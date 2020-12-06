using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExampleColorReceiver : MonoBehaviour {
	
    Color color;
    public GameObject close;
    public GameObject go;
    public TextMeshProUGUI tmp;
    public Image img;

    void Awake()
    {
        color = new Color(255, 255, 255, 255);
    }



    public void OnColorChange(HSBColor color) 
	{
        this.color = color.ToColor();
	}

    void OnGUI()
    {
		//var r = Camera.main.pixelRect;
		//var rect = new Rect(r.center.x + r.height / 6 + 50, r.center.y, 100, 100);
		//GUI.Label (rect, "#" + ToHex(color.r) + ToHex(color.g) + ToHex(color.b));	
    }

    public void Show()
    {
        gameObject.SetActive(true);
        close.SetActive(true);
        go.SetActive(false);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        close.SetActive(false);
        go.SetActive(true);
    }



    void Update()
    {
       PlayerPrefs.SetString("Colour", color.r + "_" + color.g + "_" + color.b + "_");
       tmp.color = new Color(color.r, color.g, color.b, 255);
       img.color = new Color(color.r, color.g, color.b, 255);
    }

    string ToHex(float n)
	{
		return ((int)(n * 255)).ToString("X").PadLeft(2, '0');
	}
}
