using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScreen : MonoBehaviour
{
    // made at 1.36am... forgive my sloppy-ness

    public float my_color;
    public RawImage my_image;
    public float my_time;
    public AnimationCurve my_curve;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        my_time += Time.deltaTime;
        my_color = my_curve.Evaluate(my_time);
        my_color = 1f - my_color;
        my_image.color = new Vector4 (0f, 0f, 0f, my_color);

        if (my_time > 10f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
