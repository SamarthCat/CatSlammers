using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColourTint : MonoBehaviour
{
    public Image img;
    public TextMeshProUGUI tmp;
    public TextMeshProUGUI nameTmp;
    public SpriteRenderer sr;

    private void Awake()
    {
        try
        {
            nameTmp.text = GetName(true);
        }
        catch
        {

        }
    }

    string GetName(bool WithAppend)
    {
        if (WithAppend)
        {
            if (PlayerPrefs.GetInt("NoLB") == 1)
            {
                return PlayerPrefs.GetString("username") + "(Private)";
            }
            else
            {
                return PlayerPrefs.GetString("username");
            }
        }
        else
        {
            return PlayerPrefs.GetString("username");
        }
    }


    void FixedUpdate()
    {
        try
        {
            string[] colour = PlayerPrefs.GetString("Colour").Split(new char[] { '_' });
            img.color = new Color(float.Parse(colour[0]), float.Parse(colour[1]), float.Parse(colour[2]), img.color.a);
        }
        catch
        {

        }

        try
        {
            string[] colour = PlayerPrefs.GetString("Colour").Split(new char[] { '_' });
            tmp.color = new Color(float.Parse(colour[0]), float.Parse(colour[1]), float.Parse(colour[2]), tmp.color.a);
        }
        catch
        {

        }

        try
        {
            string[] colour = PlayerPrefs.GetString("Colour").Split(new char[] { '_' });
            sr.color = new Color(float.Parse(colour[0]), float.Parse(colour[1]), float.Parse(colour[2]), sr.color.a);
        }
        catch
        {

        }

    }


}
