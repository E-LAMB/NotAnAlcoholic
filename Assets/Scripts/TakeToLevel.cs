using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeToLevel : MonoBehaviour
{

    public float timer;
    public float time_to_wait;

    public int scene_to_take;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (time_to_wait < timer)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene_to_take);
        }
    }
}
