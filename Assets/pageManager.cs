using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pageManager : MonoBehaviour
{
    public LevelLoader ll;
    public string left;
    public string right;

    void Left()
    {
        ll.Load(left);
    }

    void Right()
    {
        ll.Load(right);
    }

    void Update()
    {
        if (Input.GetKeyDown("joystick button 4") | Input.GetKeyDown("a"))
        {
            Left();
        }
        else if (Input.GetKeyDown("joystick button 5") | Input.GetKeyDown("d"))
        {
            Right();
        }
    }

}
