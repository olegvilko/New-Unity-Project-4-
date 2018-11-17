using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBack : MonoBehaviour
{

    public bool timeout = true;

    public float timeCounter = 10f;

    // private float timer = 0;

    private float scale;

    private float step;

    //void Start()
    //{

    //}

    public void RollbackStart(float time)
    {
        timeout = false;
        scale = 1;
        InvokeRepeating("NewScale", time, time);
    }

    void NewScale()
    {

        //        Debug.Log(scale);



        scale = scale - timeCounter;
        if (scale <= 0)
        {
            scale = 0;
            timeout = true;
            CancelInvoke();
        }
        transform.localScale = new Vector3(1, scale, 1);

    }


}
