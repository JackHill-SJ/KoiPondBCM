﻿using System.Collections;
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
            particles.Play();
        }
        else
        {
            particles.Stop();
        }
    }
}
