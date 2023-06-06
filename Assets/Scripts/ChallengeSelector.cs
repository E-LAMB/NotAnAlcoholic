using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeSelector : MonoBehaviour
{

    public ChallengeControls my_controller;
    public int my_code;

    public Color active;
    public Color inactive;

    public RawImage self;

    public void SelectChallenge()
    {
        my_controller.SelectScene(my_code);
    }

    // Update is called once per frame
    void Update()
    {
        if (my_code == my_controller.new_scene)
        {
            self.color = active;
        } else
        {
            self.color = inactive;
        }
    }
}
