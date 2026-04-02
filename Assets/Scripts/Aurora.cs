using UnityEngine;

public class Aurora : MonoBehaviour
{
    [SerializeField] private GameObject otto;
    [SerializeField] private LayerMask ottoLayer;
    [SerializeField] private float grabDistance;
    [SerializeField] private Transform rayTransform;
    [SerializeField] private Transform grabPosition;

    private Vector2 characterDirection = Vector2.right;
    private Rigidbody2D ottoRb;
    private Move ottoMove;
    private bool isCarrying = false;

    void Start()
    {
        ottoRb = otto.GetComponent<Rigidbody2D>();
        ottoMove = otto.GetComponent<Move>();
    }

    
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        if (moveInput != 0) {
            characterDirection = new Vector2(moveInput, 0).normalized;
        }

        bool hit = Physics2D.Raycast(rayTransform.position, characterDirection, grabDistance, ottoLayer);;

        if (Input.GetKeyDown(KeyCode.E)) {
            if (!isCarrying && hit)
                PickUp();
            else
                Drop();
        }
    }

    void PickUp()
    {
        // trava física
        ottoRb.simulated = false;

        // trava movimento dele
        ottoMove.isActiveCharacter = false;

        // vira filho da Aurora
        otto.transform.SetParent(grabPosition);
        otto.transform.localPosition = Vector3.zero;

        isCarrying = true;
    }

    void Drop()
    {
        // solta
        otto.transform.SetParent(null);

        // ativa física
        ottoRb.simulated = true;

        isCarrying = false;
    }
}
