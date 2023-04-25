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

    public void RollConversations(bool sp_a_pred, bool pred_present)
    {
        if (!pred_present)
        {
            the_target = innocent_conversations[Random.Range(0, innocent_conversations.Length)];
        } else
        {
            if (sp_a_pred)
            {
                the_target = pred_a_conversations[Random.Range(0, pred_a_conversations.Length)];
            } else
            {
                //the_target = pred_b_conversations[Random.Range(0, pred_b_conversations.Length)];
            }
        }
    }

    public string[] Assemb_string(bool was_first)
    {
       if (was_first)
        {
            current_value = 0;
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
        return text_to_extract;
    }

    public bool[] extraction_bool()
    {
        Assemb_bool(true);
        return bool_to_extract;
    }

}
