using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _actionMove;
    
    private Rigidbody2D _rb;

    private float _inputMove;

    [SerializeField] private float _speed = 100f;
    
    
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }



    private void FixedUpdate()
    {
        _inputMove = _actionMove.action.ReadValue<float>();

        
        _rb.linearVelocity = new Vector2(_inputMove * Time.fixedDeltaTime * _speed, _rb.linearVelocity.y);
    }
}
