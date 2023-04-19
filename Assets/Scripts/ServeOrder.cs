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

    public bool order_was_valid;

    void OnMouseDown()
    {
        if (can_serve)
        {
            can_serve = !can_serve;

            order_was_valid = true;

            if (shaker_dropper.items_in_shaker != the_generator.needed_ingredients)
            {
                order_was_valid = false;
            }
            if (Mind.drink_fluid != the_generator.needed_fluid)
            {
                order_was_valid = false;
            }
            if (Mind.drink_shake_level != the_generator.needed_shake_level)
            {
                order_was_valid = false;
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
