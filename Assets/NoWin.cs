using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWin : MonoBehaviour
{
    public bc bc;
    public GameObject tp;

    // Start is called before the first frame update
    void Start()
    {
        tp.SetActive(false);
    }

    IEnumerator disableBC()
    {
        yield return new WaitForSeconds(1f);
        bc.enabled = false;
        Time.timeScale = 1;
        bc.ec.enabled = false;
        bc.esr.enabled = false;
        Debug.ClearDeveloperConsole();
        tp.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (bc.enabled)
        {
            if (bc.EHealth <= 0)
            {
                bc.EHealth = 0.0000001f;
                bc.Ediv = 99999999999;
                StartCoroutine(disableBC());
            }
        }
    }
}
