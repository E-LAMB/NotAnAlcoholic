using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatScript : MonoBehaviour
{

    public bool currently_free;
    public int seat_number;

    public bool facing_right;

    public Vector3 Expose_location()
    {
        return gameObject.transform.position;
    }

}
