using UnityEngine;
using Unity.Cinemachine;

public class CharacterSwitcher : MonoBehaviour
{
    public Move aurora;
    public Move otto;
    [SerializeField] private CinemachineCamera  cam;

    private Move current;

    void Start()
    {
        SetActiveCharacter(aurora);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (current == aurora)
                SetActiveCharacter(otto);
            else
                SetActiveCharacter(aurora);
        }
    }

    void SetActiveCharacter(Move character)
    {
        aurora.isActiveCharacter = false;
        otto.isActiveCharacter = false;

        character.isActiveCharacter = true;
        current = character;

        UpdateVisuals();
        UpdateCameraTarget();
    }

    void UpdateCameraTarget()
    {
        cam.Follow = current.transform;
        cam.LookAt = current.transform;}

    void UpdateVisuals()
    {
        SetOpacity(aurora, aurora.isActiveCharacter ? 1f : 0.4f);
        SetOpacity(otto, otto.isActiveCharacter ? 1f : 0.4f);
    }

    void SetOpacity(Move character, float alpha)
    {
        SpriteRenderer sr = character.GetComponent<SpriteRenderer>();
        Color color = sr.color;
        color.a = alpha;
        sr.color = color;
    }
}