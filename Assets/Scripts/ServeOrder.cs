using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ServeOrder : MonoBehaviour
{

    public bool can_serve;

    public float overall_score;

    public GameplayDirector the_gameplay_director;
    public Identifier_Shaker shaker_dropper;
    public OrderGenerator the_generator;
    public ShakeItUp shaker_shake;

    public TextMeshPro overall_text;
    public TextMeshPro recent_text;
    public float recent_text_trans;

    public float points_value;
    // Max of 80

    int needed_ing_ora;
    int needed_ing_lim;
    int needed_ing_min;
    int needed_ing_oli;
    int needed_ing_ice;
    int needed_ing_che;

    bool order_valid;

    int gotten_ing_ora;
    int gotten_ing_lim;
    int gotten_ing_min;
    int gotten_ing_oli;
    int gotten_ing_ice;
    int gotten_ing_che;

    void Start()
    {
        recent_text.text = points_value.ToString() + " POINTS!";
        overall_text.text = "SCORE: " + overall_score.ToString();
    }
    void Update()
    {
        if (recent_text_trans >= 0f)
        {
            recent_text_trans -= Time.deltaTime / 5f;
        }

        recent_text.color = new Vector4(1f, 1f, 1f, recent_text_trans);
    }

    bool CompareIngredients()
    {

        needed_ing_ora = 0;
        needed_ing_lim = 0;
        needed_ing_min = 0;
        needed_ing_oli = 0;
        needed_ing_ice = 0;
        needed_ing_che = 0;

        order_valid = false;

        gotten_ing_ora = 0;
        gotten_ing_lim = 0;
        gotten_ing_min = 0;
        gotten_ing_oli = 0;
        gotten_ing_ice = 0;
        gotten_ing_che = 0;

        SusOutIngredient(true, 0,the_generator.needed_ingredients);
        SusOutIngredient(true, 1,the_generator.needed_ingredients);
        SusOutIngredient(true, 2,the_generator.needed_ingredients);
        SusOutIngredient(true, 3,the_generator.needed_ingredients);
        SusOutIngredient(true, 4,the_generator.needed_ingredients);

        SusOutIngredient(false, 0,shaker_dropper.items_in_shaker);
        SusOutIngredient(false, 1,shaker_dropper.items_in_shaker);
        SusOutIngredient(false, 2,shaker_dropper.items_in_shaker);
        SusOutIngredient(false, 3,shaker_dropper.items_in_shaker);
        SusOutIngredient(false, 4,shaker_dropper.items_in_shaker);

        order_valid = true;

        if (gotten_ing_ora != needed_ing_ora) {order_valid = false;}
        if (gotten_ing_min != needed_ing_min) {order_valid = false;}
        if (gotten_ing_ice != needed_ing_ice) {order_valid = false;}
        if (gotten_ing_oli != needed_ing_oli) {order_valid = false;}
        if (gotten_ing_che != needed_ing_che) {order_valid = false;}
        if (gotten_ing_lim != needed_ing_lim) {order_valid = false;}

        //Debug.Log("is it valid");
        //Debug.Log(order_valid);

        return order_valid;

    }

    void SusOutIngredient(bool is_needed, int current_looking, string[] array_looking)
    {

        if (is_needed)
        {

            if (array_looking[current_looking] == "ORANGE") {needed_ing_ora += 1;}
            if (array_looking[current_looking] == "LIME") {needed_ing_lim += 1;}
            if (array_looking[current_looking] == "MINT") {needed_ing_min += 1;}
            if (array_looking[current_looking] == "CHERRY") {needed_ing_che += 1;}
            if (array_looking[current_looking] == "OLIVE") {needed_ing_oli += 1;}
            if (array_looking[current_looking] == "ICE") {needed_ing_ice += 1;}

        } else
        {

            if (array_looking[current_looking] == "ORANGE") {gotten_ing_ora += 1;}
            if (array_looking[current_looking] == "LIME") {gotten_ing_lim += 1;}
            if (array_looking[current_looking] == "MINT") {gotten_ing_min += 1;}
            if (array_looking[current_looking] == "CHERRY") {gotten_ing_che += 1;}
            if (array_looking[current_looking] == "OLIVE") {gotten_ing_oli += 1;}
            if (array_looking[current_looking] == "ICE") {gotten_ing_ice += 1;}

        }

    }

    void OnMouseDown()
    {

        if (can_serve)
        {
            points_value = 0f;

            /*
            if (shaker_dropper.items_in_shaker == the_generator.needed_ingredients)
            {
                points_value += 10f;
                Debug.Log("Right order");
            }
            */

            if (CompareIngredients())
            {
                points_value += 20f;
                //Debug.Log("Right ingredients");
            }

            if (Mind.drink_fluid == the_generator.needed_fluid)
            {
                points_value += 20f;
                //Debug.Log("Right fluid");
            }

            if (Mind.drink_shake_level == the_generator.needed_shake_level)
            {
                points_value += 20f;
                //Debug.Log("Right shake");
            }

            if ((the_gameplay_director.order_time / the_gameplay_director.max_time) <= 0.5f)
            {
                points_value += 40f;
                //Debug.Log("Timer = +30");

            } else if ((the_gameplay_director.order_time / the_gameplay_director.max_time) <= 0.75f)
            {
                points_value += 30f;
                //Debug.Log("Timer = +20");

            } else if ((the_gameplay_director.order_time / the_gameplay_director.max_time) <= 1f)
            {
                points_value += 20f;
                //Debug.Log("Timer = +10");

            } else if (the_gameplay_director.order_time > the_gameplay_director.max_time)
            {
                points_value = 0f;
                //Debug.Log("Timer SET TO NONE");

            } else
            {
                points_value += 0;
                //Debug.Log("Timer = +0");
            }

            recent_text_trans = 1.5f;
            overall_score += points_value;

            recent_text.text = points_value.ToString() + " POINTS!";
            overall_text.text = "SCORE: " + overall_score.ToString();

            recent_text.color = new Vector4(1f, 1f, 1f, recent_text_trans);

            shaker_dropper.item_number = 0;
            shaker_dropper.items_in_shaker[0] = "n/a";
            shaker_dropper.items_in_shaker[1] = "n/a";
            shaker_dropper.items_in_shaker[2] = "n/a";
            shaker_dropper.items_in_shaker[3] = "n/a";
            shaker_dropper.items_in_shaker[4] = "n/a";
            Mind.drink_shake_level = 0;

            if (the_generator.selected_patron_seat.can_order) 
            {
                the_generator.selected_patron_seat.DrinkServed(Mind.drink_fluid);
            }

            the_gameplay_director.just_served = true;
            can_serve = !can_serve;
        }
    }
}
