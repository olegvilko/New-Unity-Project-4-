using UnityEngine;

public class HideByDistance : MonoBehaviour
{
    public float distance = 0.0f;

    [SerializeField]
    private int removalRate = 8;

    private Transform child;

    private float timer = 0;

    void Start()
    {
        child = transform.Find("child");
    }

    void Update()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        var heading = transform.position - LinksManager.player.transform.position;
        distance = heading.magnitude;
        if (distance < LinksManager.hideDistance)
        {
            child.gameObject.SetActive(true);
        }
        else
        {
            for (var i = LinksManager.poolDistance.Length-1; i >= 0; i--)
            {
                if (distance >LinksManager.hideDistance+ LinksManager.poolStep * i)
                {
                    gameObject.transform.parent = LinksManager.poolDistance[i].transform;
                    gameObject.SetActive(false);
                    break;
                }
                child.gameObject.SetActive(false);
            }
        }
    }
}
