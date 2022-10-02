using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Character))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Character _character;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _character = GetComponent<Character>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float direction = Input.GetAxisRaw(Axis.Horizontal);

        if (Input.GetButton(Axis.Horizontal))
        {
            _rigidbody.velocity = new Vector2(direction * _speed, _rigidbody.velocity.y);
            _character.ChangeCharacterState(CharacterState.Run);

            if (direction < 0)
                transform.localScale = new Vector2(-1, transform.localScale.y);
            else
                transform.localScale = new Vector2(1, transform.localScale.y);
        }
        else
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
            _character.ChangeCharacterState(CharacterState.Idle);
        }
    }
}
