using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public bool Unflip = false;
    public Rigidbody2D rb;
    public jump jmp;
    public BoxCollider2D boxc;
    public BoxCollider2D playerc;
    public GameObject player;
    public SpriteRenderer psr;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            flip();
        }
    }

    public void flip()
    {
        if (Unflip)
        {
            //psr.flipY = false;
            player.transform.localScale = new Vector3(player.transform.localScale.x, 1, 1);
            rb.gravityScale = 2;
            jmp.jumpSpeed = 8;
        }
        else
        {
            //psr.flipY = true;
            player.transform.localScale = new Vector3(player.transform.localScale.x, -1, 1);
            rb.gravityScale = -2;
            jmp.jumpSpeed = -8;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (boxc.IsTouching(playerc))
        {
            flip();
        }
    }
}
