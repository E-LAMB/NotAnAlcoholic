using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeTimebomb : MonoBehaviour
{

    public ChallengeBombController my_challenger;

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
    }
}
