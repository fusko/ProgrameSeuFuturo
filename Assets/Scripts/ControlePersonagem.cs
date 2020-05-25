using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlePersonagem : MonoBehaviour
{
    public float velocidade;              
    public Vector3 movimentoHorizontal;
    private Rigidbody2D rb2d;        

    public float gravity;
    public float forcaPulo;
    public SpriteRenderer spriteRenderer;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    void Update() {
        Movimentar();
        Pular();
    }

    
     public void Movimentar()
    {
       
       
        movimentoHorizontal = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        if  (movimentoHorizontal.x > 0.01f){
            spriteRenderer.flipX = false;
        }
        else if (movimentoHorizontal.x < -0.01f){
            spriteRenderer.flipX = true;
        }
        transform.position += movimentoHorizontal * Time.deltaTime * velocidade;
        
    }

    public void Pular(){
        if(Input.GetButtonDown("Jump")){
            rb2d.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
        }
    }


}
