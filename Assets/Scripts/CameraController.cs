using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public bool looking_into_back;
    public bool just_switched_to_bar;

    public float transition_time;

    public Transform back_holster;
    
    public Transform bar_holster;
    public Transform bar_left_holster;
    public Transform bar_right_holster;

    public float speed;
    public float calculated_speed;

    public Transform target_holser;
    public Transform camera_dolly;

    public bool can_move_freely;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void CalculateTheSpeed()
    {
        calculated_speed = camera_dolly.position.x - target_holser.position.x;
        Debug.Log(calculated_speed);
        if (0 > calculated_speed)
        {
            calculated_speed = calculated_speed * -1f;
        }
        Debug.Log(calculated_speed);
        calculated_speed = calculated_speed / speed;
    }

    // Update is called once per frame
    void Update()
    {
        Mind.camera_in_bar = !looking_into_back;

        if (Mind.camera_in_bar)
        {
            if (just_switched_to_bar == false)
            {
                just_switched_to_bar = true;
                transition_time = 0.7f;
                CalculateTheSpeed();
                target_holser.position = bar_holster.position;
            }
        } else
        {
            if (just_switched_to_bar == true)
            {
                just_switched_to_bar = false;
                transition_time = 0.7f;
                CalculateTheSpeed();
                target_holser.position = back_holster.position;
            }
        }

        if (Mind.in_control)
        {

        } else
        {
            if (transition_time >= 0f || can_move_freely)
            {
                transition_time -= Time.deltaTime;
                camera_dolly.position = Vector3.MoveTowards(camera_dolly.position, target_holser.position, calculated_speed * Time.deltaTime);
            }
        }

    }
}
