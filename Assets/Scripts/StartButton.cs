using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{

    public GameplayDirector the_director;
    public GameObject self;

    public GameObject others;

    void OnMouseDown()
    {
        the_director.began_shift = true;
        if (others != null) {others.SetActive(false);}
        self.SetActive(false);
    }
}
