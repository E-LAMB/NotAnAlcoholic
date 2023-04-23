using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankStorage : MonoBehaviour
{

    [TextArea(5,30)]
    public string notes;

    [TextArea(1,15)]
    public string command_list;

    public DiaData[] to_draw_from;

    /*

    These indicate the start and end of a conversation



    $StartOfConvo
    $EndOfConvo



    These indicate when a character should change emotions - And what to

    $Emote/Default    

    Changes the sprite to the default sprite. 


    $Emote/Sick     

    Changes the sprite to the sick sprite.
    This usually occurs when someone has been spiked.

    (This can occur rarely in conversation - But very rarely.)


    $Emote/Suspicious   

    Changes the sprite to the suspicious sprite.
    This usually occurs when The Predator is about to perform a Spiker Action,
    The Predator always exhibits the suspicious sprite in this case.

    (This can occur rarely in conversation - But very rarely.)


    $Emote/Uncomfortable      

    Changes the sprite to the uncomfortable sprite.
    This usually occurs when someone feels uncomfortable in conversation, 
    Usually as a result of The Predator performing an Abuser Action.


    $Spike/Prepare
    $Spike/Perform

    $Abuse/RedText


    */

}
