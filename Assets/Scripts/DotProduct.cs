using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class DotProduct : MonoBehaviour
{
   [SerializeField] [Range(0f,1f)] private float _treshhold;
   [SerializeField] private Transform _targetPoint;

   private void OnDrawGizmos()
   {
      Gizmos.color = Color.green;
      Gizmos.DrawLine(transform.position, transform.right);
      Vector3 vectorToTarget = (_targetPoint.position - transform.position).normalized;
      if (Vector3.Dot(vectorToTarget, transform.right) > _treshhold)
      {
         Gizmos.color = Color.red;
         Gizmos.DrawLine(transform.position, transform.right);
      }
   }
}
