using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewSceneFade : MonoBehaviour
{

    public Image my_image;
    public TMPro.TextMeshProUGUI text;

    public float my_fade;
    public GameObject my_object;

    public float others;

    public bool is_image;

    // Start is called before the first frame update
    void Start()
    {
        my_fade = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_image)
        {
            my_image.color = new Vector4 (others, others, others, my_fade);
        } else
        {
            text.color = new Vector4 (others, others, others, my_fade);
        }


        my_fade -= Time.deltaTime / 2f;
        if (my_fade < -0.1f)
        {
            my_object.SetActive(false);
        }
    }
}
