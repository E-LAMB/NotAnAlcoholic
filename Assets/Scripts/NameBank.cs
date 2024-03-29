using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameBank : MonoBehaviour
{

    public bool editing_the_bank;

    public bool should_access_males;

    public static string[] male_names;
    public static string[] female_names;

    public string[] male_setup;
    public string[] female_setup;

    // Start is called before the first frame update
    void Awake()
    {
        if (editing_the_bank)
        {
            male_names = male_setup;
            female_names = female_setup;
        } else
        {
            male_setup = male_names;
            female_setup = female_names;
        }
    }

    public string GiveMeMyName()
    {

        if (should_access_males) 
        { 
            return male_names[Random.Range(0, male_names.Length)]; 

        } else 
        { 
            return female_names[Random.Range(0, female_names.Length)]; 
        }

    }
}
