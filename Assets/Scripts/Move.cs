using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Rigidbody2D rb;

    public bool isActiveCharacter = false;

    private float moveInput;

    void Update()
    {
        if (!isActiveCharacter) return;

        moveInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        if (!isActiveCharacter) return;

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

}
