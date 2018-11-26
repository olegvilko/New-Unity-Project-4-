using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveAll : MonoBehaviour
{

    //    public Transform[] transforms;
  //  public GameObject[] objs;

  public  List<GameObject> gameObjects;

    // Update is called once per frame
    void Update()
    {
        // gameObjects.Add
        //	transforms.SetValue()
        //   GameObject[] objs = GameObject.FindGameObjectsWithTag("test");

     //   var direction = Vector3.right;
        for (var i = 0; i < gameObjects.Count; i++)
        {
            Vector3 direction =new Vector3 (Direction(gameObjects[i].transform.localScale.x), 0,0);
            gameObjects[i].transform.position = Vector3.MoveTowards(gameObjects[i].transform.position, gameObjects[i].transform.position + direction, 1 * Time.deltaTime);
        }

    }

    float Direction(float scaleX)
    {
        if (scaleX > 0)
        {
            return 1.0f;
        }
        else
        {
            return -1.0f;
        }
    }
}
