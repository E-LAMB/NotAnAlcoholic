using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScreen : MonoBehaviour
{
    public float my_time;

    public float darkness_color;
    public RawImage darkness_renderer;

    public float overtime_color;
    public Text overtime_renderer;

    public float challenge_color;
    public Text challenge_renderer;

    public AnimationCurve darkness_curve;
    public AnimationCurve overtime_curve;
    public AnimationCurve challenge_curve;

    public AnimationCurve lynx_position;
    public Transform lynx_transform;
    public Vector3 lynx_offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        my_time += Time.deltaTime;

        darkness_color = darkness_curve.Evaluate(my_time);
        darkness_renderer.color = new Vector4 (0f, 0f, 0f, darkness_color);

        overtime_color = overtime_curve.Evaluate(my_time);
        overtime_renderer.color = new Vector4 (0.89f, 0.75f, 0.2f, overtime_color);

        challenge_color = challenge_curve.Evaluate(my_time);
        challenge_renderer.color = new Vector4 (0.89f, 0.75f, 0.2f, challenge_color);

        lynx_transform.position = new Vector3(lynx_position.Evaluate(my_time) + lynx_offset.x, 0f + lynx_offset.y, 0f + lynx_offset.z);

        if (my_time > 23f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
