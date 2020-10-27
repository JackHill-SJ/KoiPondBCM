using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickSetActive : MonoBehaviour
{
    private ParticleSystem particles;
    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // This part of the if else statement is empty and honestly I don't know why.
        }
        else
        {
            particles.Play();
        }

    }
}
