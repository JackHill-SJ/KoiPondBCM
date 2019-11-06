using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarpAI : MonoBehaviour
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


    public Rigidbody RB;

    //public float slowdownSpeed = 0.1f;

    //public bool hasInteracted;


    // Use this for initialization
    void Start ()
    {
        fishAgent = GetComponent<NavMeshAgent>();

        GameObject.FindGameObjectsWithTag("fish");

        fishAgent.updatePosition = true;
        fishAgent.updateRotation = true;

        wayPoints = GameObject.FindGameObjectsWithTag("waypoint");
        wayPointInd = Random.Range(0, wayPoints.Length);

        AIState = CarpAI.fishState.MOVE;


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
        {
            //make sure we rotate the fish to face it's waypoint
            //RotateFish(waypoint, moveSpeed);
            /*if (hasInteracted == true)
            {
                wayPointInd = Random.Range(0, wayPoints.Length);
                moveSpeed *= 100;
                hasInteracted = false;
            }*/
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
    }
    
	
	// Update is called once per frame
	void Update ()
    {
        CollidedFish();
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
            }
        }
    }

    /*void RotateFish(Vector3 waypoint, float currentSpeed)
    {
        //get random speed for the turn
        float turnSpeed = currentSpeed * Random.Range(1f, 3f);

        //get new direction to look at for target
        Vector3 LookAt = waypoint - this.transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookAt), turnSpeed * Time.deltaTime);
    }*/
}
