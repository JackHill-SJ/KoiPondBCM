using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public Transform player;
    public float walkingDistance = 4.0f;
    public float stoppingDistance = 1.75f;
    public float smoothTime = 1.5f;
    public float turnSpeed = 20.0f;
    private Vector3 smoothVelocity = Vector3.zero;
    private bool underPlayer;
    private Vector3 relativePosition;
    private Quaternion targetRotation;


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
        else
        {
            underPlayer = false;
        }


        //now check for the greater distance, the walking distance
        if (distance < walkingDistance && underPlayer != true)  //if less than walkingdistance but not underplayer, then keep moving toward player
        {
            // Checks for the relative position between the target(player) and Koi fish, then sets the targetRotation to the relative position found.
            relativePosition = player.position - transform.position;
            targetRotation = Quaternion.LookRotation(relativePosition);

            //Quaternion.Lerp is used to create smooth rotation for the fish when they notice the player. Increase the number being multiplyed by turnSpeed to increase turn speed.
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 200 * turnSpeed);
            transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);

        }


        if (transform.position.y > 90)
            transform.position = new Vector3(transform.position.x, 90, transform.position.z);
    }
}