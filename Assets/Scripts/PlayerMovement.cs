using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
        [SerializeField]
        private float flySpeed;
        private Vector3 flyDirection;
        
        private void Start()
        {
                flyDirection = Vector3.forward;
        }

        private void Update()
        {
                transform.Translate(flyDirection * flySpeed * Time.deltaTime);
        }

        public void SetMovementDirection(Vector3 newDirection)
        {
                // movementDirection = newDirection.normalized;
        }
}