using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeOrder : MonoBehaviour
{

    public bool can_serve;

    public GameplayDirector the_gameplay_director;
    public Identifier_Shaker shaker_dropper;
    public OrderGenerator the_generator;
    public ShakeItUp shaker_shake;

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
            can_serve = !can_serve;
            points_value = 0f;

            if (CompareIngredients())
            {
                points_value += 15f;
            }

            if (shaker_dropper.items_in_shaker != the_generator.needed_ingredients)
            {
                points_value += 10f;
            }

            if (Mind.drink_fluid != the_generator.needed_fluid)
            {
                points_value += 10f;
            }

            if (Mind.drink_shake_level != the_generator.needed_shake_level)
            {
                points_value += 15f;
            }

            if ((the_gameplay_director.order_time / the_gameplay_director.max_time) <= 0.5f)
            {
                points_value += 30f;
                Debug.Log("Timer = +30");

            } else if ((the_gameplay_director.order_time / the_gameplay_director.max_time) <= 0.75f)
            {
                points_value += 20f;
                Debug.Log("Timer = +20");

            } else if ((the_gameplay_director.order_time / the_gameplay_director.max_time) <= 1f)
            {
                points_value += 10f;
                Debug.Log("Timer = +10");

            } else if (the_gameplay_director.order_time > the_gameplay_director.max_time)
            {
                points_value = 0f;
                Debug.Log("Timer SET TO NONE");

            } else
            {
                points_value += 0;
                Debug.Log("Timer = +0");
            }

            shaker_dropper.item_number = 0;
            shaker_dropper.items_in_shaker[0] = "n/a";
            shaker_dropper.items_in_shaker[1] = "n/a";
            shaker_dropper.items_in_shaker[2] = "n/a";
            shaker_dropper.items_in_shaker[3] = "n/a";
            shaker_dropper.items_in_shaker[4] = "n/a";
            Mind.drink_shake_level = 0;

            the_gameplay_director.just_served = true;
        }
    }
}
