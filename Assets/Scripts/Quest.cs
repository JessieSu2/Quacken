using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public string dialog;
    public bool playerInRange;
    public int maxCount;
    public int itemCount = 0;
    public string itemName;
    [SerializeField] private GameObject item;
    [SerializeField] private TextMeshProUGUI itemText;

    // Start is called before the first frame update
    void Start()
    {
        item.SetActive(false);
    }

    // Update is called once per frame 
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            dialogBox.SetActive(true);
            dialogText.text = dialog;
            print("Enter");
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            print("Exit");
            playerInRange = false;
            item.SetActive(true);
            itemText.text = itemName + ": ?";
        }
    }
}
