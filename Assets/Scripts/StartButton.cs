using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{

    public GameplayDirector the_director;
    public GameObject self;

    public GameObject others;

    public PredatorAnnouncement announcer;

    public bool read_note;
    public bool needs_to_read;

    public bool shift_started;

    void OnMouseDown()
    {
        if (!read_note && needs_to_read)
        {
            announcer.MakeAnnouncement("I should read the note that my boss left for me in the back.");
        } else
        {
            shift_started = true;
            the_director.began_shift = true;
            if (others != null) { others.SetActive(false); }
            self.SetActive(false);
        }
    }
}
