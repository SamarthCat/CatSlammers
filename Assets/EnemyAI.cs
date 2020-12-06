using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public AIPath aipath;
    public float enemyDamage = 1;
    public float size = 0.3f;





    void FixedUpdate()
    {
        if (aipath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-size, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(size, transform.localScale.y, transform.localScale.z);
        }



    }
}
