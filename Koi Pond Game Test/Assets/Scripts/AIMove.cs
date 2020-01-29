using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    //declare variable for AISpawner manager script
    private AISpawner m_AIManager;

    //declare variables for moving and turning
    private bool m_hasTarget = false;
    private bool m_isTurning;

    //variable for the current waypoint
    private Vector3 m_wayPoint;
    private Vector3 m_lastWaypoint = new Vector3(0f, 0f, 0f);

    //going to use this to set the animation speed
    private Animator m_Animator;

    [SerializeField]
    private float m_speed = 7.0f;

    private Collider m_collider;

	// Use this for initialization
	void Start ()
    {
        m_Animator = GetComponent<Animator>();

        SetUpFish();
        m_wayPoint = GameObject.FindGameObjectWithTag("waypoint").transform.position;
	}

    void SetUpFish()
    {
        //Randomly scale each fish
        float m_scale = Random.Range(0f, 1f);
        transform.localScale += new Vector3(m_scale * 1f, m_scale, m_scale);

        if(transform.GetComponent<Collider>() != null && transform.GetComponent<Collider>().enabled == true)
        {
            m_collider = transform.GetComponent<Collider>();
        }
        else if (transform.GetComponentInChildren<Collider>() != null && transform.GetComponentInChildren<Collider>().enabled == true)
        {
            m_collider = transform.GetComponentInChildren<Collider>();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if we found a waypoint we need to move there
        if (m_hasTarget)
        {
            //m_hasTarget = CanFindTarget();
            Debug.Log("Find Target");
        }
        else
        {
            //make sure we rotate the fish to face it's waypoint
            RotateFish(m_wayPoint, m_speed);

            //move the fish in a straight line toward the waypoint
            transform.position = Vector3.MoveTowards(transform.position, m_wayPoint, m_speed * Time.deltaTime);
            Debug.Log("Found Target");
        }
	}

     void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "waypoint")
        {
            m_hasTarget = false;
            int x = Random.Range(0, 10);
            m_wayPoint = GameObject.FindGameObjectWithTag("pond").GetComponent<AISpawner>().fishWayPoints[x].transform.position;
        }
    }

    //Rotate the Fish to face a new waypoint
    void RotateFish(Vector3 waypoint, float currentSpeed)
    {
        //get random speed for the turn
        float turnSpeed = currentSpeed * Random.Range(1f, 3f);

        //get new direction to look at for target
        Vector3 LookAt = waypoint - this.transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookAt), turnSpeed * Time.deltaTime);
    }
}