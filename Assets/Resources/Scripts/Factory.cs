using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
   // public int test=0;

    [SerializeField]
    private GameObject gameobject;

    [SerializeField]
    private float timeCounter = 6f;

    private float timer = 0;

    public FPSDisplay fPSDisplay;

    private void Start()
    {
      //  fPSDisplay = GetComponent<FPSDisplay>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeCounter)
        {
            timer = 0;
            newObject();
        }
    }

    private void newObject()
    {
        //     Debug.Log(test);
        //     test++;
       // for (var i = 0; i < 10; i++)
        {
            fPSDisplay.monsters++;
            GameObject newObj = Instantiate(gameobject, transform.position, transform.rotation);
        }
    }
}
