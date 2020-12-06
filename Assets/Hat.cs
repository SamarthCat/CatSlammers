using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{

    public Sprite CurrentHat;
    public SpriteRenderer sr;
    SpriteRenderer psr;
    float normalPosY;

    void Start()
    {
        psr = GetComponentInParent(typeof(SpriteRenderer)) as SpriteRenderer;
        if (PlayerPrefs.GetString("currentCat") == "cat7")
        {
            // 0.34, 1.54
            transform.localPosition = new Vector3(0.34f, 1.54f, 0f);
        }

        if (PlayerPrefs.GetString("currentCat") == "cat15")
        {
            // 0.36, 1.38
            transform.localPosition = new Vector3(0.36f, 1.38f, 0f);
        }

        normalPosY = transform.localPosition.y;
        sr = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        CurrentHat = Resources.Load<Sprite>(PlayerPrefs.GetString("currentHat"));
        sr.sprite = CurrentHat;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
