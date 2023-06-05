using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{

    public bool allow_duplicates = true;
    public string my_tag;

    void Start()
    {

        GameObject[] other_sources = GameObject.FindGameObjectsWithTag(my_tag);
        if (other_sources.Length > 1 && !allow_duplicates)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}

