using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Identifier_Shaker : MonoBehaviour
{

    public string most_recent_item;
    public int destructable_layer;

    public string[] items_in_shaker;
    public int item_number;

    // Start is called before the first frame update
    void Start()
    {
        Mind.drink_ingredients = items_in_shaker;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<ItemIdentity>())
        {
            most_recent_item = other.gameObject.GetComponent<ItemIdentity>().my_identity;
            if (other.gameObject.layer == destructable_layer)
            {
                items_in_shaker[item_number] = most_recent_item;
                item_number += 1;
                Mind.drink_ingredients = items_in_shaker;
                Destroy(other.gameObject);
            }
        } 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
