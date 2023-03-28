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

    public int my_own_state;
    // 0 = Offscreen idle
    // 1 = Patrons are both walking
    // 2 = 

    public void Activate()
    {

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

    }

    void Update()
    {

    }

}
