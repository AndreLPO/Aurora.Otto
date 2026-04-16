using UnityEngine;

public class PressButton : MonoBehaviour
{
    [SerializeField] private LayerMask ottoLayer;
    [SerializeField] private Transform door;


    void Start()
    {}

    void Update()
    {
        // if (GetIsUnderOtto())
        // {
        //     SetColor(Color.red);
        //     door.localPosition = new Vector2(door.localPosition.x, -0.5f);
        // }
        // else
        // {
        //     SetColor(Color.yellow);
        //     door.localPosition = new Vector2(door.localPosition.x, 0.5f);
        // }
        float targetY = GetIsUnderOtto() ? 3.5f : 0;
        door.localPosition = Vector2.MoveTowards(
            door.localPosition,
            new Vector2(door.localPosition.x, targetY),
            2f * Time.deltaTime
        );
    }

    private bool GetIsUnderOtto()
    {
        return Physics2D.Raycast(transform.position, Vector2.up, 0.6f, ottoLayer);
    }

    void SetColor(Color color)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = color;
    }

}
