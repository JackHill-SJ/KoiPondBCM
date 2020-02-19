using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSoundSpawn : MonoBehaviour
{

    public GameObject soundObject;
    [SerializeField] private Vector3 spawnValues;
    private float spawnWait;
    [SerializeField] private float spawnMostWait;
    [SerializeField] private float spawnLeastWait;
    public bool stopSpawning;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator Spawner()
    {
        while (!stopSpawning)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(soundObject, spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}
