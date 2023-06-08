using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerFuse : MonoBehaviour
{

    public Challenge_Power my_challenger;

    public float appearance;
    public SpriteRenderer self;

    void OnMouseDown()
    {
        if (!my_challenger.fuse_collected)
        {
            Debug.Log("Collected Fuse");
            my_challenger.fuse_collected = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        appearance += Time.deltaTime;
        if (appearance > 1f)
        {
            appearance = 1f;
        }
        self.color = new Vector4(1f, 1f, 1f, appearance);
    }
}
