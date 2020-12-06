using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RedeemCode : MonoBehaviour
{

    public TMP_InputField tmpi;
    public string[] validCodes;

    void Start()
    {
        
    }




    public void RedeemButton()
    {
        print("pressed");
        for (int i = 0; i < validCodes.Length; i++)
        {
            if (tmpi.text.ToString() == validCodes[i])
            {
                print("accepted");
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
