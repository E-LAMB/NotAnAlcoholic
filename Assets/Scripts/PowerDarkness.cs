using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerDarkness : MonoBehaviour
{

    public Challenge_Power my_challenger;
    public Transform my_size;

    public bool is_shrinking;

    public float current_size;

    public float big_size;
    public float small_size;

    public float speed;

    public RawImage[] dark_image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        is_shrinking = !my_challenger.power_on;

        my_size.position = Input.mousePosition;

        if (is_shrinking)
        {
            current_size -= Time.deltaTime * speed * 2f;
        } else
        {
            current_size += Time.deltaTime * speed;
        }

        if (current_size < small_size)
        {
            current_size = small_size;
        } 
        if (current_size > big_size)
        {
            current_size = big_size;
        }

        dark_image[0].color = new Vector4(0f,0f,0f, small_size / current_size);
        dark_image[1].color = new Vector4(0f,0f,0f, small_size / current_size);
        dark_image[2].color = new Vector4(0f,0f,0f, small_size / current_size);
        dark_image[3].color = new Vector4(0f,0f,0f, small_size / current_size);
        dark_image[4].color = new Vector4(0f,0f,0f, small_size / current_size);

        my_size.localScale = new Vector3(current_size, current_size, 1f);

    }
}
