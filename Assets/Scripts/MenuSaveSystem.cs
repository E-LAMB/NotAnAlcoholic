using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuSaveSystem : MonoBehaviour
{

    public string content = "NEVER_RAN_SO_YOURE_NEW"; // The text that should be written in the save file

    public float icon_time = 3f; // How long to show the save icon for
    public GameObject icon; // The icon to show

    public int player_location;

    void Start()
    {
        Mind.save_path = Application.persistentDataPath + "/dairyofthealcoholicfurries.txt";

        if (!File.Exists(Mind.save_path)) 
        {
            File.Create(Mind.save_path); 
        } else 
        { 
            Debug.Log("Exists!"); 
        }

        StreamReader reader = new StreamReader(Mind.save_path);
        string content;
        content = reader.ReadToEnd(); // Reads the content in the file
        reader.Close();
        Debug.Log(content);

        // Different Values based on player's progress

        // Funny reference to this video ---> https://www.youtube.com/watch?v=WIpRkhcz3lQ

        // Else the location is at 0

        // "NotFurry" - Completed Day 1
        // "SemiFurry" - Completed Day 2
        // "FURRY" - Completed Day 3
        // "DangerouslyFurry" - Completed Day 4
        // "WAYDYSF" - Completed Day 5

        player_location = 0;

        if (content == "NotFurry")
        {
            player_location = 1;
        }
        if (content == "SemiFurry")
        {
            player_location = 2;
        }
        if (content == "FURRY")
        {
            player_location = 3;
        }
        if (content == "DangerouslyFurry")
        {
            player_location = 4;
        }
        if (content == "WAYDYSF")
        {
            player_location = 5;
        }
    }

    void Update()
    {
        if (!Mind.ran_startup)
        {
            Mind.ran_startup = true;
        }
    }
}
