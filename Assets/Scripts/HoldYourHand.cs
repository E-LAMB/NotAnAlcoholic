using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldYourHand : MonoBehaviour
{

    public GameObject[] guide;

    public bool shift_started;


    public int state;

    // 0 = Shift Not Started

    // 1 = Shift Started - Adding Ingredients
    // 2 = Shift Started - Waiting for Fluid
    // 3 = Shift Started - Shaking Drinks

    public FluidController fluid_controller;
    public StartButton start_my_shift;
    public GameplayDirector gameplayDirector;

    // Start is called before the first frame update
    void Start()
    {
        guide[0].SetActive(true);
        guide[1].SetActive(false);
        guide[2].SetActive(false);
        guide[3].SetActive(false);
        guide[4].SetActive(false);
        guide[5].SetActive(false);
        guide[6].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (shift_started)
        {

            if (state == 0)
            {
                guide[0].SetActive(false);
                state = 4;
            }

            if (state == 4 && gameplayDirector.has_an_order)
            {
                state = 1;
                guide[1].SetActive(true);
                guide[2].SetActive(true);
            }

            if (state == 5)
            {
                guide[6].SetActive(true);
            }

            if (state == 1 && fluid_controller.time_to_fluid > 5f)
            {
                guide[1].SetActive(false);
                guide[2].SetActive(false);
                state = 2;
                guide[5].SetActive(true);
            }

            if (state == 2 && fluid_controller.time_to_fluid < 0.1f)
            {
                guide[5].SetActive(false);
                state = 3;
                guide[3].SetActive(true);
                guide[4].SetActive(true);
            }

            if (state == 3 && gameplayDirector.order_time < 1f)
            {
                if (gameplayDirector.quota_fufilled >= gameplayDirector.quota_for_today)
                {
                    guide[3].SetActive(false);
                    guide[4].SetActive(false);
                    state = 5;
                    guide[6].SetActive(true);
                } else
                {
                    guide[3].SetActive(false);
                    guide[4].SetActive(false);
                    state = 1;
                    guide[1].SetActive(true);
                    guide[2].SetActive(true);
                }
            }
        }

        if (start_my_shift.shift_started && !shift_started)
        {
            shift_started = true;
        }

        if (!shift_started)
        {
            state = 0;
        } 

    }
}
