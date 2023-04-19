using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Patron : MonoBehaviour
{

    public bool currently_free;

    public bool assigned_to_conversation;

    public bool am_predator;

    public GameplayDirector gameplay_director;

    public GameObject pred_indicator;

    public SeatScript my_seat_script;
    public int seat_number;

    public Transform self;
    public float movement_speed;

    public Transform my_spawner;

    public float walking_height = 0.5f;
    public float original_height;

    public int my_state;
    // 0 = Offscreen Idle
    // 1 = Walking To Seat
    // 2 = Sitting Down & Facing The Correct Direction
    // 3 = Conversating
    // 4 = Getting Up
    // 5 = Leaving
    // 6 = OOB

    public float text_fade_time;
    public Vector4 text_colour;

    public bool completed_state;

    public void Activate()
    {

        my_state = 1;
        am_predator = false;

        seat_number = my_seat_script.seat_number;
        seat_location = my_seat_script.Expose_location();

        self.position = my_spawner.position;
        OOB_location = new Vector3 (self.position.x, self.position.y + walking_height, self.position.z);
        self.position = new Vector3 (self.position.x, self.position.y + walking_height, self.position.z);

        seat_location.y += walking_height;
        original_height = walking_height;

    }

    public void Speaking(string to_say, float time_to_say)
    {

        text_fade_time = time_to_say - 0.125f;
        my_text.text = to_say;
        text_colour.w = 1f;

    }

    public float distance_to_seat;
    public float distance_to_OOB;

    public Vector3 OOB_location;
    public Vector3 seat_location;

    public Vector3 new_position;

    public TMPro.TextMeshPro my_text;
    public GameObject text_gameobject;

    // Update is called once per frame
    void Update()
    {

        if (am_predator)
        {
            pred_indicator.SetActive(true);
        } else
        {
            pred_indicator.SetActive(false);
        }

        if (text_fade_time <= 0.125f)
        {
            text_colour.w = text_fade_time * 8f;
        } 

        my_text.color = text_colour;

        if (text_fade_time > 0)
        {
            text_fade_time -= Time.deltaTime;
        }

        if (my_state == 1)
        {

            new_position = Vector3.MoveTowards(self.position, seat_location, Time.deltaTime * movement_speed);
            self.position = new_position;
            distance_to_seat = Vector3.Distance(self.position, seat_location);
            if (distance_to_seat < 0.1f)
            {
                if (!completed_state) { gameplay_director.drinks_logged += Random.Range(1f, 1.5f); }
                completed_state = true;
            }

        }

        if (my_state == 2)
        {   

            if (walking_height > 0)
            {
                walking_height -= Time.deltaTime;
            } else
            {
                completed_state = true;
            }

            if (walking_height < 0)
            {
                walking_height = 0;
            }

            seat_location.y = walking_height;

            self.position = seat_location;

        }

        if (my_state == 3)
        {
            text_gameobject.SetActive(true);
        } else
        {
            text_gameobject.SetActive(false);
        }

        if (my_state == 4)
        {   

            if (walking_height < original_height)
            {
                walking_height += Time.deltaTime;
            } else
            {
                completed_state = true;
            }

            if (walking_height > original_height)
            {
                walking_height = original_height;
            }

            seat_location.y = walking_height;

            self.position = seat_location;

        }

        if (my_state == 5)
        {

            new_position = Vector3.MoveTowards(self.position, OOB_location, Time.deltaTime * movement_speed);
            self.position = new_position;
            distance_to_OOB = Vector3.Distance(self.position, OOB_location);
            if (distance_to_OOB < 0.1f)
            {
                completed_state = true;
            }

        }

    }
}
