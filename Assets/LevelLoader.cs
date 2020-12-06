using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public Animator an;
    public Image loader;
    public void Load(string scene)
    {
        StartCoroutine(LoadLevel(scene));
    }

    IEnumerator LoadLevel(string scene)
    {
        an.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(scene);
    }


    void FixedUpdate()
    {
        var euler = loader.transform.eulerAngles;
        euler.z -= 1.8f;
        loader.transform.eulerAngles = euler;
    }
}
