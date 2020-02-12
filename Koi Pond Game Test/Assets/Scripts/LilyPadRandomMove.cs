using UnityEngine;
using System.Collections;

// Makes objects float left, right, up & down while spinning.
public class LilyPadRandomMove : MonoBehaviour
{
    // User Inputs
    public float speed;  // Speed of sway
    private Vector3 startingpos; //Starting position
    private Vector3 finalpos; //Final position
    private float deltaX;
    private float deltaZ;

    // Use this for initialization
    void Start()
    {
        startingpos = transform.position;
        SetDeltas();
    }

    public void SetDeltas()
    {
        float deltaX = Random.Range(-0.5f, 0.5f);
        float deltaZ = Random.Range(-0.5f, 0.5f);
        Vector3 posDiff = new Vector3(deltaX, 0f, deltaZ);
        finalpos = transform.position + posDiff;
    }

    // Update is called once per frame
    void Update()
    {
        //Move object back and forth
        transform.position = Vector3.Lerp(startingpos, finalpos, Mathf.PingPong(Time.time * speed, 1.0f));
        transform.Rotate(Vector3.up * 10f * Time.deltaTime);
    }
}