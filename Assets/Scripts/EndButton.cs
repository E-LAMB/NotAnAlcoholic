using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour
{

    public GameplayDirector the_director;
    bool pressed;

    void OnMouseDown()
    {
        if (!pressed)
        {
            the_director.EndMyShift();
        }
    }

}
