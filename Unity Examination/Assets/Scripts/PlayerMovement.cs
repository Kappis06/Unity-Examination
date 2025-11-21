using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _actionMove;
    [SerializeField] private InputActionReference _actionJump;
    
    private Rigidbody2D _rb;
    private SpriteRenderer _renderer;
    private Animator _animator;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private float _inputMove;

    [SerializeField] private float _speed = 100f;
    [SerializeField] private float _jumpForce = 100f;
    
    
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }



    private void Update()
    {
        if (IsGrounded() && _actionJump.action.triggered)
            _rb.AddForceY(_jumpForce, ForceMode2D.Impulse);
        
        
        
        if (_inputMove > 0)
            _renderer.flipX = false;
        else if (_inputMove < 0)
            _renderer.flipX = true;
        
        _animator.SetBool("IsWalking", _inputMove != 0);
    }
    
    private void FixedUpdate()
    {
        _inputMove = _actionMove.action.ReadValue<float>();

        
        _rb.linearVelocity = new Vector2(_inputMove * Time.fixedDeltaTime * _speed, _rb.linearVelocity.y);
    }



    private bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(_groundCheck.position, Vector2.down, 0.1f, _groundLayer);
        
        return hitInfo.collider != null;
    }
}
