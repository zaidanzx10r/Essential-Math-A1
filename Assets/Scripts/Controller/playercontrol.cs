using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float horizomtalInput;
    public float jumpInput;

    [SerializeField] public float speed = 1f;
    [SerializeField] public float jumpSpeed = 1f;

    private bool onGround = false;
    private Vector2 lookLeft, lookRight;

    // Start is called before the first frame update
    void Start()
    {
     _rb = GetComponent<Rigidbody2D>();

        lookLeft = new Vector2(); //add x,y axises
        lookRight = new Vector2();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizomtalInput = Input.GetAxisRaw("Horizontal");

        float hMove = horizomtalInput * speed * Time.deltaTime;

        _rb.velocity = new Vector2(hMove, _rb.velocity.y);

        if(horizomtalInput < 0)
        {
            //flip sprite
        }
        else
        {

        }

        jumpInput = Input.GetAxisRaw("Jump");

        if (onGround)
        {
            if (jumpInput >= 1)
            {
                //set y-axis of velocity to be jump speed
                onGround = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BG")
        {
            //set y-axis to 0
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
