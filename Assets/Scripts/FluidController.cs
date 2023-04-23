using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidController : MonoBehaviour
{

    public bool alcohol_selected;
    public bool water_selected;
    public bool juice_selected;

    public bool alcohol_active;
    public bool water_active;
    public bool juice_active;

    public bool can_dispense;

    public float time_to_fluid;
    public bool has_just_dispensed;

    public ParticleSystem particle_alcohol;
    public ParticleSystem particle_water;
    public ParticleSystem particle_juice;

    public GameplayDirector the_director;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FluidSelected_Alcohol()
    {
        if (alcohol_active)
        {
            alcohol_selected = true;
            water_selected = false;
            juice_selected = false;
        }
    }
    public void FluidSelected_Water()
    {
        if (water_active)
        {
            alcohol_selected = false;
            water_selected = true;
            juice_selected = false;
        }
    }
    public void FluidSelected_Juice()
    {
        if (juice_active)
        {
            alcohol_selected = false;
            water_selected = false;
            juice_selected = true;
        }
    }

    public void DispenseFluid()
    {
        if (can_dispense)
        {
            can_dispense = false;

            if (alcohol_selected) { particle_alcohol.Play(); }
            if (water_selected) { particle_water.Play(); }
            if (juice_selected) { particle_juice.Play(); }

            if (alcohol_selected) { Mind.drink_fluid = "ALCOHOL"; }
            if (water_selected) { Mind.drink_fluid = "WATER"; }
            if (juice_selected) { Mind.drink_fluid = "JUICE"; }

            time_to_fluid = 9f;
            has_just_dispensed = true;
            // the_director.dispensed_fluid = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time_to_fluid -= Time.deltaTime;

        if (0f > time_to_fluid && has_just_dispensed)
        {
            has_just_dispensed = false;
            the_director.dispensed_fluid = true;
        }
    }
}
