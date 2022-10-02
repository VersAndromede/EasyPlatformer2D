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
        if (_character.CharacterState == CharacterState.Idle)
        {
            _animator.SetBool("Idle", true);
            _animator.SetBool("Run", false);
        }
        else if (_character.CharacterState == CharacterState.Run)
        {
            _animator.SetBool("Run", true);
            _animator.SetBool("Idle", false);
        }
        else if (_character.CharacterState == CharacterState.Jump)
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("Idle", false);
            _animator.SetTrigger("Jump");
        }
    }
}
