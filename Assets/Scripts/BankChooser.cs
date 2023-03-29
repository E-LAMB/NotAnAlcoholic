using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankChooser : MonoBehaviour
{

    public string[] text_to_extract;
    public bool[] bool_to_extract;

    public BankStorage the_target;

    public string[] extraction_string()
    {
        return text_to_extract;
    }

    public bool[] extraction_bool()
    {
        return bool_to_extract;
    }

}
