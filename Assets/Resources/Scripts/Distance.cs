using UnityEngine;

public class Distance : MonoBehaviour {

    [SerializeField]
    public float reloadTime=1.0f;

    [SerializeField]
    private int childs;

    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > reloadTime)
        {
            timer = 0;

            childs = transform.childCount;
            for (var i = 0; i < childs; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }

        }

    }
}
