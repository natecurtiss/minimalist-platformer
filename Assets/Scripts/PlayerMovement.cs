using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Gizmos;
using static UnityEngine.Input;
using static UnityEngine.Mathf;
using static UnityEngine.Physics2D;
using static UnityEngine.Time;

class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    [SerializeField] LayerMask _ground;
    [SerializeField] float _speed = 18f;
    [SerializeField] float _acceleration = 0.4f;
    [SerializeField] float _deceleration = 0.2f;
    [SerializeField] float _jump = 40f;
    [SerializeField] float _groundDistance = 1f;
    [SerializeField] float _coyoteTime = 0.2f;

    [SerializeField] UnityEvent _onJump;
    [SerializeField] UnityEvent _onLand;
    [SerializeField] UnityEvent<int> _onMove;
    [SerializeField] UnityEvent<int> _onStop;

    float _horizontalInput;
    float _jumpBuffer;
    float _groundTimer;
    bool _isMoving;
    int _direction;

    void Awake() => _rigidbody = GetComponent<Rigidbody2D>();

    void Update()
    {
        TickTimers();
        CheckGround();
        GetInput();
    }

    void FixedUpdate()
    {
        Move();
        if (_jumpBuffer > 0 && _groundTimer > 0)
            Jump();
    }

    void OnDrawGizmos() => DrawRay(transform.position, Vector3.down * _groundDistance);

    void TickTimers()
    {
        _groundTimer -= deltaTime;
        _jumpBuffer -= deltaTime;
    }

    void CheckGround()
    {
        var hit = Raycast(transform.position, Vector2.down, _groundDistance, _ground);
        if (hit.collider is not null)
        {
            if (_groundTimer <= 0) 
                _onLand.Invoke();
            _groundTimer = _coyoteTime;
        }
    }
    
    void GetInput()
    {
        _horizontalInput = GetAxisRaw("Horizontal");
        if (GetAxisRaw("Vertical") == 1)
            _jumpBuffer = _coyoteTime;
    }

    void Move()
    {
        if (_horizontalInput != 0 && _horizontalInput != _direction)
        {
            _direction = (int) _horizontalInput;
            _onMove.Invoke(_direction);
            _isMoving = true;
        }
        else if (_horizontalInput == 0 && _isMoving)
        {
            _onStop.Invoke(_direction);
            _isMoving = false;
        }
        var target = _speed * _horizontalInput;
        var t = target == 0 ? _deceleration : _acceleration;
        var lerp = Lerp(_rigidbody.velocity.x, target, t);
        _rigidbody.velocity = new(lerp, _rigidbody.velocity.y);
    }

    void Jump()
    {
        _rigidbody.velocity = new(_rigidbody.velocity.x, _jump);
        _groundTimer = 0f;
        _jumpBuffer = 0f;
        _onJump.Invoke();
    }
}
