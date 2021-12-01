using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
       [SerializeField]
       private Vector3 offset;

       [SerializeField]
       private Transform target;

       private void LateUpdate()
       {
           Vector3 targetPosition = target.position;
           targetPosition += offset;
           transform.position = targetPosition;
       }
}