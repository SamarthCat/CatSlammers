using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIPopUp : MonoBehaviour
{
    public string Title = "Title Go Brrrrrrr!";
    public string SceneToLoad;
    public TextMeshProUGUI tmp;
    public Button Close;
    public Animation an;
    public AnimationClip anClip;
    public GameObject[] disable;
    public bool CanClose = true;
    public bool OneTime = false;
    public bool Load = false;
    public bool dontDestroy = true;
    public GameObject Panel;
    RectTransform rt;

    void Awake()
    {
        an.clip = anClip;
        if (dontDestroy)
        {
            DontDestroyOnLoad(gameObject);
        }
        rt = Panel.GetComponent(typeof(RectTransform)) as RectTransform;
        tmp.text = Title;
        if (!CanClose)
        {
            Close.interactable = false;
        }
    }

    public void funcshow()
    {
        StartCoroutine(show());
    }

    public void funcclose()
    {
        StartCoroutine(close());
    }

    public IEnumerator close()
    {
        if (CanClose)
        {
            if (OneTime)
            {
                Destroy(gameObject);
            }
            Panel.SetActive(false);
            rt.anchoredPosition = new Vector3(rt.anchoredPosition.x, -419);
            for (int i = 0; i < disable.Length; i++)
            {
                disable[i].SetActive(true);
            }
            yield return null;
        }
    }

    public IEnumerator show()
    {
        if (true)
        { 
            for (int i = 0; i < disable.Length; i++)
            {
                disable[i].SetActive(false);
            }

            if (Load)
            {
                SceneManager.LoadScene(SceneToLoad);
            }
            Panel.SetActive(true);
            an.Play();
            yield return new WaitForSeconds(1);
            rt.anchoredPosition = new Vector3(rt.anchoredPosition.x, -5);
            Panel.SetActive(true);
            yield return null;


        }
    }


    void Update()
    {
        
    }
}
