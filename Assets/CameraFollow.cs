using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public bool y;
    public bool x;
    public bool pan;
    public bool unpan;
    public Transform tf;
    public Transform ptf;
    public float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

        if (unpan)
        {
            if (tf.position.y > 3f)
            {
                tf.position = new Vector3(tf.position.x, tf.position.y - 0.001f, -10f);
            }
            else
            {
                pan = true;
                unpan = false;
            }

        }

        if (y)
        {
            tf.position = new Vector3(tf.position.x, ptf.position.y + yOffset, -10f);
        }
        if (x)
        {
            tf.position = new Vector3 (ptf.position.x, tf.position.y, -10f);
        }
        if (pan)
        {
            tf.position = new Vector3(tf.position.x, tf.position.y + 0.001f, -10f);
            if (tf.position.y >= 20)
            {
                unpan = true;
                pan = false;
            }

        }

    }
}
