using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;
    [SerializeField]
    private float forwardSpeed;
    [SerializeField]
    private float maxSpeed;
    private Vector2 direction;
    [SerializeField]
    private Animator m_animator;
    [SerializeField]
    private bool walking;
    private bool facingRight;
    [SerializeField]
    private float gravity;

    void Start()
    {
        Input.simulateMouseWithTouches = true;
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();

    }

    void Update()
    {
        
            print("yes");
            float horizontal = Input.GetAxis("Horizontal");

        walking = Mathf.Abs(horizontal) != 0 ? true : false;

            direction.Set(horizontal, gravity);

            direction.Normalize();

            Flip(horizontal);
        
    }

    private void FixedUpdate()
    {

        m_animator.SetBool("walk", walking);
        m_rigidbody.velocity=(direction * forwardSpeed * Time.deltaTime);

    }

    private void Flip(float horizontal)
    {
        if (horizontal < 0 && !facingRight || horizontal >0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }


    private float HandleInput()
    {
        if (Input.touchCount > 0)
        {
            float touch;
            touch = Input.GetTouch(0).position.x;
            return touch > Screen.width / 2 ? 1 : -1;
    }
    else
    {

            return Input.GetAxis("Horizontal");
    }
    }

}
