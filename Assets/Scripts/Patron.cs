using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Patron : MonoBehaviour
{

    public bool timebomb_logic;
    public GameObject timebomb;
    public GameObject bomb_spawn_spot;

    public bool currently_free;

    public bool assigned_to_conversation;

    public bool am_predator;
    public bool pred_present;

    public bool can_be_belled;

    public AudioSource spiker_sound;

    public GameplayDirector gameplay_director;

    public GameObject pred_indicator;
    public GameObject spike_indicator;

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
    public bool spiking_stage;
    public bool is_a_spiker;

    public bool is_being_watched;
    public LayerMask watch_layer;

    public float bouncer_waiting_time = 10f;

    public string my_name;

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

    public SpriteRenderer drink_fluid;
    public Vector4 drink_color;
    public SpriteRenderer drink_glass;
    public bool drink_spike_change;

    public PatronSprites my_sprite_manager;
    public ConversationController my_conversation_controller;

    public Transform drink_collective;
    public Transform drink_offscreen;
    public Transform drink_onscreen;

    public bool icon_gun_logic;

    public void Activate()
    {
        served_angel_shot = false;

        sprite_collection[0].SetActive(false);
        sprite_collection[1].SetActive(false);
        sprite_collection[2].SetActive(false);
        sprite_collection[3].SetActive(false);
        sprite_collection[4].SetActive(false);

        drink_color = new Vector4(1f, 1f, 1f, 1f);

        sprite_collection[sprite_chosen].SetActive(true);

        my_sprite_manager = sprite_collection[sprite_chosen].GetComponent<PatronSprites>();
        my_sprite_manager.SetSprite("Default");

        my_name = sprite_collection[sprite_chosen].GetComponent<NameBank>().GiveMeMyName();

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
        drink_spike_change = false;
        can_order = false;
        spiking_stage = false;

        time_until_drink = Random.Range(-10f, 0f);

        sick_time = 0f;

        drink_fluid.enabled = true;
        drink_glass.enabled = true;

        drink_collective.position = drink_onscreen.position;

    }

    public void DrinkServed(string type)
    {

        drink_color = new Vector4(0f, 0f, 0f, 1f);

        if (type == "ALCOHOL")
        {
            drink_color = new Vector4(0.95f, 0.9f, 0.65f, 0.8f);
        }
        if (type == "WATER")
        {
            drink_color = new Vector4(0.5f, 0.8f, 1f, 0.4f);
        }
        if (type == "JUICE")
        {
            drink_color = new Vector4(0.9f, 0.5f, 0f, 1f);
        }

        drink_fluid.color = drink_color;

        has_drink = true;
        drink_glass.enabled = true;

        drink_fluid.color = drink_color;

    }

    public void AngelDrinkServed()
    {
        served_angel_shot = true;

        drink_color = new Vector4(0f, 0f, 0f, 0f);

        drink_fluid.color = drink_color;

        has_drink = true;

        drink_fluid.color = drink_color;
        drink_glass.enabled = false;

    }

    public void Speaking(string to_say, float time_to_say)
    {

        text_fade_time = time_to_say - 0.125f;
        my_text.text = to_say;
        text_colour.w = 1f;

    }

    public void ExecuteCommand(string command)
    {

        /*
        if (command.Contains("$Spike") && !spiking_stage && !other_person.drink_is_spiked && other_person.has_drink) 
        {
            my_sprite_manager.SetSprite("Suspicious");
            Debug.Log("Spike Prepare");
            spiking_stage = true;
            
        } else if (command.Contains("$Spike") && spiking_stage  && !other_person.is_being_watched && other_person.has_drink && !is_being_watched && !other_person.drink_is_spiked)
        {
            other_person.drink_is_spiked = true;
            spiking_stage = false;
            Debug.Log("Spike Set");
            my_sprite_manager.SetSprite("Default");

        } else if (is_being_watched && spiking_stage && other_person.has_drink && !other_person.drink_is_spiked)
        {
            my_sprite_manager.SetSprite("Uncomfortable");
            Debug.Log("Spike Interrupt");
            spiking_stage = false;

        } else if (other_person.is_being_watched && spiking_stage && other_person.has_drink && !other_person.drink_is_spiked)
        {
            my_sprite_manager.SetSprite("Uncomfortable");
            Debug.Log("Spike Interrupt");
            spiking_stage = false;
        }
        */

        if (command.Contains("$Emote/Default")) {my_sprite_manager.SetSprite("Default");}
        if (command.Contains("$Emote/Sick")) {my_sprite_manager.SetSprite("Sick");}
        if (command.Contains("$Emote/Suspicious")) {my_sprite_manager.SetSprite("Suspicious");}
        if (command.Contains("$Emote/Uncomfortable")) {my_sprite_manager.SetSprite("Uncomfortable");}

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

    public float spiker_time;
    public float spiker_stare_time;

    public int spiker_chance;

    public float sick_time;
    public float spike_change;

    public bool served_angel_shot;

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
        if (served_angel_shot)
        {
            drink_fluid.enabled = false;
            drink_glass.enabled = false;
        }

        if (drink_is_spiked && !drink_spike_change)
        {
            drink_spike_change = true;
            drink_color = drink_fluid.color;
            drink_color = new Vector4 (drink_color.x - (gameplay_director.spike_impact / 2f), drink_color.y + (gameplay_director.spike_impact), drink_color.z - (gameplay_director.spike_impact / 2f), drink_color.w);
            drink_glass.enabled = true;
            drink_fluid.color = drink_color;
        }

        if (is_a_spiker && my_state == 3 && other_person.has_drink)
        {
            spiker_time += Time.deltaTime;

            if (spiker_time > 2.5f)
            {
                spiker_time = 0f;

                if (Random.Range(1,100) < spiker_chance && !is_being_watched && other_person.has_drink && !other_person.is_being_watched && !other_person.drink_is_spiked)
                {

                    if (!spiking_stage)
                    {
                        spiking_stage = true;
                        my_sprite_manager.SetSprite("Suspicious");
                        spiker_time = -5f;
                        // Debug.Log("Spike Prepared");
                        spiker_chance += 5;

                    } else
                    {
                        other_person.drink_is_spiked = true;
                        spiking_stage = false;
                        spiker_sound.Play();
                        // Debug.Log("Spike Set");

                        if (timebomb_logic)
                        {
                            Instantiate(timebomb, other_person.bomb_spawn_spot.transform);
                        }

                        my_sprite_manager.SetSprite("Default");
                    }

                } else
                {
                    spiker_chance += 2;
                    // Debug.Log("Failed");
                }
            }

        }

        if (spiking_stage)
        {
            if (is_being_watched)
            {
                spiker_stare_time += Time.deltaTime;
                if (spiker_stare_time > 3f)
                {
                    my_sprite_manager.SetSprite("Uncomfortable");
                    Debug.Log("Spike Interrupt Ext.");
                    spiking_stage = false;
                }
            } else
            {
                spiker_stare_time = 0f;
            }
        }

        if (drink_is_spiked)
        {
            sick_time += Time.deltaTime;
        }

        is_being_watched = Physics.CheckSphere(self.position, 1f, watch_layer);

        if (icon_gun_logic)
        {
            if (my_state == 3 || my_state == 6 || my_state == 7 || my_state == 10)
            {
                pred_indicator.SetActive(am_predator);
                if (am_predator)
                {
                    my_sprite_manager.SetSprite("Suspicious");
                }

            } else
            {
                pred_indicator.SetActive(false);
            }
        } else
        {
            pred_indicator.SetActive(am_predator);
        }
        
        spike_indicator.SetActive(drink_is_spiked);

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
            if (distance_to_seat < 0.5f)
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
            drink_glass.enabled = has_drink;
        } else
        {
            text_gameobject.SetActive(false);
            can_be_belled = false;       
            my_drink.SetActive(false);
            drink_glass.enabled = false;
        }

        if (my_state == 6)
        {
            my_drink.SetActive(has_drink);
            drink_glass.enabled = has_drink;
        }
        if (my_state == 7)
        {
            my_drink.SetActive(has_drink);
            drink_glass.enabled = has_drink;
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
                    if (is_a_spiker)
                    {
                        gameplay_director.predators_missed += 1;
                        if (other_person.drink_is_spiked)
                        {
                            gameplay_director.predators_victim_count += 1;
                            announcer.MakeAnnouncement("A Predator left with their Spiked Victim...");
                        } else
                        {
                            gameplay_director.predators_victim_saved += 1;
                            announcer.MakeAnnouncement("A Predator left without Spiking their Victim...");
                        }

                    } else
                    {
                        gameplay_director.predators_missed += 1;
                        gameplay_director.predators_victim_count += 1;
                        announcer.MakeAnnouncement("A Predator left with their Victim...");
                    }
                    pred_present = false;
                    am_predator = false;
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
            if (bouncer_wait_time > bouncer_waiting_time)
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
                    gameplay_director.predators_victim_count += 1;
                    announcer.MakeAnnouncement("You caught the Victim, Not the Predator.");
                }
                pred_present = false;
                am_predator = false;
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
                    gameplay_director.predators_victim_saved += 1;
                    announcer.MakeAnnouncement("You caught a Predator.");
                }
                pred_present = false;
                am_predator = false;
                completed_state = true;
            }
        }

    }
}
