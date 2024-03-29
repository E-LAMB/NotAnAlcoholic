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
    // 4: Shift over

    public static int current_day;

    public static bool has_an_order;

    public static string drink_fluid = "n/a";
    public static string[] drink_ingredients;
    public static int drink_shake_level = 0;

    public static float ingredient_gap_time = 0.2f;
    public static float ice_melting_time = 12f;

    public static bool currently_in_back;
    public static bool in_control;

    public static string save_path;
    public static bool ran_startup;

}
