using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform camera_mover;

    public Transform bar_holster;
    public Transform bar_left;
    public Transform bar_right;
    public Transform back_holster;

    // Start is called before the first frame update
    void Start()
    {
        Mind.in_control = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mind.in_control)
        {
            if (Mind.currently_in_back)
            {
                camera_mover.position = back_holster.position;
            } else
            {
                camera_mover.position = bar_holster.position;
                if (bar_holster.position.x < bar_left.position.x)
                {
                    bar_holster.position = bar_left.position;
                }
                if (bar_holster.position.x > bar_right.position.x)
                {
                    bar_holster.position = bar_right.position;
                }
                camera_mover.position = bar_holster.position;
                Vector3 new_position = new Vector3(camera_mover.position.x + Input.GetAxis("Horizontal"), camera_mover.position.y, camera_mover.position.z);
                bar_holster.position = new_position;
            }
        }
    }
}
