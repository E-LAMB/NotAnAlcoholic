using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{

    public GameObject main_menu;

    public GameObject old_player_menu;
    public GameObject new_player_menu;

    public float darkness_setting = 1f;
    public int new_scene;

    public bool going_to_scene;
    public bool scene_change;

    public Image no_ui_menu;
    public MenuSaveSystem save_sys;

    public bool exiting_game;

    public RawImage continue_button;
    public Texture continue_texture;
    public Texture challenge_texture;

    public void TakeToSceneWithFade(int chosen)
    {
        going_to_scene = true;
        scene_change = true;
        new_scene = chosen;
        darkness_setting = 1.3f;
        DisableTheMenu();
    }

    public void TakeToSceneFileControlled()
    {
        going_to_scene = true;
        scene_change = true;

        darkness_setting = 1.3f;

        if (save_sys.player_location == 0) { new_scene = 3; }
        if (save_sys.player_location == 1) { new_scene = 4; }
        if (save_sys.player_location == 2) { new_scene = 5; }
        if (save_sys.player_location == 3) { new_scene = 6; }
        if (save_sys.player_location == 4) { new_scene = 7; }
        if (save_sys.player_location == 5) { new_scene = 2; darkness_setting = 1.1f; }

        DisableTheMenu();
    }

    public void TakeToSceneReset()
    {
        going_to_scene = true;
        scene_change = true;

        save_sys.SaveData("WelcomeToTheFurmaly");
        save_sys.player_location = 0;

        if (save_sys.player_location == 0) { new_scene = 1; }

        darkness_setting = 1.3f;
        DisableTheMenu();
    }

    public void ExitApplicationWithFade()
    {
        going_to_scene = false;
        exiting_game = true;
        scene_change = true;
        darkness_setting = 1.3f;
        DisableTheMenu();
    }

    void DisableTheMenu()
    {
        main_menu.SetActive(false);

        old_player_menu.SetActive(false);
        new_player_menu.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (save_sys.player_location == 5)
        {
            continue_button.texture = challenge_texture;
        } else
        {
            continue_button.texture = continue_texture;
        }

        if (!going_to_scene && save_sys.player_location == 0)
        {
            old_player_menu.SetActive(false);
            new_player_menu.SetActive(true);

        } else if (!going_to_scene)
        {
            old_player_menu.SetActive(true);
            new_player_menu.SetActive(false);

        } else
        {
            old_player_menu.SetActive(false);
            new_player_menu.SetActive(false);
        }

        if (exiting_game)
        {
            old_player_menu.SetActive(false);
            new_player_menu.SetActive(false);
        }

        if (scene_change)
        {
            darkness_setting -= Time.deltaTime / 2f;

            no_ui_menu.color = new Vector4 (1f,1f,1f,darkness_setting);

            if (darkness_setting < -0f)
            {
                if (going_to_scene)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(new_scene);
                } else
                {
                    Application.Quit();
                }
            }
        }
    }
}
