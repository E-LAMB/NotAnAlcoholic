using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerFuse : MonoBehaviour
{

    public Challenge_Power my_challenger;

    void OnMouseDown()
    {
        if (!my_challenger.fuse_collected)
        {
            Debug.Log("Collected Fuse");
            my_challenger.fuse_collected = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
