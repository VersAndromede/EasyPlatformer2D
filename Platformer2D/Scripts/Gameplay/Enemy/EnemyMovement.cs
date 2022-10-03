using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyPath _path;
    [SerializeField] private float _speedChange;

    private Rigidbody2D _rigidbody;
    private Transform[] _enemyPoints;
    private int _currentTarget;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyPoints = new Transform[_path.transform.childCount];

        for (int i = 0; i < _path.transform.childCount; i++)
            _enemyPoints[i] = _path.transform.GetChild(i);
    }

    private void FixedUpdate()
    {
        Transform target = _enemyPoints[_currentTarget];

        _rigidbody.position = Vector3.MoveTowards(_rigidbody.position, new Vector2(target.position.x, _rigidbody.position.y), _speedChange * Time.deltaTime);

        if (_rigidbody.position.x == target.position.x)
        {
            _currentTarget++;

            if (_currentTarget >= _enemyPoints.Length)
                _currentTarget = 0;
        }
    }
}
