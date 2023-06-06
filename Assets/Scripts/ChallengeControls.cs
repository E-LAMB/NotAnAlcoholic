using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeControls : MonoBehaviour
{

    public GameObject main_menu;
    public float darkness_setting = 1f;
    public int new_scene;
    public bool going_to_scene;
    public bool scene_change;
    public Image background;

    public void TakeToSceneWithFade(int chosen)
    {
        going_to_scene = true;
        scene_change = true;
        new_scene = chosen;
        darkness_setting = 1.1f;
        DisableTheMenu();
    }

    void DisableTheMenu()
    {
        main_menu.SetActive(false);
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

            background.color = new Vector4 (1f,1f,1f,darkness_setting);

            if (darkness_setting < -0.05f)
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

