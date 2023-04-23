using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PredatorAnnouncement : MonoBehaviour
{

    public TextMeshProUGUI my_text;
    public float trans;

    public void MakeAnnouncement(string text)
    {

        my_text.text = text;

        trans = 2.5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        trans = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        trans -= Time.deltaTime / 2f;

        my_text.color = new Vector4 (1f, 1f, 1f, trans);
    }
}
