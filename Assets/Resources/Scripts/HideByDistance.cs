using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideByDistance : MonoBehaviour
{
    private Transform child;

    private float timeCounter = 0.0f;
    private float timer = 0;

    void Start()
    {
        child = transform.Find("child");
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeCounter)
        {
            timer = 0;
            CheckDistance();
        }
    }

    private void CheckDistance()
    {
        var heading = transform.position - LinksManager.player.transform.position;
        var distance = heading.magnitude;
        if (distance < LinksManager.hideDistance)
        {
            child.gameObject.SetActive(true);
        }
        else
        {
            child.gameObject.SetActive(false);
        }

        timeCounter = distance/8;
    }
}
