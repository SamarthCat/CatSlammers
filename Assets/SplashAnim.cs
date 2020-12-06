using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SplashAnim : MonoBehaviour
{
    public Animator an;
    public TextMeshProUGUI tmp;
    public float alpha = 100;
    public bool goingUp = false;
    public LevelSelector ls;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Count());
    }



    IEnumerator Count()
    {
        yield return new WaitForSeconds(6);
        an.speed = 0f;
    } 


    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetAxisRaw("Jump") > 0)
        {
            ls.Back();
        }


        if (goingUp)
        {
            if (alpha < 100)
            {
                alpha += 0.35f;
            }
            else
            {
                goingUp = false;
            }
        }

        if (!goingUp)
        {
            if (alpha > 35)
            {
                alpha -= 0.35f;
            }
            else
            {
                goingUp = true;
            }
        }

        //Debug.Log(tmp.color);
        tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, alpha/100);
    }
}
