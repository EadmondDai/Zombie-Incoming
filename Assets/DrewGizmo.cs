using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrewGizmo : MonoBehaviour
{
    [SerializeField] float gizmoRange = 10f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, gizmoRange);
    }
}
