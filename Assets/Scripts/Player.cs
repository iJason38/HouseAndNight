using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed=1;
    public float MaxHight = 2;
    private Rigidbody2D _rb;
    private Vector2 _moveVelocity;
    private Animator _anim;
    public bool CheckAllRoom = false;
    public bool CanSleep = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = transform.GetComponentInParent<Animator>();
    }
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            _anim.SetBool("Move",false);
        }
        else
        {
            _anim.SetBool("Move", true);
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            _anim.Play("MoveRightLamp");
            transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
        }
        else if(Input.GetAxisRaw("Horizontal") == 1)
        {
            _anim.Play("MoveRightLamp");
            transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
        else if (Input.GetAxisRaw("Vertical") == -1)
        {
            _anim.Play("MoveFrontLamp");
        }
        else if(Input.GetAxisRaw("Vertical") == 1)
        {
            _anim.Play("MoveBackLamp"); 
        }


      
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        _moveVelocity = moveInput * Speed;
    }
    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position+_moveVelocity*Time.fixedDeltaTime);
    }
}
