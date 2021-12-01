using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[HelpURL("https://google.com")]
public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private Gun[] guns;
    private void Update()
    {
        Vector3 newDirection = new Vector3(0, 0, 0);
        float vInput = Input.GetAxis("Vertical"); // W and S
        float hInput = Input.GetAxis("Horizontal"); // A and D
        
        newDirection.z = vInput;
        newDirection.x = hInput;

        if (Input.GetMouseButtonDown(0))
        {
            foreach (var gun in guns)
            {
                gun.StartShooting();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            foreach (var gun in guns)
            {
                gun.StopShooting();
            }
        }
        
        playerMovement.SetMovementDirection(newDirection);
    }
}
