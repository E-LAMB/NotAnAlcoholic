using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour
{

    public bool currently_free;

    public bool assigned_to_conversation;

    public SeatScript my_seat_script;
    public int seat_number;

    public Transform self;
    public float movement_speed;

    public Transform my_spawner;

    public int my_state;
    // 0 = Offscreen Idle
    // 1 = Walking To Seat
    // 2 = Sitting Down & Facing The Correct Direction
    // 3 = Conversating
    // 4 = Getting Up
    // 5 = Leaving
    // 6 = Out Of Bounds

    public bool completed_state;

    public void Activate()
    {

        my_state = 1;

        seat_number = my_seat_script.seat_number;
        seat_location = my_seat_script.Expose_location();

        self.position = my_spawner.position;

    }

    public float distance_to_seat;
    public float distance_to_OOB;

    public Vector3 OOB_location;
    public Vector3 seat_location;

    public Vector3 new_position;

    // Update is called once per frame
    void Update()
    {

        if (my_state == 1)
        {
            new_position = Vector3.MoveTowards(self.position, seat_location, Time.deltaTime * movement_speed);
            self.position = new_position;
            distance_to_seat = Vector3.Distance(self.position, seat_location);
        }

    }
}
