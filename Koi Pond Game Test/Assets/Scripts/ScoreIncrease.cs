using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncrease : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "fish")
        {
            ScoreManager.score += 100;
            Debug.Log(ScoreManager.score);
            Destroy(gameObject);
        }
    }
}
