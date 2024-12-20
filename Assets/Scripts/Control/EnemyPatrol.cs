using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_PROJECT.Control
{
    public class EnemyPatrol : MonoBehaviour
    {
        const float waypointGizmoRadius = 0.3f;

        private void OnDrawGizmos()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                int j = GetNextIndex(i);
                Gizmos.DrawSphere(GetWaypoint(i), waypointGizmoRadius);
                Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));
            }
        }

        public int GetNextIndex(int i)
        {
            //This function gets the next index of the tarnsform we need to go to
            if (i + 1 == transform.childCount)
            {
                return 0; //ths will ensure the loop does not go out of bounds
            }
            return i + 1;
        }

        public Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position; //gets the transform of the position the enemy will go to
        }
    }
}