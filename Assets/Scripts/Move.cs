using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

}
