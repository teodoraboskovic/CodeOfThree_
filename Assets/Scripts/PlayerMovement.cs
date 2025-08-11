using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField]private float speed;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput *speed, body.velocity.y);
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }else if(horizontalInput <- 0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        if (Input.GetKey(KeyCode.Space)&& isGrounded())
        {
            jump();
        }
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
    }
    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    
    }
    private bool isGrounded()
    {
        RaycastHit2D rayCastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0,Vector2.down,0.1f,groundLayer);
        return rayCastHit.collider!=null;
    }
    private bool hittingWall()
    {
        RaycastHit2D rayCastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, wallLayer);
        return rayCastHit.collider != null;
    }

}
