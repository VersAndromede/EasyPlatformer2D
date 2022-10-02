using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private float _speedChange;

    private Rigidbody2D _rigidbody;
    private Transform _currentTarget;
    private bool _isPoint1Reached;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_isPoint1Reached)
            _currentTarget = _point2;
        else
            _currentTarget = _point1;

        _rigidbody.position = Vector3.MoveTowards(_rigidbody.position, new Vector2(_currentTarget.position.x, _rigidbody.position.y), _speedChange * Time.deltaTime);

        if (_rigidbody.position.x == _point1.position.x)
            _isPoint1Reached = true;

        if (_rigidbody.position.x == _point2.position.x)
            _isPoint1Reached = false;
    }
}
