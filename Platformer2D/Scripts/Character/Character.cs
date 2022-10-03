using UnityEngine;
using UnityEngine.Events;

public enum CharacterState
{
    Idle,
    Run,
    Jump
}

[RequireComponent(typeof(Movement), typeof(Bounce))]
public class Character : MonoBehaviour
{
    public event UnityAction StateChanged;

    private Movement _movement;
    private Bounce _bounce;

    public CharacterState CharacterState { get; private set; }

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _bounce = GetComponent<Bounce>();
    }

    private void OnEnable()
    {
        _movement.CharacterMoved.AddListener(ChangeCharacterState);
        _movement.CharacterStopped.AddListener(ChangeCharacterState);
        _bounce.CharacterJumped.AddListener(ChangeCharacterState);
    }

    private void OnDisable()
    {
        _movement.CharacterMoved.RemoveListener(ChangeCharacterState);
        _movement.CharacterStopped.RemoveListener(ChangeCharacterState);
        _bounce.CharacterJumped.RemoveListener(ChangeCharacterState);
    }

    private void ChangeCharacterState(CharacterState characterState)
    {
        CharacterState = characterState;
        StateChanged?.Invoke();
    }
}
