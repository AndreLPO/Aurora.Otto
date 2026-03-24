using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float playerHalfHeight;

    void Start()
    {
        playerHalfHeight = spriteRenderer.bounds.extents.y;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && GetIsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool GetIsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, playerHalfHeight + 0.1f, groundLayer);
    }
}
