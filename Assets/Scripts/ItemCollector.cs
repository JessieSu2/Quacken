using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public int itemCount = 0;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject itemObject;
    private string itemType;
    private int maxCount;

    [SerializeField] private AudioSource collectionSoundEffect;
    private Collider2D itemCollision;
    private bool canDestroy = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Quest"))
        {
            maxCount = collision.gameObject.GetComponent<Quest>().maxCount;
        }
        if (collision.gameObject.CompareTag("Collectable"))
        {
            
            itemType = collision.gameObject.GetComponent<CollectableScript>().itemType;
            print("itemType: " + itemType);
            if (itemType != "Vegetable")
            {
                collectionSoundEffect.Play();
                Destroy(collision.gameObject);
                itemCount++;
                print(itemCount);
                text.text = itemType + "s: " + itemCount + "/" + maxCount;
            }
        }
        if (collision.gameObject.CompareTag("Well"))
        {
            itemType = collision.gameObject.GetComponent<CollectableScript>().itemType;
        }
 }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable") && itemType == "Vegetable")
        {
            canDestroy = true;
            itemCollision = collision;
        }
        else 
        {
            canDestroy = false;
        }
    }
    private void Update()
    {
        if (itemType == "Vegetable" && canDestroy)
        {
            print("is vegetable and can destroy ");
            if (Input.GetKeyDown(KeyCode.E) && itemCollision != null)
            {
                print("pressing e");
                collectionSoundEffect.Play();
                Destroy(itemCollision.gameObject);
                itemCount++;
                text.text = itemType + "s: " + itemCount + "/" + maxCount;
            }
        }
        if (itemType == "Water" && itemCount != 1)
        {
            print("WELL WELL WELL");
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("pressing e");
                collectionSoundEffect.Play();
                itemCount++;
                text.text = itemType + ": " + itemCount + "/" + maxCount;
            }
        }
    }
}
