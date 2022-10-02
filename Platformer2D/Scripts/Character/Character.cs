using UnityEngine;
using UnityEngine.Events;

public enum CharacterState
{
    Idle,
    Run,
    Jump
}

public class Character : MonoBehaviour
{
    public event UnityAction StateChanged;

    public CharacterState CharacterState { get; private set; }

    public void ChangeCharacterState(CharacterState characterState)
    {
        CharacterState = characterState;
        StateChanged?.Invoke();
    }
}
