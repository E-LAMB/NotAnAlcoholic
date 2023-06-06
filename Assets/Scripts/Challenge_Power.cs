using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge_Power : MonoBehaviour
{

    public GameplayDirector gameplay_director;

    public Transform fuse;
    public GameObject[] fuse_locations;

    public int state;
    // 0 = Fusebox Active
    // 1 = Power is out (fuse uncollected)
    // 2 = Power is out (fuse collected)

    public float fuse_time_left;

    public bool power_on;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0 && gameplay_director.began_shift)
        {
            fuse_time_left -= Time.deltaTime;
            if (0f > fuse_time_left)
            {
                state = 1;
                power_on = false;

                fuse.position = fuse_locations[Random.Range(0, fuse_locations.Length)].transform.position;
            }
        }

        if (state == 2)
        {
            fuse.position = new Vector3 (0f, -20f, 0f);
        }

    }
}
