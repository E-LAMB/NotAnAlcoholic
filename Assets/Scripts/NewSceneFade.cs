using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewSceneFade : MonoBehaviour
{

    public Image my_image;
    public float my_fade;
    public GameObject my_object;

    // Start is called before the first frame update
    void Start()
    {
        my_fade = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        my_image.color = new Vector4 (0f, 0f, 0f, my_fade);
        my_fade -= Time.deltaTime / 2f;
        if (my_fade < -0.1f)
        {
            my_object.SetActive(false);
        }
    }
}
