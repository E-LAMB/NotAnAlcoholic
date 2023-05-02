using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnClick : MonoBehaviour
{
    
    public GameObject to_enable;

    void OnMouseDown()
    {
        to_enable.SetActive(true);
    }

    public void DisableIt()
    {
        to_enable.SetActive(false);
    }

}
