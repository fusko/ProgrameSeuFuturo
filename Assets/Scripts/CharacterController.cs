using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    public float velocidade;              
    public Vector3 movimentoHorizontal;
    private Rigidbody2D rb2d;        

    public float gravity;
    public float forcaPulo;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Movimentar();
        Pular();
    }

    
     public void Movimentar()
    {
       
        movimentoHorizontal = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        transform.position += movimentoHorizontal * Time.deltaTime * velocidade;
        
    }

    public void Pular(){
        if(Input.GetButtonDown("Jump")){
            rb2d.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
        }
    }

}
