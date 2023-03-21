using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropItems : MonoBehaviour
{

    public bool is_picked_up;
    public bool can_be_picked_up;

    public Vector3 moving_to;

    public Rigidbody2D my_body;

    // Start is called before the first frame update
    void Start()
    {
        
        my_body = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        can_be_picked_up = !Mind.item_is_in_hand;

        /*
        if (is_picked_up)
        {
            my_body.enabled = false;
        } else
        {
            my_body.enabled = true;
        }
        */


        is_picked_up = false;

    }

    void OnMouseDrag()
    {
        is_picked_up = true;
        WhileGrabbed();
    }

    void WhileGrabbed()
    {
        
        my_body.velocity = Vector2.zero;
        moving_to = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moving_to.z = transform.position.z;
        transform.position = moving_to;

    }

}
