using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShakeItUp : MonoBehaviour
{

    public bool placing_ingredients = true;

    public Transform stage;
    public Transform shaker_open;
    public Transform shaker_shake;
    public Transform OOB_storage;

    public KeyCode key_shake_up;
    public KeyCode key_shake_down;

    public int shake_level;
    public float total_shaken;
    public AnimationCurve shake_curve;
    public float shake_amount;

    public int times_until_flip;
    public int times_shaken;

    public GameObject shake_by;

    public bool shake_direction;

    public bool switched;

    public GameObject image_W;
    public GameObject image_S;
    public GameObject image_A;
    public GameObject image_D;
    public GameObject image_outline_up;
    public GameObject image_outline_down;

    public Transform shaker_prompt_inbounds;
    public Transform shaker_prompt;

    public string shaker_position = "md";
    // md - Middle
    // up - Up
    // dn - Down
    // lt - Left
    // rt - Right
    public bool shaker_standing_upwards = true;

    public Transform shaker_mover_rotator;
    public Transform shaker_mover_positioner;

    public float turning_angle;
    float r;

    public Transform shaker_mover_origin;

    public TextMeshPro intensity_text;

    public Vector3 shaker_mover_upwards;
    public Vector3 shaker_mover_downwards;
    public Vector3 shaker_mover_leftwards;
    public Vector3 shaker_mover_rightwards;

    public float move_amount;
    public float shake_base_speed;
    public float shake_speed;

    // Start is called before the first frame update
    void Start()
    {
        shaker_mover_upwards = shaker_mover_origin.position;
        shaker_mover_upwards.y += move_amount;
        shaker_mover_rightwards = shaker_mover_origin.position;
        shaker_mover_rightwards.x += move_amount;
        shaker_mover_downwards = shaker_mover_origin.position;
        shaker_mover_downwards.y -= move_amount;
        shaker_mover_leftwards = shaker_mover_origin.position;
        shaker_mover_leftwards.x -= move_amount;

        shake_speed = shake_base_speed;
    }

    public void ResetShaker()
    {

    }

    void SetShakeKeys(int chance, bool should_invert)
    {
        image_W.SetActive(false);
        image_A.SetActive(false);
        image_S.SetActive(false);
        image_D.SetActive(false);
        shaker_position = "md";

        if (should_invert)
        {
            if (!shaker_standing_upwards)
            {
                key_shake_up = KeyCode.W;
                key_shake_down = KeyCode.S;
                image_W.SetActive(true);
                image_S.SetActive(true);
                shaker_standing_upwards = true;
            } else
            {
                key_shake_up = KeyCode.A;
                key_shake_down = KeyCode.D;
                image_A.SetActive(true);
                image_D.SetActive(true);
                shaker_standing_upwards = false;
            }
        } else
        {
            if (Random.Range(1,chance) == 1)
            {
                key_shake_up = KeyCode.W;
                key_shake_down = KeyCode.S;
                image_W.SetActive(true);
                image_S.SetActive(true);
                shaker_standing_upwards = true;
            } else
            {
                key_shake_up = KeyCode.A;
                key_shake_down = KeyCode.D;
                image_A.SetActive(true);
                image_D.SetActive(true);
                shaker_standing_upwards = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        shake_by.SetActive(!placing_ingredients);

        if (Mind.drink_shake_level == 0) { intensity_text.text = "X"; }
        if (Mind.drink_shake_level == 1) { intensity_text.text = "I"; }
        if (Mind.drink_shake_level == 2) { intensity_text.text = "II"; }
        if (Mind.drink_shake_level == 3) { intensity_text.text = "III"; }
        if (Mind.drink_shake_level > 3) { intensity_text.text = "X"; }

        Mind.filling_shaker = placing_ingredients;

        if (placing_ingredients)
        {
            shaker_mover_positioner.position = Vector3.MoveTowards(shaker_mover_positioner.position, OOB_storage.position, shake_speed * Time.deltaTime);

        } else if (shaker_position == "md")
        {
            shaker_mover_positioner.position = Vector3.MoveTowards(shaker_mover_positioner.position, shaker_mover_origin.position, shake_speed * Time.deltaTime);

        } else if (shaker_position == "up")
        {
            shaker_mover_positioner.position = Vector3.MoveTowards(shaker_mover_positioner.position, shaker_mover_upwards, shake_speed * Time.deltaTime);

        } else if (shaker_position == "dn")
        {
            shaker_mover_positioner.position = Vector3.MoveTowards(shaker_mover_positioner.position, shaker_mover_downwards, shake_speed * Time.deltaTime);

        } else if (shaker_position == "lt")
        {
            shaker_mover_positioner.position = Vector3.MoveTowards(shaker_mover_positioner.position, shaker_mover_leftwards, shake_speed * Time.deltaTime);

        } else if (shaker_position == "rt")
        {
            shaker_mover_positioner.position = Vector3.MoveTowards(shaker_mover_positioner.position, shaker_mover_rightwards, shake_speed * Time.deltaTime);

        } else
        {
            shaker_position = "md";
        }

        float new_angle = Mathf.SmoothDampAngle(shaker_mover_rotator.eulerAngles.z, turning_angle, ref r, 0.1f);

        if (shaker_standing_upwards)
        {

            shaker_mover_rotator.localRotation = Quaternion.Euler(0,0,new_angle);
            turning_angle = 0f;

        } else
        {

            shaker_mover_rotator.localRotation = Quaternion.Euler(0,0,new_angle);
            turning_angle = 90f;

        }

        if (placing_ingredients)
        {
            shaker_open.position = stage.position;
            shaker_shake.position = OOB_storage.position;
            shaker_prompt.position = OOB_storage.position;
        } else
        {
            shaker_open.position = OOB_storage.position;
            shaker_shake.position = stage.position;
            shaker_prompt.position = shaker_prompt_inbounds.position;
        }

        if (!placing_ingredients)
        {
            if (!switched)
            {
                switched = true;
                SetShakeKeys(1, false);
                times_shaken = 0;
                shake_direction = true;
                image_outline_up.SetActive(true);
                image_outline_down.SetActive(false);
                shaker_position = "md";
                times_until_flip = 9;
            }

            if (shake_amount > 0)
            {
                shake_amount -= Time.deltaTime - (Time.deltaTime * (shake_amount / 10f));
            }

            if (shake_amount > 5f)
            {
                shake_amount = 5f;
            }

            if (times_shaken > times_until_flip)
            {
                SetShakeKeys(3, true);
                times_shaken = 0;
                times_until_flip = Random.Range(8,10) + Mind.drink_shake_level + Mind.current_day;
                times_until_flip = times_until_flip * 2;
                times_until_flip -= 1;
                Mind.drink_shake_level += 1;
            }

            shake_speed = shake_base_speed + shake_amount;

            if (shake_direction && Input.GetKeyDown(key_shake_up))
            {
                shake_direction = !shake_direction;
                shake_amount += 0.5f;
                total_shaken += shake_amount;
                times_shaken += 1;
                image_outline_up.SetActive(false);
                image_outline_down.SetActive(true);
                if (shaker_standing_upwards) {shaker_position = "up";} else {shaker_position = "lt";}
            }
            if (!shake_direction && Input.GetKeyDown(key_shake_down))
            {
                shake_direction = !shake_direction;
                shake_amount += 0.5f;
                total_shaken += shake_amount;
                times_shaken += 1;
                image_outline_up.SetActive(true);
                image_outline_down.SetActive(false);
                if (shaker_standing_upwards) {shaker_position = "dn";} else {shaker_position = "rt";}
            }
        }

    }
}
