using UnityEngine;
using System.Collections;

// Makes objects float up & down while gently spinning.
public class LilyPadBob : MonoBehaviour
{
    // User Inputs
    public float degreesPerSecond = 15.0f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);
    }
}