using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{

    public bool should_assign;

    public int pairing_one;
    public int pairing_two;

    public int pairing_attempts;
    public int max_attempts;

    public int patron_free_count;

    public bool patron_1_free;
    public bool patron_2_free;
    public bool patron_3_free;
    public bool patron_4_free;
    public bool patron_5_free;
    public bool patron_6_free;

    public GameObject patron_1;
    public GameObject patron_2;
    public GameObject patron_3;
    public GameObject patron_4;
    public GameObject patron_5;
    public GameObject patron_6;

    public Patron patronscript_1;
    public Patron patronscript_2;
    public Patron patronscript_3;
    public Patron patronscript_4;
    public Patron patronscript_5;
    public Patron patronscript_6;

    public int conversator_free_count;
    public bool conversation_1_free;
    public bool conversation_2_free;
    public bool conversation_3_free;

    public ConversationController conversator_1;
    public ConversationController conversator_2;
    public ConversationController conversator_3;

    public int selected_conversator;

    public GameObject selected_1_patronobject;
    public GameObject selected_2_patronobject;
    public Patron selected_1_patronscript;
    public Patron selected_2_patronscript;

    public ConversationController selected_controller;

    public bool can_predators_appear;
    public float predator_chance;
    public float initial_predator_chance;
    public bool is_predator;
    public bool predator_is_a;
    public float predator_chance_reduction;

    // Start is called before the first frame update
    void Start()
    {
        predator_chance = initial_predator_chance;
    }
     
    public void roll_patrons(bool first, bool cp_1, bool cp_2, bool cp_3, bool cp_4, bool cp_5, bool cp_6)
    {
        int selected_pairing = 0;
        bool should_retry = false;
        pairing_attempts += 1;
        bool is_first_ran = false;
        if (pairing_attempts == 1)
        {
            is_first_ran = true;
        }

        if (first)
        {
            pairing_one = Random.Range(1, 7);
            selected_pairing = pairing_one;
        } else
        {
            pairing_two = Random.Range(1, 7);
            selected_pairing = pairing_two;
        }

        Debug.Log(selected_pairing);
        
        if (selected_pairing == 1 && !cp_1) { should_retry = true; }
        if (selected_pairing == 2 && !cp_2) { should_retry = true; }
        if (selected_pairing == 3 && !cp_3) { should_retry = true; }
        if (selected_pairing == 4 && !cp_4) { should_retry = true; }
        if (selected_pairing == 5 && !cp_5) { should_retry = true; }
        if (selected_pairing == 6 && !cp_6) { should_retry = true; }

        if (selected_pairing == pairing_one && first) { should_retry = true; }

        if (is_first_ran)
        {
            is_first_ran = true;
        }

        if (should_retry && pairing_attempts != max_attempts) 
        {
            roll_patrons(first, cp_1, cp_2, cp_3, cp_4, cp_5, cp_6); 
        } 
        //if (pairing_attempts == max_attempts && is_first_ran) {Debug.Log("Denied");}
        selected_pairing += 0;
    }

    public void roll_conversators(bool cp_1, bool cp_2, bool cp_3)
    {

        bool should_retry = false;
        pairing_attempts += 1;
        bool is_first_ran = false;
        if (pairing_attempts == 1)
        {
            is_first_ran = true;
        }

        selected_conversator = Random.Range(1,4);

        Debug.Log(selected_conversator);
        
        if (selected_conversator == 1 && !cp_1) { should_retry = true; }
        if (selected_conversator == 2 && !cp_2) { should_retry = true; }
        if (selected_conversator == 3 && !cp_3) { should_retry = true; }

        if (is_first_ran)
        {
            is_first_ran = true;
        }

        if (should_retry && pairing_attempts != max_attempts) 
        {
            roll_conversators(cp_1, cp_2, cp_3); 
        } 
        //if (pairing_attempts == max_attempts && is_first_ran) {Debug.Log("Denied");}

    }

    // Update is called once per frame
    void Update()
    {
        if (!can_predators_appear)
        {
            predator_chance = 200;
        }

        patron_1_free = patronscript_1.currently_free;
        patron_2_free = patronscript_2.currently_free;
        patron_3_free = patronscript_3.currently_free;
        patron_4_free = patronscript_4.currently_free;
        patron_5_free = patronscript_5.currently_free;
        patron_6_free = patronscript_6.currently_free;

        conversation_1_free = conversator_1.currently_free;
        conversation_2_free = conversator_2.currently_free;
        conversation_3_free = conversator_3.currently_free;

        patron_free_count = 0;
        conversator_free_count = 0;

        if (patron_1_free) {patron_free_count += 1;}
        if (patron_2_free) {patron_free_count += 1;}
        if (patron_3_free) {patron_free_count += 1;}
        if (patron_4_free) {patron_free_count += 1;}
        if (patron_5_free) {patron_free_count += 1;}
        if (patron_6_free) {patron_free_count += 1;}

        if (conversation_1_free) {conversator_free_count += 1;}
        if (conversation_2_free) {conversator_free_count += 1;}
        if (conversation_3_free) {conversator_free_count += 1;}

        if (should_assign && patron_free_count >= 2 && conversator_free_count >= 1)
        {

            if (Random.Range(1f, 100f) > predator_chance)
            {
                is_predator = true;
                predator_chance = initial_predator_chance;
            }
            else
            {
                is_predator = false;
                predator_chance -= predator_chance_reduction;
            }

            predator_is_a = true;

            should_assign = false;

            pairing_one = 0;
            if (patron_1_free && pairing_one == 0) {pairing_one = 1;}
            if (patron_2_free && pairing_one == 0) {pairing_one = 2;}
            if (patron_3_free && pairing_one == 0) {pairing_one = 3;}
            if (patron_4_free && pairing_one == 0) {pairing_one = 4;}
            if (patron_5_free && pairing_one == 0) {pairing_one = 5;}
            if (patron_6_free && pairing_one == 0) {pairing_one = 6;}

            pairing_two = 0;
            if (patron_1_free && pairing_two == 0 && pairing_one != 1) {pairing_two = 1;}
            if (patron_2_free && pairing_two == 0 && pairing_one != 2) {pairing_two = 2;}
            if (patron_3_free && pairing_two == 0 && pairing_one != 3) {pairing_two = 3;}
            if (patron_4_free && pairing_two == 0 && pairing_one != 4) {pairing_two = 4;}
            if (patron_5_free && pairing_two == 0 && pairing_one != 5) {pairing_two = 5;}
            if (patron_6_free && pairing_two == 0 && pairing_one != 6) {pairing_two = 6;}

            /*
            pairing_attempts = 0;
            roll_patrons(true, patron_1_free, patron_2_free, patron_3_free, patron_4_free, patron_5_free, patron_6_free);
            pairing_attempts = 0;
            roll_patrons(false, patron_1_free, patron_2_free, patron_3_free, patron_4_free, patron_5_free, patron_6_free);
            */

            pairing_attempts = 0;
            roll_conversators(conversation_1_free, conversation_2_free, conversation_3_free);

            if (pairing_one == 1) {selected_1_patronobject = patron_1;}
            if (pairing_one == 2) {selected_1_patronobject = patron_2;}
            if (pairing_one == 3) {selected_1_patronobject = patron_3;}
            if (pairing_one == 4) {selected_1_patronobject = patron_4;}
            if (pairing_one == 5) {selected_1_patronobject = patron_5;}
            if (pairing_one == 6) {selected_1_patronobject = patron_6;}

            if (pairing_two == 1) {selected_2_patronobject = patron_1;}
            if (pairing_two == 2) {selected_2_patronobject = patron_2;}
            if (pairing_two == 3) {selected_2_patronobject = patron_3;}
            if (pairing_two == 4) {selected_2_patronobject = patron_4;}
            if (pairing_two == 5) {selected_2_patronobject = patron_5;}
            if (pairing_two == 6) {selected_2_patronobject = patron_6;}

            if (selected_conversator == 1) {selected_controller = conversator_1;}
            if (selected_conversator == 2) {selected_controller = conversator_2;}
            if (selected_conversator == 3) {selected_controller = conversator_3;}

            selected_1_patronscript = selected_1_patronobject.GetComponent<Patron>();
            selected_2_patronscript = selected_2_patronobject.GetComponent<Patron>();

            selected_controller.commanding_1 = selected_1_patronscript;
            selected_controller.commanding_2 = selected_2_patronscript;

            selected_controller.predator_is_a = predator_is_a;
            selected_controller.predator_present = is_predator;
            selected_controller.Activate();

            Debug.Log("Activation Occured From Director");

        }
    }
    
}
