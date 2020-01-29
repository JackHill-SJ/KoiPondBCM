using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishAI : MonoBehaviour
{
    public NavMeshAgent fishAgent;

    public enum fishState
    {
        MOVE
    }

    public fishState AIState;

    private bool active = true;

    // Variables for movement
    public GameObject[] wayPoints;

    private int wayPointInd = 0;

    public float moveSpeed = 1.0f;

    [SerializeField]
    private Collider m_collider;

    private bool m_hasTarget = false;

    [SerializeField]
    private Vector3 waypoint;


    private MoveToPlayer playerCapsule;

    public Rigidbody RB;


    // Use this for initialization
    void Start()
    {
        fishAgent = GetComponent<NavMeshAgent>();

        GameObject.FindGameObjectsWithTag("fish");

        fishAgent.updatePosition = true;
        fishAgent.updateRotation = true;

        wayPoints = GameObject.FindGameObjectsWithTag("waypoint");
        wayPointInd = Random.Range(0, wayPoints.Length);

        AIState = FishAI.fishState.MOVE;


        playerCapsule = GetComponent<MoveToPlayer>();

        RB = GetComponent<Rigidbody>();


        StartCoroutine("FSM");
    }

    IEnumerator FSM()
    {
        while (active)
        {
            switch (AIState)
            {
                case fishState.MOVE:
                    Move();
                    break;
               
            }

            yield return null;
        }
    }

    void Move()
    {
        if (playerCapsule.playerInteract == false)
        {   
            fishAgent.isStopped = false;  //ulm

            fishAgent.speed = moveSpeed;
            if (Vector3.Distance(this.transform.position, wayPoints[wayPointInd].transform.position) >= 2)
            {
                fishAgent.SetDestination(wayPoints[wayPointInd].transform.position);
            }
            else if (Vector3.Distance(this.transform.position, wayPoints[wayPointInd].transform.position) <= 2)
            {
                wayPointInd = Random.Range(0, wayPoints.Length);
            }
        }
        else
        {
            fishAgent.isStopped = true;   //ulm
        }

    }

    void CollidedFish()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, transform.localScale.z))
        {
            //if collider has hit a waypoint or registers itself ignore raycast hit
            if (hit.collider == m_collider | hit.collider.tag == "waypoint")
            {
                return;
            }
            //otherwise have a random chance that fish will change direction
            int randomNum = Random.Range(1, 100);
            if (randomNum < 40)
            {
                m_hasTarget = false;
                transform.Rotate(Vector3.left, 45 * Time.deltaTime * moveSpeed);
            }
        }
    }
}