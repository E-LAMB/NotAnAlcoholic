using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderIcon : MonoBehaviour
{

    public GameObject icon_orange;
    public GameObject icon_ice;
    public GameObject icon_lime;
    public GameObject icon_mint;
    public GameObject icon_olive;
    public GameObject icon_cherry;

    public string to_show;

    // Start is called before the first frame update
    void Start()
    {
        icon_orange.SetActive(false);
        icon_ice.SetActive(false);
        icon_lime.SetActive(false);
        icon_mint.SetActive(false);
        icon_olive.SetActive(false);
        icon_cherry.SetActive(false);
    }

    public void new_icon(string ingredient)
    {
        to_show = ingredient;

        icon_orange.SetActive(false);
        icon_ice.SetActive(false);
        icon_lime.SetActive(false);
        icon_mint.SetActive(false);
        icon_olive.SetActive(false);
        icon_cherry.SetActive(false);

        if (to_show == "ORANGE")
        {
            icon_orange.SetActive(true);
        }
        if (to_show == "ICE")
        {
            icon_ice.SetActive(true);
        }
        if (to_show == "LIME")
        {
            icon_lime.SetActive(true);
        }
        if (to_show == "MINT")
        {
            icon_mint.SetActive(true);
        }
        if (to_show == "OLIVE")
        {
            icon_olive.SetActive(true);
        }
        if (to_show == "CHERRY")
        {
            icon_cherry.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
