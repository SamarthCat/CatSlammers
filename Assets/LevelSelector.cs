using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelector : MonoBehaviour
{

    public LevelLoader ll;
    public string other;

    public void Back()
    {
        Time.timeScale = 1f;
        ll.Load("Title");
    }

    public void Play()
    {
        Time.timeScale = 1f;
        ll.Load("LevelSelect");
    }

    public void Other()
    {
        Time.timeScale = 1f;
        ll.Load(other);
    }

    public void Map1()
    {
        Time.timeScale = 1f;
        ll.Load("Map1");
    }

    public void Current()
    {
        Time.timeScale = 1f;
        ll.Load(SceneManager.GetActiveScene().name);
    }
}