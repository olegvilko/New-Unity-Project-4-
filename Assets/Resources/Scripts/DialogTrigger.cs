using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour {

    public GameObject dialog;
    public Text textComponent;
    Text newText;
    // Use this for initialization
    void Awake () {
        //    dialog = GameObject.Find("Dialog");
        newText = GetComponent<Text>();
	}
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
  //       Debug.Log(collision.tag);
        if (collision.tag == "Player")
        {
            textComponent.text = newText.text;
            dialog.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialog.SetActive(false);
        }
    }
}
