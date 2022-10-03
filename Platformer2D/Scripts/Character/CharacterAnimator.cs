using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Character))]
public class CharacterAnimator : MonoBehaviour
{
    private Animator _animator;
    private Character _character;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _character = GetComponent<Character>();
    }

    private void OnEnable()
    {
        _character.StateChanged += PlayAnimate;
    }

    private void OnDisable()
    {
        _character.StateChanged -= PlayAnimate;
    }

    private void PlayAnimate()
    {
        const string IdleAnimation = "Idle";
        const string RunAnimation = "Run";
        const string JumpAnimation = "Jump";

        if (_character.CharacterState == CharacterState.Idle)
        {
            _animator.SetBool(IdleAnimation, true);
            _animator.SetBool(RunAnimation, false);
        }
        else if (_character.CharacterState == CharacterState.Run)
        {
            _animator.SetBool(RunAnimation, true);
            _animator.SetBool(IdleAnimation, false);
        }
        else if (_character.CharacterState == CharacterState.Jump)
        {
            _animator.SetBool(RunAnimation, false);
            _animator.SetBool(IdleAnimation, false);
            _animator.SetTrigger(JumpAnimation);
        }
    }
}
