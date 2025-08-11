using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLimitController : MonoBehaviour
{
    public int jumpLimit = 3; 
    private int jumpCount = 0; 
    public KeyCode jumpKey = KeyCode.Space; 
    private bool isGrounded = false; 
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        if (Input.GetKeyDown(jumpKey))
        {
            jumpCount++;

            if (jumpCount > jumpLimit)
            {
                GameManager.gameManager.RuleBroken();
                return;
            }else
                Debug.Log("Jump limit rule is not broken!");
        }
    }
}
