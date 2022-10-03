using UnityEngine;

[RequireComponent(typeof(Character), typeof(Rigidbody2D))]
public class Bounce : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private float _jumpForce;

    private Character _character;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _character = GetComponent<Character>();
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
            _character.ChangeCharacterState(CharacterState.Jump);
        }

        if (_rigidbody.velocity.y < minVelocityY)
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, minVelocityY);
    }
}
                                                                                                                                                                                                 
