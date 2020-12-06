using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public bc bc;
    // Start is called before the first frame update
    void Start()
    {
        bc.PDamage = PlayerPrefs.GetFloat("Damage");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
