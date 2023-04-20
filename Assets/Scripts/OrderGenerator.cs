using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public int current_day;

    public string[] all_drinks;

    public bool generate;

    public int boundary;

    public bool can_serve_angel;

    public bool can_do_addon;

    public OrderIcon[] ordering_icon;

    public TextMeshPro drink_title;
    public TextMeshPro drink_tier;
    public TextMeshPro drink_fluid;

    // Drink Data

    public string selected_addon;
    public string selected_drink;
    public string[] needed_ingredients;
    public string needed_fluid;
    public int needed_shake_level;
    public string drink_name;
    public int seat;

    void Start()
    {
        if (current_day == 1) { boundary = 3; }
        if (current_day == 2) { boundary = 7; }
        if (current_day == 3) { boundary = 12; }
        if (current_day == 4) { boundary = 17; }
        if (current_day == 5) { boundary = 19; }

        clear_note();

        if (current_day > 3) { can_do_addon = true; } else { can_do_addon = false; }
    }

    public void clear_note()
    {
        ordering_icon[0].new_icon("n/a");
        ordering_icon[1].new_icon("n/a");
        ordering_icon[2].new_icon("n/a");
        ordering_icon[3].new_icon("n/a");
        drink_title.text = " ";
        drink_fluid.text = " ";
        drink_tier.text = " ";
    }

    void new_angelshot()
    {

    }

    public void new_order()
    {
        if (can_serve_angel)
        {
            new_angelshot();
            return;
        }

        selected_addon = "n/a";

        selected_drink = all_drinks[Random.Range(0,boundary)];

        // Day One //

        if (selected_drink == "d1_hs")
        {
            drink_name = "Hard Stop";
            needed_fluid = "ALCOHOL";
            needed_shake_level = 1;
            needed_ingredients[0] = "CHERRY";
            needed_ingredients[1] = "ICE";
            needed_ingredients[2] = "n/a";
            needed_ingredients[3] = "n/a";
        }

        if (selected_drink == "d1_rs")
        {
            drink_name = "Rock Solid";
            needed_fluid = "ALCOHOL";
            needed_shake_level = 1;
            needed_ingredients[0] = "ICE";
            needed_ingredients[1] = "ICE";
            needed_ingredients[2] = "ICE";
            needed_ingredients[3] = "n/a";
        }

        if (selected_drink == "d1_tl")
        {
            drink_name = "Traffic Light";
            needed_fluid = "ALCOHOL";
            needed_shake_level = 1;
            needed_ingredients[0] = "CHERRY";
            needed_ingredients[1] = "ORANGE";
            needed_ingredients[2] = "LIME";
            needed_ingredients[3] = "n/a";
        }

        if (selected_drink == "d1_siu")
        {
            drink_name = "Shake It Up";
            needed_fluid = "ALCOHOL";
            needed_shake_level = 3;
            needed_ingredients[0] = "Lime";
            needed_ingredients[1] = "n/a";
            needed_ingredients[2] = "n/a";
            needed_ingredients[3] = "n/a";
        }

        // Day Two //

        if (selected_drink == "d2_qs")
        {
            drink_name = "Quite Sublime";
            needed_fluid = "WATER";
            needed_shake_level = 1;
            needed_ingredients[0] = "LIME";
            needed_ingredients[1] = "n/a";
            needed_ingredients[2] = "n/a";
            needed_ingredients[3] = "n/a";
        }

        if (selected_drink == "d2_jaw")
        {
            drink_name = "Just Add Water";
            needed_fluid = "WATER";
            needed_shake_level = 2;
            needed_ingredients[0] = "ICE";
            needed_ingredients[1] = "n/a";
            needed_ingredients[2] = "n/a";
            needed_ingredients[3] = "n/a";
        }

        if (selected_drink == "d2_mwp")
        {
            drink_name = "More Water Please";
            needed_fluid = "WATER";
            needed_shake_level = 3;
            needed_ingredients[0] = "ICE";
            needed_ingredients[1] = "ICE";
            needed_ingredients[2] = "ICE";
            needed_ingredients[3] = "n/a";
        }

        if (selected_drink == "d2_gt")
        {
            drink_name = "Green Team";
            needed_fluid = "ALCOHOL";
            needed_shake_level = 1;
            needed_ingredients[0] = "MINT";
            needed_ingredients[1] = "LIME";
            needed_ingredients[2] = "OLIVE";
            needed_ingredients[3] = "n/a";
        }

        // Day Three //

        if (selected_drink == "d3_cmr")
        {
            drink_name = "Colour Me Red";
            needed_fluid = "WATER";
            needed_shake_level = 2;
            needed_ingredients[0] = "CHERRY";
            needed_ingredients[1] = "CHERRY";
            needed_ingredients[2] = "n/a";
            needed_ingredients[3] = "n/a";
        }

        if (selected_drink == "d3_do")
        {
            drink_name = "Dirty Olives";
            needed_fluid = "ALCOHOL";
            needed_shake_level = 3;
            needed_ingredients[0] = "ICE";
            needed_ingredients[1] = "OLIVE";
            needed_ingredients[2] = "OLIVE";
            needed_ingredients[3] = "OLIVE";
        }

        if (selected_drink == "d3_dl")
        {
            drink_name = "Dirty Limes";
            needed_fluid = "ALCOHOL";
            needed_shake_level = 3;
            needed_ingredients[0] = "ICE";
            needed_ingredients[1] = "LIME";
            needed_ingredients[2] = "LIME";
            needed_ingredients[3] = "LIME";
        }

        if (selected_drink == "d3_m")
        {
            drink_name = "Minty";
            needed_fluid = "WATER";
            needed_shake_level = 1;
            needed_ingredients[0] = "MINT";
            needed_ingredients[1] = "n/a";
            needed_ingredients[2] = "n/a";
            needed_ingredients[3] = "n/a";
        }

        if (selected_drink == "d3_oyg")
        {
            drink_name = "Orange You Glad";
            needed_fluid = "JUICE";
            needed_shake_level = 1;
            needed_ingredients[0] = "ORANGE";
            needed_ingredients[1] = "ICE";
            needed_ingredients[2] = "ICE";
            needed_ingredients[3] = "n/a";
        }

        // Day Four //

        if (selected_drink == "d4_oitng")
        {
            drink_name = "Orange Is The New Green";
            needed_fluid = "JUICE";
            needed_shake_level = 1;
            needed_ingredients[0] = "ORANGE";
            needed_ingredients[1] = "ORANGE";
            needed_ingredients[2] = "ORANGE";
            needed_ingredients[3] = "n/a";
        }

        if (selected_drink == "d4_cb")
        {
            drink_name = "Cherry Bomb";
            needed_fluid = "ALCOHOL";
            needed_shake_level = 2;
            needed_ingredients[0] = "CHERRY";
            needed_ingredients[1] = "CHERRY";
            needed_ingredients[2] = "CHERRY";
            needed_ingredients[3] = "CHERRY";
        }

        if (selected_drink == "d4_dotf")
        {
            drink_name = "Demise Of The Faithful";
            needed_fluid = "ALCOHOL";
            needed_shake_level = 2;
            needed_ingredients[0] = "ICE";
            needed_ingredients[1] = "n/a";
            needed_ingredients[2] = "n/a";
            needed_ingredients[3] = "n/a";
        }

        if (selected_drink == "d4_cj")
        {
            drink_name = "Cold Juice";
            needed_fluid = "JUICE";
            needed_shake_level = 3;
            needed_ingredients[0] = "ICE";
            needed_ingredients[1] = "ICE";
            needed_ingredients[2] = "n/a";
            needed_ingredients[3] = "n/a";
        }

        if (selected_drink == "d4_mb")
        {
            drink_name = "Mint Breath";
            needed_fluid = "ALCOHOL";
            needed_shake_level = 3;
            needed_ingredients[0] = "CHERRY";
            needed_ingredients[1] = "MINT";
            needed_ingredients[2] = "MINT";
            needed_ingredients[3] = "n/a";
        }

        // Day Five //

        if (selected_drink == "d5_wng")
        {
            drink_name = "Who Needs Green?";
            needed_fluid = "ALCOHOL";
            needed_shake_level = 1;
            needed_ingredients[0] = "CHERRY";
            needed_ingredients[1] = "ORANGE";
            needed_ingredients[2] = "ICE";
            needed_ingredients[3] = "n/a";
        }

        if (selected_drink == "d5_uddup")
        {
            drink_name = "Until Death Does Us Part";
            needed_fluid = "ALCOHOL";
            needed_shake_level = 2;
            needed_ingredients[0] = "LIME";
            needed_ingredients[1] = "LIME";
            needed_ingredients[2] = "LIME";
            needed_ingredients[3] = "LIME";
        }

        if (needed_fluid == "ALCOHOL")
        {
            drink_fluid.text = "ALC.";
        }
        if (needed_fluid == "WATER")
        {
            drink_fluid.text = "WTR.";
        }
        if (needed_fluid == "JUICE")
        {
            drink_fluid.text = "JUC.";
        }

        ordering_icon[0].new_icon(needed_ingredients[0]);
        ordering_icon[1].new_icon(needed_ingredients[1]);
        ordering_icon[2].new_icon(needed_ingredients[2]);
        ordering_icon[3].new_icon(needed_ingredients[3]);

        if (can_do_addon)
        {
            if (Random.Range(1,4) == 1)
            {
                int rand_addon = Random.Range(1, 4);
                bool done_addon = false;

                if (rand_addon == 1)
                {
                    selected_addon = "wei";

                    if (needed_ingredients[1] == "n/a" && !done_addon)
                    {
                        done_addon = true;
                        needed_ingredients[1] = "ICE";
                    }
                    if (needed_ingredients[2] == "n/a" && !done_addon)
                    {
                        done_addon = true;
                        needed_ingredients[2] = "ICE";
                    }
                    if (needed_ingredients[3] == "n/a" && !done_addon)
                    {
                        done_addon = true;
                        needed_ingredients[3] = "ICE";
                    }
                    if (needed_ingredients[4] == "n/a" && !done_addon)
                    {
                        done_addon = true;
                        needed_ingredients[4] = "ICE";
                    }

                    drink_name += " (With Extra Ice)";

                }
                if (rand_addon == 2)
                {
                    selected_addon = "na";

                    if (needed_fluid == "ALCOHOL")
                    {
                        needed_fluid = "WATER";
                        drink_name += " (Non-Alcoholic)";

                    } else
                    {
                        selected_addon = "n/a";
                    }

                }
                if (rand_addon == 3)
                {
                    selected_addon = "wm";

                    if (needed_ingredients[1] == "n/a" && !done_addon)
                    {
                        done_addon = true;
                        needed_ingredients[1] = "MINT";
                    }
                    if (needed_ingredients[2] == "n/a" && !done_addon)
                    {
                        done_addon = true;
                        needed_ingredients[2] = "MINT";
                    }
                    if (needed_ingredients[3] == "n/a" && !done_addon)
                    {
                        done_addon = true;
                        needed_ingredients[3] = "MINT";
                    }
                    if (needed_ingredients[4] == "n/a" && !done_addon)
                    {
                        done_addon = true;
                        needed_ingredients[4] = "MINT";
                    }

                    drink_name += " (With Extra Mint)";

                }

            }
        }

        drink_title.text = drink_name;

        if (needed_shake_level == 1)
        {
            drink_tier.text = "I";
        }
        if (needed_shake_level == 2)
        {
            drink_tier.text = "II";
        }
        if (needed_shake_level == 3)
        {
            drink_tier.text = "III";
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (generate)
        {
            new_order();
            generate = false;
        }
    }
}
