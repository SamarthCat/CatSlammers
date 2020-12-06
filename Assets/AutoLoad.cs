using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoLoad : MonoBehaviour
{

    public string sceneToLoad;
    public bool load = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (load)
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        if (Input.GetKeyDown("/"))
        {
            PlayerPrefs.SetInt("dataCoins", 9999);
        }
    }
}
