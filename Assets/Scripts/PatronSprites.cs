using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronSprites : MonoBehaviour
{

    public GameObject sprite_default;
    public GameObject sprite_sick;
    public GameObject sprite_uncomfortable;
    public GameObject sprite_suspicious;

    public void SetSprite(string sprite_name)
    {
        sprite_default.SetActive(false);
        sprite_sick.SetActive(false);
        sprite_uncomfortable.SetActive(false);
        sprite_suspicious.SetActive(false);

        if (sprite_name == "Default") {sprite_default.SetActive(true);}
        if (sprite_name == "Sick") {sprite_sick.SetActive(true);}
        if (sprite_name == "Uncomfortable") {sprite_uncomfortable.SetActive(true);}
        if (sprite_name == "Suspicious") {sprite_suspicious.SetActive(true);}
    }

}
