using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float JumpForce = 2.5f;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        walk();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider is BoxCollider2D)
        {
            if (collision.collider.tag == "Ground") //verifica se o personagem ta no chao
            {
                grounded = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.otherCollider is BoxCollider2D)
        {
            if (collision.collider.tag == "Ground")
            {
                grounded = false;
            }
        }
    }

    void walk()
    {
        //A: Captura Movimento de jogador
        movement.x = Input.GetAxisRaw("Horizontal"); //pega só o horizontal
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.velocity = Vector2.up * JumpForce; //faz pular
            grounded = false;
        }
        rb.transform.position = rb.position + movement * speed * Time.fixedDeltaTime; //movimenta o personagem
        if (movement.x != 0)
        {
            if (movement.x < 0)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);//rotaciona o personagem
            }
            else if (movement.x > 0)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }
}
