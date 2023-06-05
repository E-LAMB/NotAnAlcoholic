using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour
{

    public Patron pat_1;
    public Patron pat_2;
    public Patron pat_3;
    public Patron pat_4;
    public Patron pat_5;
    public Patron pat_6;

    public PredatorAnnouncement announcer;

    public GameplayDirector the_director;
    bool pressed;
    bool gave_warning;

    public BouncerBell the_bell;

    void OnMouseDown()
    {

        // announcer.MakeAnnouncement("I can't end my shift while a predator is still in the building. I should remove them first.");

        bool predator_present = false;

        if (pat_1.am_predator) { predator_present = true; }
        if (pat_2.am_predator) { predator_present = true; }
        if (pat_3.am_predator) { predator_present = true; }
        if (pat_4.am_predator) { predator_present = true; }
        if (pat_5.am_predator) { predator_present = true; }
        if (pat_6.am_predator) { predator_present = true; }

        if (!the_bell.is_using_bouncer)
        {
            if (!the_bell.bell_ready)
            {
                announcer.MakeAnnouncement("I should wait for the people I've targeted to leave.");

            }else if (!pressed && !predator_present)
            {
                the_director.EndMyShift();

            } else if (!pressed && predator_present && gave_warning)
            {
                the_director.EndMyShift();
            } else if (!pressed && predator_present && !gave_warning)
            {
                gave_warning = true;
                announcer.MakeAnnouncement("I shouldn't end my shift while a predator is still in the bar.");
            }
        }


    }

}
