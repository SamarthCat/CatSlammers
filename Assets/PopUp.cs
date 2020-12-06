using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUp : MonoBehaviour
{
    public Animation an;
    public bc bc;
    public bool isDead = false;
    public TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
    }

    public void animate()
    {
        an.Play("PopUp");
    }

    void Update()
    {
        if (!isDead)
        {
            if(bc.PHealth <= 0)
            {
                isDead = true;
                tmp.text = "-5";
                PlayerPrefs.SetInt("dataCoins", PlayerPrefs.GetInt("dataCoins") - 5);
                animate();
            }
        }
    }
}
