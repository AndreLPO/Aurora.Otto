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
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void FixedUpdate()
    {
        if (!isActiveCharacter) return;

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

}
