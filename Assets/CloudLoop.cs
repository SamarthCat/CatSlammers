using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudLoop : MonoBehaviour
{



    [SerializeField]
    public Transform tf;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (tf.position.x > 12.5) 
        {
            tf.position = new Vector2(-20.5f, tf.position.y);
        }


    }
}
