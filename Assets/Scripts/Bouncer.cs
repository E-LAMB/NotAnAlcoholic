using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{

    public Transform self;
    public Vector3 OOB_location;

    public int current_state;
    // 0 = Inactive
    // 1 = Moving to target
    // 2 = Talking to target
    // 3 = Sending target off
    // 4 = Leaving with target

    public Patron victim_patron;
    public Patron pred_patron;

    public Vector3 target_location;

    public Vector3 new_position;

    public BouncerBell my_bell;

    public float my_speed;
    public float distance_to_target;

    public float talking_time;

    // Start is called before the first frame update
    void Start()
    {
        OOB_location = self.position;
    }

    public void Activate()
    {
        target_location = victim_patron.self.position;
        target_location += pred_patron.self.position;
        target_location = target_location / 2f;
        target_location.y = OOB_location.y;
        target_location.z = OOB_location.z;

        current_state = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (current_state == 1)
        {
            new_position = Vector3.MoveTowards(self.position, target_location, Time.deltaTime * my_speed);
            self.position = new_position;
            distance_to_target = Vector3.Distance(self.position, target_location);
            if (distance_to_target < 0.1f)
            {
                current_state = 2;
                distance_to_target = 20f;
                talking_time = 0f;
            }
        }

        if (current_state == 2)
        {
            talking_time += Time.deltaTime;
            if (talking_time > 2f)
            {

                pred_patron.my_state = 11;

                current_state = 3;
                talking_time = 0f;
            }
        }

        if (current_state == 3)
        {
            talking_time += Time.deltaTime;
            if (talking_time > 5f)
            {
                victim_patron.my_state = 7;
                current_state = 4;
                target_location = OOB_location;
            }
        }

        if (current_state == 4)
        {
            new_position = Vector3.MoveTowards(self.position, target_location, Time.deltaTime * my_speed);
            self.position = new_position;
            distance_to_target = Vector3.Distance(self.position, target_location);
            if (distance_to_target < 0.1f)
            {
                current_state = 0;
                my_bell.bell_ready = true;
                distance_to_target = 20f;
                talking_time = 0f;
            }
        }
    }
}
