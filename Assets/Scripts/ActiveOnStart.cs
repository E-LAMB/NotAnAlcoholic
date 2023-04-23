using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnStart : MonoBehaviour
{

    public GameObject to_enable;
    public bool state;

    // Start is called before the first frame update
    void Start()
    {
        to_enable.SetActive(state);
    }
}
