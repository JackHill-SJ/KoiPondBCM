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
        //get the AISpawner from it's parent
        //m_AIManager = transform.parent.GetComponentInParent<AISpawner>();
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
        //if we have not found a way point to move to
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

            //Check if collided - if yes then lose the target and look for a new waypoint
            //CollidedFish();
            
        }

        //if fish reaches waypoint reset target
        /*if(transform.position == m_wayPoint)
        {
            m_hasTarget = false;
        }*/
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

    //method for changing direction if a fish collides with something
    /*void CollidedFish()
    {
        
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, transform.localScale.z))
        {
            //if collider has hit a waypoint or registers itself ignore raycast hit
            if(hit.collider == m_collider | hit.collider.tag == "waypoint")
            {
                return;
            }
            //otherwise have a random chance that fish will change direction
            int randomNum = Random.Range(1, 100);
            if(randomNum < 40)
            {
                m_hasTarget = false;
            }

            //Debug just to show that it works
            Debug.Log(hit.collider.transform.parent.name + " " + hit.collider.transform.parent.position);
        }
    }*/

    //Get the waypoint
    /*Vector3 GetWaypoint(bool isRandom)
    {
        //if isRandom is true then get a random position location
        if (isRandom)
        {
            return m_AIManager.RandomPosition();
        }
        //otherwise get a random waypoint from the list of waypoint gameObjects
        else
        {
            return m_AIManager.RandomWaypoint();
        }
    }*/

    /*bool CanFindTarget(float start = 1f, float end = 7f)
    {
        m_wayPoint = m_AIManager.RandomWaypoint();
        
        //make sure we don't set the same waypoint twice
        if(m_lastWaypoint == m_wayPoint)
        {
            //get a new waypoint
            m_wayPoint = GetWaypoint(true);
            return false;
        }
        else
        {
            //set the new waypoint as the last waypoint
            m_lastWaypoint = m_wayPoint;

            //get random speed for movement and animation
            m_speed = Random.Range(start, end);
            m_Animator.speed = m_speed;
            //set bool to true to say we found a WP
            return true;
        }
    }*/

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