using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{

    public int custom_scene;

    public bool moving;
    public float change_time;

    public bool go_custom_scene; 

    public SpriteRenderer darkness;

    void OnMouseDown()
    {
        moving = true;
        darkness.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        change_time = 0f;
        darkness.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            change_time += Time.deltaTime / 2f;
            darkness.color = new Vector4 (0f, 0f, 0f, change_time);
        }

        if (change_time > 1.5f)
        {
            if (go_custom_scene)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(custom_scene);
            } else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
