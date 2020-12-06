using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLMENU : MonoBehaviour
{



    [SerializeField]
    public Transform tf;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (tf.position.x > 15) 
        {
            tf.position = new Vector2(-20.5f, tf.position.y);
        }


    }
}
