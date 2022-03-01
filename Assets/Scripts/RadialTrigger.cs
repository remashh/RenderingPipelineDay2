using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RadialTrigger : MonoBehaviour
{
   [SerializeField] private float radius;
   [SerializeField] private Transform targetPoint;

   private void OnDrawGizmos()
   {
      Handles.color = Color.green;
      var distance = Mathf.Sqrt(Mathf.Pow(targetPoint.transform.position.x, 2) +
                                Mathf.Pow(targetPoint.transform.position.y, 2));
      Handles.DrawWireDisc(transform.position, Vector3.forward, radius);
      if (distance < radius)
      {
         Gizmos.color = Color.cyan;
         Gizmos.DrawLine(transform.position, targetPoint.transform.position);
         Handles.color = Color.red;
         Handles.DrawWireDisc(transform.position, Vector3.forward, radius);
      }
   }
}
