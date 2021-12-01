using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Aircraft/Propeller")]
[DisallowMultipleComponent]
public class Propeller : MonoBehaviour
{
    
    [SerializeField]
    private Transform pointA;
    [SerializeField]
    private Transform pointB;

    [SerializeField]
    private float targetTime;

    private float timer;

    private void Awake()
    {
        timer = 0.0f;
    }

    private void Update()
    {
    }

}
