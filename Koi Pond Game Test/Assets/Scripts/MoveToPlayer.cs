using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public Transform player;
    public float walkingDistance = 10.0f;
    public float stoppingDistance = 5.0f;
    public float smoothTime = 10.0f;
    private Vector3 smoothVelocity = Vector3.zero;
    private bool underPlayer;

    public bool playerInteract;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < walkingDistance && underPlayer != true)
        {
            playerInteract = true;
            transform.LookAt(player);
            transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
        }
        if (distance > walkingDistance && underPlayer != true)
        {
            playerInteract = false;
        }

        if (distance <= stoppingDistance)
        {
            underPlayer = true;
        }

        if (distance >= stoppingDistance)
        {
            underPlayer = false;
        }

        if (transform.position.y > 90)
            transform.position = new Vector3(transform.position.x, 90, transform.position.z);
    }
}
