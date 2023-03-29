using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationController : MonoBehaviour
{

    public bool currently_free;

    public Patron commanding_1;
    public Patron commanding_2;

    public SeatScript seat_1;
    public SeatScript seat_2;

    public Transform spawner_1;
    public Transform spawner_2;

    public int conversation_progress;
    public float dia_countdown;

    [Header("Dialouge")]
    public float time_to_wait;
    public bool[] from_speaker_a;
    public string[] what_to_say;
    public bool conversation_concluded;

    public float speaking_speed;

    public int my_own_state;
    // 0 = Offscreen idle
    // 1 = Patrons are both walking
    // 2 = Patrons are sitting down
    // 3 = Puppeting Conversation
    // 4 = Standing up
    // 5 = Leaving
    // 6 = OOBs 

    public void Activate()
    {

        conversation_progress = 0;

        speaking_speed = Mind.speaking_speed;

        currently_free = false;
        commanding_1.currently_free = false;
        commanding_2.currently_free = false;
        seat_1.currently_free = false;
        seat_2.currently_free = false;

        commanding_1.my_seat_script = seat_1;
        commanding_2.my_seat_script = seat_2;
        
        commanding_1.my_spawner = spawner_1;
        commanding_2.my_spawner = spawner_2;

        commanding_1.Activate();
        commanding_2.Activate();

        my_own_state = 1;

    }

    void Update()
    {

        if (my_own_state == 1)
        {
            if (commanding_1.completed_state && commanding_2.completed_state)
            {
                commanding_1.my_state = 2;
                commanding_2.my_state = 2;
                my_own_state = 2;
                commanding_1.completed_state = false;
                commanding_2.completed_state = false;
            }
        }

        if (my_own_state == 2)
        {
            if (commanding_1.completed_state && commanding_2.completed_state)
            {
                commanding_1.my_state = 3;
                commanding_2.my_state = 3;
                my_own_state = 3;
                commanding_1.completed_state = false;
                commanding_2.completed_state = false;
                dia_countdown = 2000f;
                time_to_wait = 0f;
                conversation_progress = 0;
                conversation_concluded = false;
            }
        }

        if (my_own_state == 3)
        {
            dia_countdown += Time.deltaTime;    
            if (dia_countdown > time_to_wait)
            {
                conversation_progress += 1;

                time_to_wait = what_to_say[conversation_progress].Length / speaking_speed;
                if (0.4f > time_to_wait)
                {
                    time_to_wait = 0.4f;
                }

                dia_countdown = 0;

                if (what_to_say[conversation_progress] == "$EndOfConvo")
                {
                    conversation_concluded = true;
                    my_own_state = 4;
                    commanding_1.my_state = 4;
                    commanding_2.my_state = 4;
                }

                if (!conversation_concluded)
                {
                    if (from_speaker_a[conversation_progress])
                    {
                        commanding_1.Speaking(what_to_say[conversation_progress], time_to_wait);
                    } else
                    {
                        commanding_2.Speaking(what_to_say[conversation_progress], time_to_wait);
                    }
                }
            }
        }

        if (my_own_state == 4)
        {
            if (commanding_1.completed_state && commanding_2.completed_state)
            {
                commanding_1.my_state = 5;
                commanding_2.my_state = 5;
                my_own_state = 5;
                commanding_1.completed_state = false;
                commanding_2.completed_state = false;
            }
        }

        if (my_own_state == 5)
        {
            if (commanding_1.completed_state && commanding_2.completed_state)
            {
                commanding_1.my_state = 0;
                commanding_2.my_state = 0;
                my_own_state = 0;
                commanding_1.completed_state = false;
                commanding_2.completed_state = false;
                currently_free = true;
                commanding_1.currently_free = true;
                commanding_2.currently_free = true;
                seat_1.currently_free = true;
                seat_2.currently_free = true;
            }
        }

    }

}
