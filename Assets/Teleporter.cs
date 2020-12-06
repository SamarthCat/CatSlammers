using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform otherportal;
    public Transform ptf;
    public jump jmp;
    public float factor = 2;
    public bool otherscene;
    public LevelSelector ls;
   

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            if (otherscene)
            {
                ls.Other();
            }
            else
            {
                TP(otherportal);
            }
        }
    }

    public void TP(Transform target)
    {
        ptf.position = new Vector2(otherportal.position.x, otherportal.position.y + factor);
        jmp.jumpy();
    }
}
