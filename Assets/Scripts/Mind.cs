using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Mind 
{

    public static bool filling_shaker = false;

    public static float speaking_speed = 5f;

    public static int making_stage = 0;

    // 0: Shift started
    // 1: Recieved order, Placing ingredients
    // 2: Shaking drink
    // 3: Serve drink

    public static string drink_fluid = "n/a";
    public static string[] drink_ingredients;
    public static int drink_shake_level = 1;

    public static float ingredient_gap_time = 1f;
    public static float ice_melting_time = 11f;

    public static bool currently_in_back;
    public static bool in_control;

}
