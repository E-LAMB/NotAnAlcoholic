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

    void OnMouseDown()
    {
        if (!read_note && needs_to_read)
        {
            announcer.MakeAnnouncement("I should read the note my boss left me.");
        } else
        {
            the_director.began_shift = true;
            if (others != null) { others.SetActive(false); }
            self.SetActive(false);
        }
    }
}
