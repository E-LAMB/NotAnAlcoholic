using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuotaShower : MonoBehaviour
{

    public GameplayDirector the_director;
    public TextMeshProUGUI my_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        my_text.text = "Quota: " + the_director.quota_fufilled.ToString() + " / " + the_director.quota_for_today.ToString();
    }
}
