using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HugoEasterEgg : MonoBehaviour
{

    public int rolled;
    public int max;
    bool show;
    public Image self;

    // Start is called before the first frame update
    void Start()
    {
        rolled = Random.Range(0, max);
        if (rolled == 1)
        {
            show = true;
        } else
        {
            show = false;
        }
        self.enabled = show;
    }

}
