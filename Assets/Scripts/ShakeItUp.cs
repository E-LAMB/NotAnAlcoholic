using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeItUp : MonoBehaviour
{

    public bool placing_ingredients = true;

    public Transform stage;
    public Transform shaker_open;
    public Transform shaker_shake;
    public Transform OOB_storage;

    public int shake_level;
    public float total_shaken;
    public AnimationCurve shake_amount;

    public bool shake_direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mind.filling_shaker = placing_ingredients;

        if (placing_ingredients)
        {
            shaker_open.position = stage.position;
            shaker_shake.position = OOB_storage.position;
        } else
        {
            shaker_open.position = OOB_storage.position;
            shaker_shake.position = stage.position;
        }

        if (!placing_ingredients)
        {
            if (shake_direction && Input.GetKeyDown(KeyCode.W))
            {
                shake_direction = !shake_direction;
                total_shaken += 1f;
            }
            if (!shake_direction && Input.GetKeyDown(KeyCode.S))
            {
                shake_direction = !shake_direction;
                total_shaken += 1f;
            }
        }

    }
}
