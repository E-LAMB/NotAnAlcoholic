using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{

    public GameObject main_menu;
    public GameObject button_1;
    public GameObject button_2;

    public float darkness_setting = 1f;
    public int new_scene;

    public bool going_to_scene;
    public bool scene_change;

    public Image no_ui_menu;

    public void TakeToSceneWithFade(int chosen)
    {
        going_to_scene = true;
        scene_change = true;
        new_scene = chosen;
        darkness_setting = 1.3f;
        DisableTheMenu();
    }

    public void ExitApplicationWithFade()
    {
        going_to_scene = false;
        scene_change = true;
        darkness_setting = 1.3f;
        DisableTheMenu();
    }

    void DisableTheMenu()
    {
        main_menu.SetActive(false);
        button_1.SetActive(false);
        button_2.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scene_change)
        {
            darkness_setting -= Time.deltaTime / 2f;

            no_ui_menu.color = new Vector4 (1f,1f,1f,darkness_setting);

            if (darkness_setting < -1f)
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
