using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _actionMove;
    
    private Rigidbody2D _rb;
    private SpriteRenderer _renderer;
    private Animator _animator;

    private float _inputMove;

    [SerializeField] private float _speed = 100f;
    
    
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }



    private void Update()
    {
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
}
