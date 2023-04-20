using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{

    public Transform camera_mover;

    public Transform bar_holster;
    public Transform bar_left;
    public Transform bar_right;
    public Transform back_holster;

    public Image timer_a;
    public Image timer_b;
    public Image timer_c;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Mind.in_control = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mind.in_control)
        {

            timer_a.enabled = Mind.currently_in_back;
            timer_b.enabled = Mind.currently_in_back;
            timer_c.enabled = Mind.currently_in_back;

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
                Vector3 new_position = new Vector3(camera_mover.position.x + (speed * Time.deltaTime * Input.GetAxis("Horizontal")), camera_mover.position.y, camera_mover.position.z);
                bar_holster.position = new_position;
            }
        }
    }
}
