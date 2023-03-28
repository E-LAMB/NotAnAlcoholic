using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{

    public int type_of_button;
    // 1 = To Bar
    // 2 = To Back

    void OnMouseDown()
    {

        if (type_of_button == 1)
        {
            Mind.currently_in_back = false;
        }

        if (type_of_button == 2)
        {
            Mind.currently_in_back = true;
        }

    }

}
