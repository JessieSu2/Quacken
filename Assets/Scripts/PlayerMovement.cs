using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    private float dirX;
    private float fallMultiplier = 2.5f;
    private float lowJumpMultiplier = 2f;
    private float fall;
    private float low;
    private float moveSpeed = 7f;
    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState
    {
        idle, //0
        running, //1
        falling, //2
        sitting,//3
        walking //4
    };

    [SerializeField] private AudioSource jumpSoundEffect;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        
       
        fall = Physics2D.gravity.y * ((fallMultiplier - 1) * Time.deltaTime);
        low = Physics2D.gravity.y * ((lowJumpMultiplier - 1) * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, 7f);
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * fall;
        }
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump") )
        {
            rb.velocity += Vector2.up * low;
        }

        UpdateAnimationState();
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

    }

    private void UpdateAnimationState()
    {
        MovementState state; 
        if (Input.GetKey(KeyCode.LeftShift) && (dirX > 0f || dirX < 0f))
        {
            moveSpeed = 17f;
            state = MovementState.running;
        }
        else
        {
            moveSpeed = 7f;
            state = MovementState.walking;
        }
        

        if (dirX > 0f)
        {
            state = MovementState.walking;
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            state = MovementState.walking;
            sprite.flipX = true;
        } 
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y < -1f)
        {
            state = MovementState.falling;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            state = MovementState.sitting;
        }

        anim.SetInteger("state", (int)state);


    }


    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down,.1f, jumpableGround );
    }



}
