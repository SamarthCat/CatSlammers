using UnityEngine;
using System.Collections;
using Mirror;
using UnityEngine.UI;

public class mjump : NetworkBehaviour
{
    #if UNITY_ANDROID
    bool isMobile = true;
    #elif UNITY_IOS
    bool isMobile = true;
    #else
    bool isMobile = false;
    #endif

    public float speed = 5f;
    public float jumpSpeed = 8f;
    private Rigidbody2D rigidBody;
    public Transform tf;
    public AudioSource audio;
    public AudioClip jumpclip;
    public Button jump;

    [Client]
    void Start()
    {
        //isMobile = true;
        if (isMobile)
        {
            jump = GameObject.FindGameObjectWithTag("jumpButton").GetComponent<Button>();
            jump.onClick.AddListener(jumpy);
        }
        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent(typeof(AudioSource)) as AudioSource;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    [Client]
    void OnCollisionEnter2D(Collision2D col)
    {

        
    }


    public void jumpy()
    {
        if (!hasAuthority) { return; }
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        audio.PlayOneShot(jumpclip, 1f);
    }

    [Client]
    void FixedUpdate()
    {
        if (!hasAuthority) { return; }
        if (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown("joystick button 0"))
        {
            jumpy();
        }
        
    }
}