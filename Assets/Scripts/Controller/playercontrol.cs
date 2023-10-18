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
    private Vector2 lookLeft, lookRight;

     void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        lookLeft = new Vector2(-1, 0);
        lookRight = new Vector2(1, 0);
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
    }

       private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BG")
        {

            onGround = true;
        }
    }

}
