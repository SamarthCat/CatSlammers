using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public PopUp pp;
    public int value = 1;
    public bool up = true;
    public float vel = 0.1f;
    public GameObject[] popup;
    public TextMeshProUGUI tmp;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            tmp.text = "+" + value.ToString();
            pp.animate();
            PlayerPrefs.SetInt("dataCoins", PlayerPrefs.GetInt("dataCoins") + value);
            Destroy(gameObject);
        }
    }

    IEnumerator bob()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            up = false;
            yield return new WaitForSeconds(1);
            up = true;
        }
    }


    void Start()
    {
        popup = GameObject.FindGameObjectsWithTag("PopUp");
        pp = popup[0].GetComponent(typeof(PopUp)) as PopUp;
        tmp = popup[0].GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        StartCoroutine("bob");
    }

    
    void Update()
    {
        if (up)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + vel);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - vel);
        }




    }
}
