using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBox : MonoBehaviour
{

    public Challenge_Power my_challenger;

    void OnMouseDown()
    {
        if (!my_challenger.fuse_inserted)
        {
            Debug.Log("Fuse Inserted");
            my_challenger.fuse_inserted = true;
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
