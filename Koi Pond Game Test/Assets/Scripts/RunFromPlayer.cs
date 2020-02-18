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
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < fleeDistance)
        {
            relativePosition = player.position - transform.position;
            targetRotation = Quaternion.LookRotation(-relativePosition);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 100 * turnSpeed);
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (transform.position.y > 90)
            transform.position = new Vector3(transform.position.x, 90, transform.position.z);

    }
}
