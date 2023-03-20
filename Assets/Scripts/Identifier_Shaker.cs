using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Identifier_Shaker : MonoBehaviour
{

    public string most_recent_item;

    public LayerMask object_collided;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {

        most_recent_item = "happened";

        Debug.Log("Something entered!!");
        if (other.gameObject.GetComponent<ItemIdentity>())
        {
            Debug.Log("Worked 2");
            most_recent_item = other.gameObject.GetComponent<ItemIdentity>().my_identity;
        } 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
