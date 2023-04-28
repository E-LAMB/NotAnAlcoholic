using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankChooser : MonoBehaviour
{

    public string[] text_to_extract;
    public bool[] bool_to_extract;

    public BankStorage the_target;

    public int current_value = 0;
    public int max_value;

    public string[] assembled_string;
    public bool[] assembled_bool;

    public BankStorage[] innocent_conversations;
    public BankStorage[] pred_a_conversations;
    //public BankStorage[] pred_b_conversations;

    public void RollConversations(bool sp_a_pred, bool pred_present, string debug_runner)
    {

        //Debug.Log(debug_runner);

        if (!pred_present)
        {
            the_target = innocent_conversations[Random.Range(0, innocent_conversations.Length)];
        } else
        {
            if (sp_a_pred)
            {
                the_target = innocent_conversations[Random.Range(0, pred_a_conversations.Length)];
            } else
            {
                the_target = pred_a_conversations[Random.Range(0, pred_a_conversations.Length)];
            }
        }
    }

    public string[] Assemb_string(bool was_first)
    {
       if (was_first)
        {
            current_value = 0;
            //Debug.Log("CB_Assemble_A Occured");
        }

        assembled_string[current_value] = the_target.to_draw_from[current_value].to_say;

        current_value += 1;
       if (current_value >= max_value)
        {
            return assembled_string;
        } else
        {
            Assemb_string(false);
        }
        return null;
    }

    public bool[] Assemb_bool(bool was_first)
    {
        if (was_first)
        {
            current_value = 0;
            //Debug.Log("CB_Assemble_B Occured");
        }

        assembled_bool[current_value] = the_target.to_draw_from[current_value].speaker_a;

        current_value += 1;
        if (current_value >= max_value)
        {
            return assembled_bool;
        }
        else
        {
            Assemb_bool(false);
        }
        return null;
    }

    public string[] extraction_string()
    {
        Assemb_string(true);
        //Debug.Log("CB_Extraction_A Occured");
        return text_to_extract;
    }

    public bool[] extraction_bool()
    {
        Assemb_bool(true);
        //Debug.Log("CB_Extraction_B Occured");
        return bool_to_extract;
    }

}
