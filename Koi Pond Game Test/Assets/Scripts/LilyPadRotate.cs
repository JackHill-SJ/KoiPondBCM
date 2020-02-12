using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyPadRotate : MonoBehaviour
{
    private int degreesPerSecond; //Speed of spin

    private void Start()
    {
        degreesPerSecond = Random.Range(-4, 5);
    }

    void Update()
    {
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);
        //Ensures that the rotation speed is not zero
        if (degreesPerSecond == 0)
        {
            Start();
        }
    }
}
