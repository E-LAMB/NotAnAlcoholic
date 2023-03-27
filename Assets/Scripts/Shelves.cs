using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelves : MonoBehaviour
{

    public GameObject my_spawn;
    public float spawn_cooldown;
    public Vector3 offset;

    void Update()
    {
        if (spawn_cooldown > -1f)
        {
            spawn_cooldown -= Time.deltaTime;
        }
    }
    void OnMouseDown()
    {
        if (spawn_cooldown <= 0f)
        {
            spawn_cooldown = Mind.ingredient_gap_time;
            Instantiate(my_spawn, gameObject.transform.position + offset, gameObject.transform.localRotation);
        }
    }
}
