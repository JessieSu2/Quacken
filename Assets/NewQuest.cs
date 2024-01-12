using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewQuest : MonoBehaviour
{
    [SerializeField] private AudioSource newQuestSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Quest"))
        {
            newQuestSoundEffect.Play();
        }
    }
}
