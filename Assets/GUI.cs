using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUI : MonoBehaviour
{

    public NetworkManager manager;
    public TMP_InputField tmpi;
    public TextMeshProUGUI tmp;
    public GameObject canvas;

    void Start()
    {
        
    }

    public void host()
    {
        manager.StartHost();
        canvas.SetActive(false);
    }

    public void client()
    {
        
        
        manager.StartClient();
        manager.networkAddress = tmpi.text;
        tmp.text = "Connecting...";


    }

    

    // Update is called once per frame
    void Update()
    {
        if (manager.isNetworkActive)
        {
            canvas.SetActive(false);
        }
    }
}
