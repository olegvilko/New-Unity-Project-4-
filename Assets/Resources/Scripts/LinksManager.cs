using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LinksManager : MonoBehaviour
{
    public static LinksManager instance = null;

    #region Global
    public static TestMoveAll testMoveAll;
    //public static List<GameObject> gameObjects;

    public static float hideDistance = 8;
    GameObject poolDistancePref;
    public static int poolStep=3;
    public static float poolTime = 0.5f;
    public static GameObject[] poolDistance=new GameObject[700];
    

    public static GameObject dialogPanel;
    public static Text dialogText;

    public static string fileNameIni = "game.ini";

    public static string filenameSaveLoad= "stream";

    public static GameObject player;

    public static Bullet bullet;
    public static GameObject explosion1;
    public static GameObject explosion2;

    
    #endregion

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        InitializeManager();
    }

    private void InitializeManager()
    {
        testMoveAll = FindObjectOfType<TestMoveAll>();

        AddPoolsDistance();

        dialogPanel = GameObject.Find("UpPanel/Dialog");
        dialogText = dialogPanel.GetComponentInChildren<Text>();
        dialogPanel.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player");

        bullet = Resources.Load<Bullet>("Prefabs/items/Bullet");
        explosion1 = Resources.Load("Prefabs/items/Particles/particle1") as GameObject;
        explosion2 = Resources.Load("Prefabs/items/Particles/particle2") as GameObject;
    }

    private void AddPoolsDistance()
    {
        GameObject poolsDistance = new GameObject();
        poolsDistance.name = "poolsDistance";

        poolDistancePref = Resources.Load<GameObject>("Prefabs/items/poolDistance");
        for (var i = 0; i < poolDistance.Length; i++)
        {
            poolDistance[i] = Instantiate(poolDistancePref);
            poolDistance[i].transform.parent = poolsDistance.transform;
            Distance distance = poolDistance[i].GetComponent<Distance>();
            distance.reloadTime = i * poolTime + 1;
        }
    }
}
