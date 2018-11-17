using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLivesBar : MonoBehaviour
{
    private float length = 0.3F;

    public void Refresh(int lives, int livesMax)
    {
        float sectors = 1.0F / livesMax;
        float all = sectors * lives;
        transform.localScale = new Vector3(all, 1, 1);

    }
}
