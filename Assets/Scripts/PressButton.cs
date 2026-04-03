using UnityEngine;

public class PressButton : MonoBehaviour
{
    [SerializeField] private LayerMask ottoLayer;

    void Start()
    {}

    void Update()
    {
        if (GetIsUnderOtto())
        {
            SetColor(Color.red);
        }
        else
        {
            SetColor(Color.yellow);
        }
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
