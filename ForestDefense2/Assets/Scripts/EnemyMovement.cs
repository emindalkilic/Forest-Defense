using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0.8f;
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator.SetBool("IsRunning", true);
    }

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0 || currentWaypointIndex >= waypoints.Length)
        {
            Destroy(gameObject);
            return;
        }

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 moveDirection = (targetWaypoint.position - transform.position).normalized;

        transform.position += moveDirection * speed * Time.deltaTime;

        if (moveDirection.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveDirection.x < 0)
        {
            spriteRenderer.flipX = false;
        }

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.5f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetPath(Transform[] newWaypoints)
    {
        waypoints = newWaypoints;
        currentWaypointIndex = 0;
    }
}