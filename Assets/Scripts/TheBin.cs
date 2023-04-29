using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBin : MonoBehaviour
{

    float bin_time;

    public GameObject bin;

    public float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        if (cooldown < 0f)
        {
            bin_time = 0.1f;
            cooldown = 5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bin_time -= Time.deltaTime;
        cooldown -= Time.deltaTime;

        bin.SetActive((bin_time > 0f));
    }
}
