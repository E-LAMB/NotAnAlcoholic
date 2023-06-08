using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeBombController : MonoBehaviour
{

    public GameMusic my_music;

    public int bombs;

    public float time_until_detonation;

    // Start is called before the first frame update
    void Start()
    {
        my_music = GameObject.FindGameObjectWithTag("Music Player").GetComponent<GameMusic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bombs > 0)
        {
            time_until_detonation -= Time.deltaTime;
        } else
        {
            time_until_detonation += Time.deltaTime / 10f;
        }

        if (time_until_detonation > 7f)
        {
            time_until_detonation = 7f;
        }

        if (time_until_detonation < 0f)
        {
            Debug.Log("BOOM");
            my_music.Detonate();
            UnityEngine.SceneManagement.SceneManager.LoadScene(13);
        }
    }
}
