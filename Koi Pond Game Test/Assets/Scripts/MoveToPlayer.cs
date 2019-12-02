using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public Transform player;
    public float walkingDistance = 4.0f;
    public float stoppingDistance = 1.75f;
    public float smoothTime = 1.5f;
    private Vector3 smoothVelocity = Vector3.zero;
    private bool underPlayer;

    //in the scene, try setting walking distance = 4  stopping distance = 1.75   and smooth time = 1.5


    public bool playerInteract;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        //get distance between fish and player first
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < walkingDistance)
        {
            playerInteract = true;
        }
        else
        {
            playerInteract = false;
        }


        //if fish is in range of player [stopping distance] then underplayer is true and fish is still interacting with player
        if (distance <= stoppingDistance)
        {
            underPlayer = true;
        }
        //if fish is not within stopping distance, definitely not underplayer
        else //if (distance > stoppingDistance)
        {
            underPlayer = false;
        }


        //now check for the greater distance, the walking distance
        if (distance < walkingDistance && underPlayer != true)  //if less than walkingdistance but not underplayer, then keep moving toward player
        {
            transform.LookAt(player);


            //Vector3 targetPosition = player.TransformPoint(new Vector3(-1, 0, -1));
            //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref smoothVelocity, smoothTime);
            //OR
            transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);

        }


        if (transform.position.y > 90)
            transform.position = new Vector3(transform.position.x, 90, transform.position.z);
    }
}