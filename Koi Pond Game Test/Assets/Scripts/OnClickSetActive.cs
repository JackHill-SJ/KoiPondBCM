using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickSetActive : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
