using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class OnNetStart : MonoBehaviour
{
    public GameObject Win;
    public GameObject Lose;
    public TMP_InputField tmpi;
    public TMP_InputField portText;
    public NetworkManager man;
    public TelepathyTransport tp;
    void Awake()
    {
        Win = GameObject.FindGameObjectWithTag("PopUp");
        Lose = GameObject.FindGameObjectWithTag("Finish");
        Win.SetActive(false);
        Lose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        man.networkAddress = tmpi.text;
        tp.port = ushort.Parse(portText.text);
    }
}
