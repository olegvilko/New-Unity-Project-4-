using UnityEngine;
using UnityEngine.UI; 

public class BackgroundHelper : MonoBehaviour
{

    public float speed = 0; 

    float pos = 0;

    public RawImage image; 

    public float height = 3;

    Vector3 startPos;

    void Update()
    {
        pos += speed*Time.deltaTime;

            if (pos > 1.0F)

            pos -= 1.0F;

        image.uvRect = new Rect(pos, 0, 1, 1);

    }
}