using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DevButton : MonoBehaviour
{

    public string current_scene;
    public TMP_InputField mine;

    public GameObject belowme;
    public Image me;
    public bool see_me;

    public bool is_editing;

    public void ChangeValue()
    {
        current_scene = mine.text;
    }

    public void EditState(bool new_state)
    {
        is_editing = new_state;
    }

    void SuccessRan()
    {
        see_me = false;
        me.enabled = see_me;
        belowme.SetActive(see_me);
        is_editing = false;
    }

    public void AttemptRun()
    {
        if (see_me)
        {
            if (current_scene == "To/Day1") { UnityEngine.SceneManagement.SceneManager.LoadScene(3); SuccessRan(); }
            if (current_scene == "To/Day2") { UnityEngine.SceneManagement.SceneManager.LoadScene(4); SuccessRan(); }
            if (current_scene == "To/Day3") { UnityEngine.SceneManagement.SceneManager.LoadScene(5); SuccessRan(); }
            if (current_scene == "To/Day4") { UnityEngine.SceneManagement.SceneManager.LoadScene(6); SuccessRan(); }
            if (current_scene == "To/Day5") { UnityEngine.SceneManagement.SceneManager.LoadScene(7); SuccessRan(); }
            if (current_scene == "To/Day6") { UnityEngine.SceneManagement.SceneManager.LoadScene(8); SuccessRan(); }
            if (current_scene == "To/Ending") { UnityEngine.SceneManagement.SceneManager.LoadScene(9); SuccessRan(); }
            if (current_scene == "To/Challenge") { UnityEngine.SceneManagement.SceneManager.LoadScene(2); SuccessRan(); }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        see_me = false;
        me.enabled = see_me;
        belowme.SetActive(see_me);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash) && !is_editing)
        {
            see_me = !see_me;
            me.enabled = see_me;
            belowme.SetActive(see_me);
        }
    }
}
