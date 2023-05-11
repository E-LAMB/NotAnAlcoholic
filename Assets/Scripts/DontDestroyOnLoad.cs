using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    void Start()
    {

        GameObject[] other_sources = GameObject.FindGameObjectsWithTag("DDOL");
        if (other_sources.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}

