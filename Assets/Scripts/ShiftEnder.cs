using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShiftEnder : MonoBehaviour
{

    public GameObject other_cameras;
    public GameObject my_camera;
    
    public GameplayDirector the_director;

    float timer;
    public bool counting_time;

    public int time_in_seconds;
    public int time_in_minutes;
    public string time_in_seconds_string;

    public int orders;
    public float total_score;
    public float average_score;

    public int victims_saved;

    public TextMeshPro txt_AverageServingScore;
    public TextMeshPro txt_OverallServingScore;
    public TextMeshPro txt_PredatorCaught;
    public TextMeshPro txt_PredatorVictimsSaved;
    public TextMeshPro txt_TimeTaken;

    public void Activate()
    {

        Debug.Log("Shift Is Over");

        other_cameras.SetActive(false);
        
        counting_time = false;

        average_score = total_score / orders;
        average_score = Mathf.RoundToInt(average_score * 10f);
        average_score = average_score / 10f;

        victims_saved = the_director.predators_total - the_director.predators_victim_count;

        txt_AverageServingScore.text = "Average Serving Score: " + average_score.ToString();
        txt_OverallServingScore.text = "Overall Serving Score: " + total_score.ToString();

        txt_PredatorCaught.text = "Predators Caught: " + the_director.predators_caught.ToString() + "/" + the_director.predators_total.ToString();
        txt_PredatorVictimsSaved.text = "Victims Saved: " + victims_saved.ToString() + "/" + the_director.predators_total.ToString();

        if (time_in_seconds < 10)
        {
            time_in_seconds_string = time_in_seconds.ToString();
            time_in_seconds_string = "0" + time_in_seconds_string;
        } else
        {
            time_in_seconds_string = time_in_seconds.ToString();
        }

        txt_TimeTaken.text = "Time Taken: " + time_in_minutes.ToString() + ":" + time_in_seconds_string;

        my_camera.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counting_time)
        {
            timer += Time.deltaTime;
        }

        if (timer >= 1f)
        {
            time_in_seconds += 1;
            timer -= 1f;
            if (time_in_seconds > 59)
            {
                time_in_seconds = 0;
                time_in_minutes += 1;
            }
        }
    }
}
