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

    void Start()
    {

        m_rigidbody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        if (forwardSpeed < maxSpeed)
            forwardSpeed += 0.1f * Time.deltaTime;

        float horizontal = Input.GetAxis("Horizontal");

        direction.Set(horizontal, 0);

        direction.Normalize(); ;




    }

    private void FixedUpdate()
    {
        print("andando");
        m_rigidbody.MovePosition(m_rigidbody.position + direction * forwardSpeed * Time.deltaTime);
    }
}
