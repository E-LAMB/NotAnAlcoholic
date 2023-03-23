using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidSelectorButton : MonoBehaviour
{

    public FluidController my_master;
    public int type;

    void OnMouseDown()
    {
        if (type == 1)
        {
            my_master.FluidSelected_Alcohol();
        }

        if (type == 2)
        {
            my_master.FluidSelected_Water();
        }

        if (type == 3)
        {
            my_master.FluidSelected_Juice();
        }

        if (type == 4)
        {
            my_master.DispenseFluid();
        }
    }
}
