using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public GameMusic my_gamemusic;

    public bool should_activate_track;
    public int the_track_id;

    void Start()
    {
        my_gamemusic = GameObject.FindGameObjectWithTag("Music Player").GetComponent<GameMusic>();

        if (should_activate_track)
        {
            my_gamemusic.SwitchTrack(the_track_id);
        }
    } 

/*
    public AudioSource my_source;

    public bool direction_moving;

    public float max_audio;

    public float current_volume;

    // Start is called before the first frame update
    void OnMouseDown()
    {
        direction_moving = !direction_moving;
    }

    // Update is called once per frame
    void Update()
    {

        if (direction_moving)
        {
            current_volume += Time.deltaTime / 10f;
        } else
        {
            current_volume -= Time.deltaTime / 10f;
        }

        if (current_volume > max_audio)
        {
            current_volume = max_audio;
        }
        if (current_volume < 0f)
        {
            current_volume = 0f;
        }

        my_source.volume = current_volume;

    }
*/
}
