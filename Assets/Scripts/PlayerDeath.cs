using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource checkpointSoundEffect;
    private void Start()
    {
        checkpoint = transform.position;
    }
    public Vector3 checkpoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            print(transform);
            print(transform.position);
            transform.position = checkpoint;
            deathSoundEffect.Play();
        }
        if (collision.tag == "CheckPoint")
        {
            checkpointSoundEffect.Play();
            print(collision.transform.position);
            checkpoint = transform.position; 
        }
    }
}
