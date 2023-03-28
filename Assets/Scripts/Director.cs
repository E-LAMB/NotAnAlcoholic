using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{

    public bool should_assign;

    public int pairing_one;
    public int pairing_two;

    public bool patron_1_free;
    public bool patron_2_free;
    public bool patron_3_free;
    public bool patron_4_free;
    public bool patron_5_free;
    public bool patron_6_free;

    public GameObject patron_1;
    public GameObject patron_2;
    public GameObject patron_3;
    public GameObject patron_4;
    public GameObject patron_5;
    public GameObject patron_6;

    public Patron patronscript_1;
    public Patron patronscript_2;
    public Patron patronscript_3;
    public Patron patronscript_4;
    public Patron patronscript_5;
    public Patron patronscript_6;

    public GameObject seat_1;
    public GameObject seat_2;
    public GameObject seat_3;
    public GameObject seat_4;
    public GameObject seat_5;
    public GameObject seat_6;

    // Start is called before the first frame update
    void Start()
    {

    }

    /* */
     
    public void roll_patrons(bool first, bool cp_1, bool cp_2, bool cp_3, bool cp_4, bool cp_5, bool cp_6)
    {
        int selected_pairing = 0;
        bool should_retry = false;

        if (first)
        {
            pairing_one = Random.Range(1, 7);
            selected_pairing = pairing_one;
        } else
        {
            pairing_two = Random.Range(1, 7);
            selected_pairing = pairing_two;
        }

        Debug.Log(selected_pairing);
        
        if (selected_pairing == 1 && !cp_1) { should_retry = true; }
        if (selected_pairing == 2 && !cp_2) { should_retry = true; }
        if (selected_pairing == 3 && !cp_3) { should_retry = true; }
        if (selected_pairing == 4 && !cp_4) { should_retry = true; }
        if (selected_pairing == 5 && !cp_5) { should_retry = true; }
        if (selected_pairing == 6 && !cp_6) { should_retry = true; }

        if (should_retry) { roll_patrons(first, cp_1, cp_2, cp_3, cp_4, cp_5, cp_6); }

    }

    // Update is called once per frame
    void Update()
    {

        patron_1_free = patronscript_1.currently_free;
        patron_2_free = patronscript_2.currently_free;
        patron_3_free = patronscript_3.currently_free;
        patron_4_free = patronscript_4.currently_free;
        patron_5_free = patronscript_5.currently_free;
        patron_6_free = patronscript_6.currently_free;

        if (should_assign)
        {
            should_assign = false;
            Debug.Log("Runs");
            roll_patrons(true, patron_1_free, patron_2_free, patron_3_free, patron_4_free, patron_5_free, patron_6_free);
            roll_patrons(false, patron_1_free, patron_2_free, patron_3_free, patron_4_free, patron_5_free, patron_6_free);
        }
    }
    
     /* */

}
