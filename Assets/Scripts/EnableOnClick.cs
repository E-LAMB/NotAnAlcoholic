using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnClick : MonoBehaviour
{
    
    public GameObject to_enable;

    public bool tutorial_note;

    public StartButton the_start;

    void OnMouseDown()
    {
        to_enable.SetActive(true);
        if (tutorial_note)
        {
            Mind.in_control = false;
            the_start.read_note = true;
        }
    }

    public void DisableIt()
    {
        to_enable.SetActive(false);
        if (tutorial_note)
        {
            Mind.in_control = true;
        }
    }

}
