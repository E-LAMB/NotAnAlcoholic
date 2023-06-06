using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameplayDirector : MonoBehaviour
{

    [Header("Variables")]

    public int current_day;
    public float spike_impact;

    public int gameplay_loop_drinks;

    public int quota_for_today;
    public int quota_fufilled;
    public int quota_drinks_given;

    public float drinks_logged;

    public bool has_an_order;
    public bool in_endgame;

    public bool dispensed_fluid;

    public bool just_served;

    [Header("Read Only Values")]

    public int customers_at_disposal;

    public Director the_director;
    public FluidController the_fluid_controller;
    public ShakeItUp the_shaker;
    public OrderGenerator the_order_generator;
    public ServeOrder the_server;
    public ShiftEnder the_ender;

    public float time_since_summoned;

    public float order_time;
    public float max_time;

    public int predators_total;
    public int predators_missed;
    public int predators_caught;
    public int predators_victim_count;
    public int predators_victim_saved;

    public GameObject unable_to_order;

    public Image timer;

    public float summoner_time;
    public float order_regression_speed;

    public GameObject end_shift_button;

    public float angel_penalty = 4f;

    public bool began_shift;

    public void EndMyShift()
    {
        gameplay_loop_drinks = 3;
        the_shaker.placing_ingredients = true;
        has_an_order = false;
        just_served = false;
        the_order_generator.clear_note();
    }

    // Update is called once per frame
    void Update()
    {

        current_day = Mind.current_day;

        if (0f > order_time)
        {
            order_time = 0f;
        }

        if (has_an_order)
        {
            if (order_time <= max_time + 0.5f)
            {
                order_time += Time.deltaTime;
            }
        } else
        {
            if (the_order_generator.selected_drink == "ANGEL")
            {
                if (order_time > 0f)
                {
                    order_time -= (Time.deltaTime * order_regression_speed) / angel_penalty;
                }
            } else
            {
                if (order_time > 0f)
                {
                    order_time -= Time.deltaTime * order_regression_speed;
                }
            }
          
        }

        timer.fillAmount = order_time / max_time;

        customers_at_disposal = the_director.patron_free_count;

        time_since_summoned += Time.deltaTime;

        if (time_since_summoned > summoner_time || customers_at_disposal == 6 && time_since_summoned > 5f)
        {
            if (quota_drinks_given < quota_for_today * 1.2 && quota_fufilled <= quota_for_today && began_shift && !in_endgame)
            {
                the_director.should_assign = true;
                time_since_summoned = 0f;
            }
        }

        if (gameplay_loop_drinks == 0)
        {

            if (began_shift && drinks_logged > 1f && !has_an_order && order_time < 0.5f && the_order_generator.has_a_customer)
            {
                gameplay_loop_drinks = 1;
                drinks_logged -= 1f;
                quota_drinks_given += 1;
                has_an_order = true;
                the_fluid_controller.can_dispense = true;
                the_shaker.placing_ingredients = true;
                dispensed_fluid = false;
                the_order_generator.new_order();
            }
        }

        if (gameplay_loop_drinks == 1)
        {
            if (dispensed_fluid)
            {
                gameplay_loop_drinks = 2;
                the_shaker.placing_ingredients = false;
                the_shaker.times_shaken = 0;
                the_shaker.shaker_position = "md";
                the_server.can_serve = true;
                dispensed_fluid = false;
            }
        }

        if (gameplay_loop_drinks == 2)
        {
            if (just_served)
                {
                    gameplay_loop_drinks = 0;
                    the_shaker.placing_ingredients = true;
                    has_an_order = false;
                    just_served = false;
                    quota_fufilled += 1;
                    the_order_generator.clear_note();
                    // Debug.Log("Served");
                }
        }

        if (in_endgame)
        {
            end_shift_button.SetActive(true);
        }

        if (!in_endgame && quota_fufilled >= quota_for_today)
        {
            in_endgame = true;
        }

        if (gameplay_loop_drinks == 3)
        {

            the_order_generator.clear_note();
            
            the_ender.Activate();

        }

    }
}
