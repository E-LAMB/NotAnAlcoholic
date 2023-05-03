using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BouncerBell : MonoBehaviour
{

    public bool is_using_bouncer;
    public bool bell_ready;

    public bool selected_a_target;

    public GameObject backarea_button;

    public TextMeshPro my_text;

    public Patron targeted;

    public Bouncer hugo_npc;

    public GameplayDirector my_director;
    public OrderGenerator my_order_generator;

    void OnMouseDown()
    {

        if (bell_ready && !is_using_bouncer && !selected_a_target)
        {
            is_using_bouncer = true;
            my_text.text = "Select a target for Hugo";

        } else if (is_using_bouncer && !selected_a_target)
        {
            is_using_bouncer = false;
            my_text.text = " ";
        }

    }

    public void clicked_on(Patron myself)
    {
        if (is_using_bouncer)
        {
            targeted = myself;
            selected_a_target = true;
            my_text.text = " ";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        my_text.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        backarea_button.SetActive(!is_using_bouncer);

        if (selected_a_target)
        {
            selected_a_target = false;
            is_using_bouncer = false;
            bell_ready = false;

            targeted.my_conversation_controller.bell_selected_patron = targeted;
            targeted.my_conversation_controller.my_own_state = 6;

            hugo_npc.pred_patron = targeted;

            if (targeted = targeted.my_conversation_controller.commanding_1)
            {
                hugo_npc.victim_patron = targeted.my_conversation_controller.commanding_1;
            }

            if (hugo_npc.victim_patron == hugo_npc.pred_patron)
            {
                hugo_npc.victim_patron = targeted.my_conversation_controller.commanding_2;
            }

            hugo_npc.Activate();

            // Stuff to reset order
            if (my_order_generator.is_angelshot)
            {
                my_order_generator.just_served_angel = true;
                my_director.the_shaker.times_shaken = 0;
                my_director.the_shaker.shaker_position = "md";
                my_director.dispensed_fluid = false;
                my_director.gameplay_loop_drinks = 0;
                my_director.the_shaker.placing_ingredients = true;
                my_director.has_an_order = false;
                my_director.just_served = false;
                my_director.the_order_generator.clear_note();
                my_order_generator.selected_patron_seat.has_drink = true;
                my_order_generator.selected_patron_seat.other_person.has_drink = true;
            }
        }

    }
}
