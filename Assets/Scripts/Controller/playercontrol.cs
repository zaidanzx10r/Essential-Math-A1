using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float horizontalInput;
    public float jumpInput;

    [SerializeField] public float speed;
    [SerializeField] public float jumpSpeed;

    private bool onGround = false;

     void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

     void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        float hMove = horizontalInput * speed * Time.deltaTime;

        _rb.velocity = new Vector2(hMove, _rb.velocity.y);

        if (horizontalInput < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalInput > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        jumpInput = Input.GetAxisRaw("Jump");

        float jMove = jumpInput * jumpSpeed * Time.deltaTime;


        if (onGround)
        {
            _rb.velocity = new Vector2(hMove, jMove);

            if (jumpInput >= 1)
            {
                onGround = false;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BG")
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BG")
        {
            onGround = false;
        }
    }
}
