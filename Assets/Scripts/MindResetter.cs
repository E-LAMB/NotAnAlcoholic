using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindResetter : MonoBehaviour
{

    public float speaking_speed;
    public int current_day;
    public float ice_melting_time;

    public string[] temp_string;

    void Start()
    {

        Mind.filling_shaker = false;
        Mind.speaking_speed = speaking_speed;

        Mind.making_stage = 0;

        Mind.current_day = current_day;

        Mind.has_an_order = false;

        Mind.drink_fluid = "n/a";

        Mind.drink_ingredients = temp_string;

        Mind.drink_shake_level = 0;
        Mind.ingredient_gap_time = 0.2f;
        Mind.ice_melting_time = ice_melting_time;
        Mind.currently_in_back = false;
        Mind.in_control = true;

    }
}
