using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    public UnityEvent<CharacterState> CharacterMoved;
    public UnityEvent<CharacterState> CharacterStopped;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
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
            CharacterMoved?.Invoke(CharacterState.Run);

            if (direction < 0)
                transform.localScale = new Vector2(-1, transform.localScale.y);
            else
                transform.localScale = new Vector2(1, transform.localScale.y);
        }
        else
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
            CharacterMoved?.Invoke(CharacterState.Idle);
        }
    }
}
