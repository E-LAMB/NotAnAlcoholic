using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{

    public AudioClip[] all_tracks;
    // 0 = Silence
    // 1 = Menu
    // 2 = Levels

    public AudioSource my_source;

    public int current_track;

    public float my_volume;
    public float max_volume;

    public bool volume_increasing;

    void Start()
    {
        SwitchTrack(0);
    }

    public void SwitchTrack(int new_track)
    {
        if (new_track == 0)
        {
            my_source.Stop();

        } else if (new_track != current_track)
        {
            my_source.Stop();
            my_source.clip = all_tracks[new_track];
            current_track = new_track;
            my_source.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (volume_increasing)
        {
            my_volume += Time.deltaTime / 10f;
        } else
        {
            my_volume -= Time.deltaTime / 10f;
        }

        if (my_volume > max_volume)
        {
            my_volume = max_volume;
        }
        if (my_volume < 0f)
        {
            my_volume = 0f;
        }

        my_source.volume = my_volume;
    }
}
