using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Bounce : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private float _jumpForce;

    public UnityEvent<CharacterState> CharacterJumped;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        float minVelocityY = -8;

        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.IsGround && _groundChecker.IsJumpChanceUsed == false)
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
            _groundChecker.DeactivateJumpPremature();
            CharacterJumped?.Invoke(CharacterState.Jump);
        }

        if (_rigidbody.velocity.y < minVelocityY)
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, minVelocityY);
    }
}
                                                                                                                                                                                                 