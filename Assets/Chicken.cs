using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public bool left;
    public float leftpos;
    public float rightpos;
    public Transform tf;
    public float vel;
    public float startScalex;

    // Start is called before the first frame update
    void Start()
    {
        startScalex = tf.localScale.x; 
    }


    void FixedUpdate()
    {
        if (left)
        {
            if (tf.position.x >= leftpos)
            {
                tf.position = new Vector2(tf.position.x - vel / 10, tf.position.y);
                tf.localScale = new Vector2(startScalex, tf.localScale.y);
            }
            else
            {
                left = false;
                tf.localScale = new Vector2(-startScalex, tf.localScale.y);
            }

        }
        else if (!left)
        {
            if (tf.position.x <= rightpos)
            {
                tf.position = new Vector2(tf.position.x + vel / 10, tf.position.y);
                tf.localScale = new Vector2(-startScalex, tf.localScale.y);
            }
            else
            {
                left = true;
                tf.localScale = new Vector2(startScalex, tf.localScale.y);
            }

        }

    }
}
