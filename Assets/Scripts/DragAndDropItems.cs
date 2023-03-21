using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropItems : MonoBehaviour
{

    public bool is_picked_up;

    public bool grabbed;

    public Vector3 moving_to;

    public Rigidbody2D my_body;

    public Vector3 drag_offset;

    public Transform dragger;

    public float max_distance;
    // public DistanceJoint2D drag_joint;

    // Start is called before the first frame update
    void Start()
    {
        my_body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        is_picked_up = false;
        // grabbed = false;
        // if (drag_joint.distance > max_distance) { drag_joint.distance = max_distance; }

    }

    void LateUpdate()
    {
        is_picked_up = grabbed;
        grabbed = false;
    }

    void OnMouseDrag()
    {
        is_picked_up = true;
        WhileGrabbed();
    }

    void OnMouseDown()
    {
        drag_offset = dragger.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        drag_offset.z = dragger.position.z;
    }

    void WhileGrabbed()
    {
        grabbed = true;
        my_body.velocity = Vector2.zero;
        moving_to = Camera.main.ScreenToWorldPoint(Input.mousePosition) + drag_offset;
        moving_to.z = dragger.position.z;
        dragger.position = moving_to;
        
    }

}
