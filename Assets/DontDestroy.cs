using System.Collections;
using System.Collections.Generic;
using Unity.RemoteConfig;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{


    public AudioSource aus;
    private static DontDestroy instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        play();
    }

    public void play()
    {
        aus.clip = Resources.Load<AudioClip>(PlayerPrefs.GetString("currentMusic"));
        aus.Play();
    }

    void Update()
    {

        if (SceneManager.GetActiveScene().name.Contains("Title"))
        {

        }
        else if (SceneManager.GetActiveScene().name.Contains("Level"))
        {

        }
        else if (SceneManager.GetActiveScene().name.Contains("Shop"))
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }




}
