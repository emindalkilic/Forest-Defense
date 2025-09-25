using UnityEngine;

public class Path : MonoBehaviour
{
    public Transform[] waypoints;

    void OnDrawGizmos()
    {
        if (waypoints != null && waypoints.Length > 1)
        {
            Gizmos.color = Color.red;
            for (int i = 0; i < waypoints.Length - 1; i++)
            {
                if (waypoints[i] != null && waypoints[i + 1] != null)
                {
                    Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
                }
            }
        }
    }
}