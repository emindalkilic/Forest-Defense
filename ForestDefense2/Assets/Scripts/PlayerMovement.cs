using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    private Rigidbody rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.fixedDeltaTime);

        if (moveX > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveX < 0)
        {
            spriteRenderer.flipX = false;
        }

        animator.SetBool("IsRunning", moveDirection != Vector3.zero);
    }
}