using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    // public GameObject dialog;
   // public Image dialog;
   // public Text textComponent;
    Text newText;

    void Awake()
    {
        newText = GetComponent<Text>();
       // textComponent=
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // textComponent.text = newText.text;
            LinksManager.dialogPanel.SetActive(true);
            LinksManager.dialogText.text = newText.text;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LinksManager.dialogPanel.SetActive(false);
        }
    }
}
