using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarButton : MonoBehaviour
{

    public Transform button;
    public Transform bound;
    public Transform ideal_location;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        button.position = ideal_location.position;
        if (button.position.x > bound.position.x)
        {
            button.position = bound.position;
        }

    }
}
