using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{

    public int next_level;
    public bool moving;
    public float change_time;

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
            UnityEngine.SceneManagement.SceneManager.LoadScene(next_level);
        }
    }
}
