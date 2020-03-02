using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunFromPlayer : MonoBehaviour
{
    public Transform player;
    public float fleeDistance = 4.0f;
    public float turnSpeed = 20.0f;
    public float smoothTime = 1.5f;
    public float speed = 5.0f;

    private Vector3 relativePosition;
    private Quaternion targetRotation;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Stops catfish from going outside of pond area.
        if (transform.position.z >= 10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 10);
        }

        if (transform.position.z <= -4)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -4);
        }

        //Block of code that has the Catfish run from the player upon their approach.
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < fleeDistance)
        {
            relativePosition = player.position - transform.position;
            targetRotation = Quaternion.LookRotation(-relativePosition);

            StartCoroutine(RunAway());
        }

        if (transform.position.y > 90)
            transform.position = new Vector3(transform.position.x, 90, transform.position.z);

    }

    IEnumerator RunAway()
    {
        float timePassed = 0;
        while (timePassed < .5)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 100 * turnSpeed);
            transform.position = Vector3.MoveTowards(transform.position, player.position, -Time.deltaTime);
            timePassed += Time.deltaTime;

            yield return null;
        }
    }
}


