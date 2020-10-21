using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncrease : MonoBehaviour
{
    public GameObject PointCube;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "fish")
        {
            ScoreManager.score += 100;
            Debug.Log(ScoreManager.score);
            SpawnNewCube();
            Destroy(gameObject);
        }
    }

    public void SpawnNewCube()
    {
        int randomIntX = Random.Range(-14,14);
        int randomIntZ = Random.Range(-4, 11);

        Instantiate(PointCube, new Vector3(randomIntX, -2.5f, randomIntZ), Quaternion.identity);
    }
}
