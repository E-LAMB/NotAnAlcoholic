using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Patron : MonoBehaviour
{

    public bool currently_free;

    public bool assigned_to_conversation;

    public bool am_predator;
    public bool pred_present;

    public bool can_be_belled;

    public GameplayDirector gameplay_director;

    public GameObject pred_indicator;

    public SeatScript my_seat_script;
    public int seat_number;

    public Transform self;
    public float movement_speed;

    public Transform my_spawner;

    public float walking_height = 0.5f;
    public float original_height;

    public Patron myself_patron_component;
    public Patron other_person;

    public bool has_drink;
    public bool can_order;
    public bool drink_is_spiked;

    public bool is_being_watched;
    public LayerMask watch_layer;

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

    public GameObject[] sprite_collection;
    public int sprite_chosen;

    public PatronSprites my_sprite_manager;
    public ConversationController my_conversation_controller;

    public void Activate()
    {

        sprite_collection[0].SetActive(false);
        sprite_collection[1].SetActive(false);
        sprite_collection[2].SetActive(false);
        sprite_collection[3].SetActive(false);

        sprite_collection[sprite_chosen].SetActive(true);

        my_sprite_manager = sprite_collection[sprite_chosen].GetComponent<PatronSprites>();
        my_sprite_manager.SetSprite("Default");

        my_state = 1;
        am_predator = false;

        seat_number = my_seat_script.seat_number;
        seat_location = my_seat_script.Expose_location();

        self.position = my_spawner.position;
        OOB_location = new Vector3 (self.position.x, self.position.y + walking_height, 3f);
        self.position = new Vector3 (self.position.x, self.position.y + walking_height, 3f);

        seat_location.y += walking_height;
        original_height = walking_height;

        bouncer_wait_time = 0f;

        has_drink = false;
        drink_is_spiked = false;
        can_order = false;

        time_until_drink = Random.Range(-10f, 0f);

    }

    public void Speaking(string to_say, float time_to_say)
    {

        text_fade_time = time_to_say - 0.125f;
        my_text.text = to_say;
        text_colour.w = 1f;

    }

    public void ExecuteCommand(string command)
    {
        if (command == "$Emote/Default") {my_sprite_manager.SetSprite("Default");}
        if (command == "$Emote/Sick") {my_sprite_manager.SetSprite("Sick");}
        if (command == "$Emote/Suspicious") {my_sprite_manager.SetSprite("Suspicious");}
        if (command == "$Emote/Uncomfortable") {my_sprite_manager.SetSprite("Uncomfortable");}

        if (command == "$Spike/Prepare" && !other_person.drink_is_spiked) {my_sprite_manager.SetSprite("Suspicious");}
        if (command == "$Spike/Perform" && !is_being_watched && !other_person.drink_is_spiked)
        {
            other_person.drink_is_spiked = true;
        }
    }

    public float distance_to_seat;
    public float distance_to_OOB;

    public Vector3 OOB_location;
    public Vector3 seat_location;

    public Vector3 new_position;

    public TMPro.TextMeshPro my_text;
    public GameObject text_gameobject;

    public BouncerBell the_bell;

    public float bouncer_wait_time;

    public GameObject my_drink;

    public PredatorAnnouncement announcer;

    public float time_until_drink;

    void OnMouseDown()
    {
        //Debug.Log("Clicked on");
        if (the_bell.is_using_bouncer && can_be_belled)
        {
            //Debug.Log("Sent message to bell");
            the_bell.clicked_on(myself_patron_component);
        }
    }

    // Update is called once per frame
    void Update()
    {

        is_being_watched = Physics.CheckSphere(self.position, 1f, watch_layer);

        pred_indicator.SetActive(am_predator);

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
            if (distance_to_seat < 1f)
            {
                if (!completed_state) 
                { 
                    gameplay_director.drinks_logged += Random.Range(1f, 1.1f); 
                    if (am_predator) {gameplay_director.predators_total += 1;}
                }
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
            can_be_belled = true;
            can_order = !has_drink;
            my_drink.SetActive(has_drink);
        } else
        {
            text_gameobject.SetActive(false);
            can_be_belled = false;
            can_order = false;
            my_drink.SetActive(false);
        }

        if (my_state == 6)
        {
            my_drink.SetActive(has_drink);
        }
        if (my_state == 7)
        {
            my_drink.SetActive(has_drink);
        }

        /*
        if (has_drink)
        {
            time_until_drink += Time.deltaTime;
            {
                if (time_until_drink > 20f)
                {
                    has_drink = false;
                    time_until_drink = Random.Range(-20f, -10f);
                }
            }
        }
        */

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
            if (distance_to_OOB < 4f)
            {
                if (!completed_state && am_predator)
                {
                    gameplay_director.predators_missed += 1;
                    gameplay_director.predators_victim_count += 1;
                    announcer.MakeAnnouncement("A Predator left with their Victim...");
                }
                completed_state = true;
            }

        }

        if (distance_to_seat < 1f)
        {
            Vector3 snapback;
            snapback = self.position;
            snapback.z = 0f;
            self.position = snapback;
        } else
        {
            Vector3 snapback;
            snapback = self.position;
            snapback.z = 1f;
            self.position = snapback;
        }

        // Bouncer Script - If was the unselected

        if (my_state == 6)
        {

        }

        if (my_state == 7)
        {
            bouncer_wait_time += Time.deltaTime;
            if (bouncer_wait_time > 12f)
            {
                my_state = 8;
            }
        }

        if (my_state == 8)
        {
            if (walking_height < original_height)
            {
                walking_height += Time.deltaTime;
            } else
            {
                my_state = 9;
            }

            if (walking_height > original_height)
            {
                walking_height = original_height;
            }

            seat_location.y = walking_height;

            self.position = seat_location;

        }

        if (my_state == 9)
        {
            new_position = Vector3.MoveTowards(self.position, OOB_location, Time.deltaTime * movement_speed);
            self.position = new_position;
            distance_to_OOB = Vector3.Distance(self.position, OOB_location);
            if (distance_to_OOB < 4f)
            {
                if (!completed_state && am_predator)
                {
                    gameplay_director.predators_missed += 1;
                    announcer.MakeAnnouncement("You caught the Victim, Not the Predator.");
                }
                completed_state = true;
            }
        }

        // Bouncer Script - If was selected

        if (my_state == 10)
        {
            
        }

        if (my_state == 11)
        {
            if (walking_height < original_height)
            {
                walking_height += Time.deltaTime;
            } else
            {
                my_state = 12;
            }

            if (walking_height > original_height)
            {
                walking_height = original_height;
            }

            seat_location.y = walking_height;

            self.position = seat_location;
        }

        if (my_state == 12)
        {
            new_position = Vector3.MoveTowards(self.position, OOB_location, Time.deltaTime * movement_speed);
            self.position = new_position;
            distance_to_OOB = Vector3.Distance(self.position, OOB_location);

            if (distance_to_OOB < 4f)
            {
                if (!completed_state && am_predator)
                {
                    gameplay_director.predators_caught += 1;
                    announcer.MakeAnnouncement("You caught a Predator.");
                }
                completed_state = true;
            }
        }

    }
}
