using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseSingletonBehaviour<PlayerController>
{
    public bool canMove = true;
    public float moveSpeed = 3.0f;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _moveVelocity;

    

    // Start is called before the first frame update
    void Start()
    {
      
        DontDestroyOnLoad(gameObject);

        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _moveVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            Move(_moveVelocity.x, _moveVelocity.y);
        }
    }

    private void Move(float x, float y)
    {
        if (x != 0 || y != 0) _animator.SetBool("isMoving", true);
        else _animator.SetBool("isMoving", false);
        _rigidbody.velocity = new Vector2(x * moveSpeed, y * moveSpeed);
        _animator.SetFloat("MoveX", x);
        _animator.SetFloat("MoveY", y);
        
    }

}
