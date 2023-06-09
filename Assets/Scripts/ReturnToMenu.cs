using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnToMenu : MonoBehaviour
{

    //public bool can_return;
    //public bool should_enable_movement;

    //bool final_return;

    public float loading;

    public float hold_timer;
    float time_needed = 4.5f;
    float time_to_fill = 4f;

    float fraction;

    public Image my_image;
    public int target_scene = 1;

    // Start is called before the first frame update
    void Start()
    {
        //if (should_enable_movement)
        //{
        //    Mind.player_in_control = true;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        /*
        final_return = can_return;
        if (!Mind.player_in_control)
        {
            final_return = false;
        }
        */

        if (4f > loading)
        {
            loading += Time.deltaTime;
        }

        fraction = hold_timer / time_to_fill;
        my_image.fillAmount = fraction; 

        if (hold_timer > time_needed)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(target_scene);
        }

        if(Input.GetKey(KeyCode.Escape) && loading > 3f)
        {
            hold_timer += Time.deltaTime;
        } else
        {
            if (hold_timer >= 0f)
            {
                hold_timer -= Time.deltaTime * 2f;
            }
            if (0 > hold_timer)
            {
                hold_timer = 0f;
            }
        }
    }
}
