using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{


    [SerializeField]
    public float Vel;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + (Vel / 1000), transform.position.y) ;
    }
}
