using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameplayDirector : MonoBehaviour
{

    [Header("Variables")]

    public int current_day;

    public int gameplay_loop_drinks;

    public int quota_for_today;
    public int quota_fufilled;
    public int quota_drinks_given;

    public float drinks_logged;

    public bool has_an_order;

    public bool dispensed_fluid;

    public bool just_served;

    [Header("Read Only Values")]

    public int customers_at_disposal;

    public Director the_director;
    public FluidController the_fluid_controller;
    public ShakeItUp the_shaker;
    public OrderGenerator the_order_generator;
    public ServeOrder the_server;

    public float time_since_summoned;

    public float order_time;
    public float max_time;

    public Image timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (has_an_order)
        {
            if (order_time <= max_time + 0.5f)
            {
                order_time += Time.deltaTime;
            }
        } else
        {
            if (order_time > 0f)
            {
                order_time -= Time.deltaTime * 10f;
            }
        }

        timer.fillAmount = order_time / max_time;

        customers_at_disposal = the_director.patron_free_count;

        time_since_summoned += Time.deltaTime;

        if (time_since_summoned > 30f || customers_at_disposal == 6 && time_since_summoned > 5f)
        {
            if (quota_drinks_given != quota_for_today)
            {
                the_director.should_assign = true;
                time_since_summoned = 0f;
            }
        }

        if (gameplay_loop_drinks == 0)
        {
            if (drinks_logged > 1f && !has_an_order && quota_fufilled < quota_for_today && order_time < 0.5f)
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
                the_order_generator.clear_note();
            }
        }
    }
}
