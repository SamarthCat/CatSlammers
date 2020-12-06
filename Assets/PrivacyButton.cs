using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivacyButton : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void yes()
    {
        PlayerPrefs.SetInt("NoLB", 0);
        Destroy(gameObject);
    }

    public void no()
    {
        PlayerPrefs.SetInt("NoLB", 1);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
