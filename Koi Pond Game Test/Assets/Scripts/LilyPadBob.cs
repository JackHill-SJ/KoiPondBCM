using UnityEngine;
using System.Collections;

// Makes objects float up & down while gently spinning.
public class LilyPadBob : MonoBehaviour
{
    // User Inputs
    public float degreesPerSecond = 15.0f;
    public float delta = 1.0f;  // Amount to move left and right from the start point
    public float speed = 1.0f;  // Speed of sway
    private Vector3 startPos;   // Starting position of the object

    // Position Storage Variables
    Vector3 posOffset = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);
        Vector3 v = startPos;
        float delta = Random.Range(1, 2);
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}