using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlePersonagem : MonoBehaviour
{
    public float velocidade; 
     public float velocidadeMax;              
    public Vector3 movimentoHorizontal;
    private Rigidbody2D rb2d;        

    public float gravity;
    public float forcaPulo;
    public SpriteRenderer spriteRenderer;

    public Animator animator;
    public bool pulando;
    private float aceletacao;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    void Update() {
        Movimentar();
        Pular();
         Animacao();
    print(-velocidadeMax);
    }

    
     public void Movimentar()
    {
       
       
        movimentoHorizontal = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        aceletacao =Mathf.Lerp(aceletacao, velocidadeMax* movimentoHorizontal.x, 0.1f);
       Rotacionar();
        transform.position += Vector3.right * Time.deltaTime * aceletacao;
        
    }

    public void Pular(){
        if(Input.GetButtonDown("Jump") & pulando == false){//Nota:pode se subistituir "pulando == false" por "!pulando"
            rb2d.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
        }
    }

    public void Rotacionar(){
         if  (movimentoHorizontal.x > 0.01f){
            spriteRenderer.flipX = false;
        }
        else if (movimentoHorizontal.x < -0.01f){
            spriteRenderer.flipX = true;
        }
    }
    
    public void Animacao(){
        animator.SetFloat("velocidadeX",Mathf.Abs(movimentoHorizontal.x));
         animator.SetFloat("velocidadeY", rb2d.velocity.y);
   
        }
      
    private void OnCollisionEnter2D(Collision2D other) {
       if(other.gameObject.layer == 8){
           pulando = false;
           animator.SetBool("chao",true);
       } 
    }

    private void OnCollisionExit2D(Collision2D other) {
            if(other.gameObject.layer == 8){
           pulando = true;
            animator.SetBool("chao",false);
       } 
    }
    }

