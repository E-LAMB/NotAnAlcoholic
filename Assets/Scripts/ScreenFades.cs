using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFades : MonoBehaviour
{

    public RawImage the_renderer;

    public float time_to_spend;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        the_renderer.color = new Vector4(0f,0f,0f, 1f - (timer / time_to_spend));

        if (time_to_spend < timer)
        {
            Destroy(this.gameObject);
        }
    }
}
