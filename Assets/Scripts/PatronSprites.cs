using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronSprites : MonoBehaviour
{

    public GameObject sprite_default;
    public GameObject sprite_sick;
    public GameObject sprite_uncomfortable;
    public GameObject sprite_suspicious;

    public Patron my_owner;

    public string ideal_sprite_name;

    public void SetSprite(string sprite_name)
    {

        ideal_sprite_name = sprite_name;

    }

    void Update()
    {

        if (ideal_sprite_name == "Default") 
        {
            sprite_default.SetActive(true);
            sprite_sick.SetActive(false);
            sprite_uncomfortable.SetActive(false);
            sprite_suspicious.SetActive(false);
        }
        if (ideal_sprite_name == "Uncomfortable") 
        {
            sprite_default.SetActive(false);
            sprite_sick.SetActive(false);
            sprite_uncomfortable.SetActive(true);
            sprite_suspicious.SetActive(false);
        }
        if (ideal_sprite_name == "Suspicious") 
        {
            sprite_default.SetActive(false);
            sprite_sick.SetActive(false);
            sprite_uncomfortable.SetActive(false);
            sprite_suspicious.SetActive(true);
        }

        if (ideal_sprite_name == "Sick" || my_owner.sick_time > 7f) 
        {
            if (my_owner.sick_time > 10f)
            {
                my_owner.sick_time = 0f;
            }
            sprite_default.SetActive(false);
            sprite_sick.SetActive(true);
            sprite_uncomfortable.SetActive(false);
            sprite_suspicious.SetActive(false);
        }
        
    }

}
