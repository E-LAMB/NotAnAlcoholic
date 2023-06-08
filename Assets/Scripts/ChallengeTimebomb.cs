using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeTimebomb : MonoBehaviour
{

    public ChallengeBombController my_challenger;

    public bool color;
    public float timer;

    public SpriteRenderer my_render;
    public Sprite red;
    public Sprite blue;

    void OnMouseDown()
    {
        my_challenger.bombs -= 1;
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        my_challenger = GameObject.FindGameObjectWithTag("BombController").GetComponent<ChallengeBombController>();
        my_challenger.bombs += 1;
        if (Random.Range(0,2) == 1)
        {
            color = true;
        }
        if (color)
        {
            my_render.sprite = blue;
        } else
        {
            my_render.sprite = red;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.4f)
        {
            timer -= 0.4f;
            color = !color;
            if (color)
            {
                my_render.sprite = blue;
            } else
            {
                my_render.sprite = red;
            }
        }
    }
}
