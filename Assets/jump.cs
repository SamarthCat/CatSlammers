using UnityEngine;
using System.Collections;
public class jump : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private Rigidbody2D rigidBody;
    public Transform tf;
    [SerializeField]
    public bc bc;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        bc.CollideEnemy(col);
    }


    public void jumpy()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        bc.audio.PlayOneShot(bc.jumpclip, 1f);
    }

    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown("joystick button 0"))
        {
            jumpy();
        }
        
    }
}