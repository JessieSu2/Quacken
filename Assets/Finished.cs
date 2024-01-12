using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finished : MonoBehaviour
{
    private AudioSource finishSound;
    [SerializeField] private GameObject Quest;
    [SerializeField] private GameObject player;
    private int maxCount;
    private int itemCount;
    private bool levelCompleted = false;
    // Start is called before the first frame update
    void Start() 
    {
        finishSound = GetComponent<AudioSource>();
        maxCount = Quest.GetComponent<Quest>().maxCount;
    }
    private void Update() 
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        itemCount = player.GetComponent<ItemCollector>().itemCount;
        if (itemCount >= maxCount && collision.gameObject.CompareTag("Player") && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
        else
        {
            print("Not Finished");
        }
    }

    private void CompleteLevel() 
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } 

}
