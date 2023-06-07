using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge_Power : MonoBehaviour
{

    public GameplayDirector gameplay_director;

    public Transform fuse;
    public GameObject[] fuse_locations;

    public AudioSource sound;

    public int state;
    // 0 = Fusebox Active
    // 1 = Power is out (fuse uncollected)
    // 2 = Power is out (fuse collected)

    public float fuse_time_left;

    public bool power_on;

    public bool fuse_inserted;
    public bool fuse_collected;

    public GameObject box_active;
    public GameObject box_inactive;

    public FluidController fluider;

    public GameObject selected_location;

    // Start is called before the first frame update
    void Start()
    {
        fuse.position = new Vector3 (0f, 20f, 0f);

        fuse_time_left = Random.Range(25f, 30f);

        fuse_inserted = true;
        fuse_collected = true;
        power_on = true;
    }

    // Update is called once per frame
    void Update()
    {

        fluider.alcohol_active = power_on;
        fluider.water_active = power_on;
        fluider.juice_active = power_on;

        box_active.SetActive(power_on);
        box_inactive.SetActive(!power_on);

        if (state == 0)
        {
            if (gameplay_director.began_shift)
            {
                state = 1;
            }
        }

        if (state == 1)
        {
            fuse_time_left -= Time.deltaTime;
            if (0f > fuse_time_left)
            {
                state = 2;
                power_on = false;

                fuse_inserted = false;
                fuse_collected = false;

                sound.Play();

                selected_location = fuse_locations[Random.Range(0, fuse_locations.Length)];
                selected_location = fuse_locations[Random.Range(0, fuse_locations.Length)];
            }
        }

        if (state == 2)
        {
            fuse.position = selected_location.transform.position;
            fuse.localRotation = selected_location.transform.localRotation;

            if (fuse_collected)
            {
                fuse.position = new Vector3 (0f, 20f, 0f);
                fuse_inserted = false;
                state = 3;
            }
        }

        if (state == 3)
        {
            if (fuse_inserted)
            {
                power_on = true;
                fuse_time_left = Random.Range(15f, 60f);
                state = 1;
            }
        }

    }
}
