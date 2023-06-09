using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAccess : MonoBehaviour
{

    public int current_stage;
    public float last_interaction;

    // O V E R T I M E

    public int new_scene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        last_interaction += Time.deltaTime;

        if (last_interaction > 3f)
        {
            last_interaction = 0f;
            current_stage = 0;
        }

        if (current_stage == 0 && Input.GetKeyDown(KeyCode.O)) {current_stage += 1; last_interaction = 0f;}
        if (current_stage == 1 && Input.GetKeyUp(KeyCode.O))   {current_stage += 1; last_interaction = 0f;}

        if (current_stage == 2 && Input.GetKeyDown(KeyCode.V)) {current_stage += 1; last_interaction = 0f;}
        if (current_stage == 3 && Input.GetKeyUp(KeyCode.V))   {current_stage += 1; last_interaction = 0f;}

        if (current_stage == 4 && Input.GetKeyDown(KeyCode.E)) {current_stage += 1; last_interaction = 0f;}
        if (current_stage == 5 && Input.GetKeyUp(KeyCode.E))   {current_stage += 1; last_interaction = 0f;}

        if (current_stage == 6 && Input.GetKeyDown(KeyCode.R)) {current_stage += 1; last_interaction = 0f;}
        if (current_stage == 7 && Input.GetKeyUp(KeyCode.R))   {current_stage += 1; last_interaction = 0f;}

        if (current_stage == 8 && Input.GetKeyDown(KeyCode.T)) {current_stage += 1; last_interaction = 0f;}
        if (current_stage == 9 && Input.GetKeyUp(KeyCode.T))   {current_stage += 1; last_interaction = 0f;}

        if (current_stage == 10 && Input.GetKeyDown(KeyCode.I)) {current_stage += 1; last_interaction = 0f;}
        if (current_stage == 11 && Input.GetKeyUp(KeyCode.I))   {current_stage += 1; last_interaction = 0f;}

        if (current_stage == 12 && Input.GetKeyDown(KeyCode.M)) {current_stage += 1; last_interaction = 0f;}
        if (current_stage == 13 && Input.GetKeyUp(KeyCode.M))   {current_stage += 1; last_interaction = 0f;}

        if (current_stage == 14 && Input.GetKeyDown(KeyCode.E)) {current_stage += 1; last_interaction = 0f;}
        if (current_stage == 15 && Input.GetKeyUp(KeyCode.E))   {current_stage += 1; last_interaction = 0f;}

        if (current_stage == 16) {UnityEngine.SceneManagement.SceneManager.LoadScene(new_scene);}
    }
}
