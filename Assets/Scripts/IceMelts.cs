using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMelts : MonoBehaviour
{

    public float my_life;
    public float size_change;
    public float fraction;
    public float buffer;

    public Transform self;
    public Vector3 start;
    public Vector3 final;
    public Vector3 current;

    // Start is called before the first frame update
    void Start()
    {
        start = self.localScale;
        my_life = 1f;
        final = start * size_change;
    }

    // Update is called once per frame
    void Update()
    {
        my_life += Time.deltaTime;
        fraction = my_life / (Mind.ice_melting_time + buffer);
        if (Mind.ice_melting_time < my_life)
        {
            Destroy(gameObject);
        }
        current = start;
        current = start - (fraction * final);
        self.localScale = current;
    }
}
