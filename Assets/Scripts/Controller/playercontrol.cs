using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _moveDirection;

    public float horizontalImput;
    public float jumpInput;

    [SerializeField] public float speed = 1f;
    [SerializeField] public float jumpSpeed = 1f;

    private bool onGround = false;
    private Vector2 lookLeft, lookRight;

    // Start is called before the first frame update
    void Start()
    {
        InputActions.Init(this);
        InputActions.SetControls();

     _rb = GetComponent<Rigidbody2D>();

        lookLeft = new Vector2(-0.5f,0); //add x,y axises
        lookRight = new Vector2(0.5f,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += (Vector3) (speed * Time.deltaTime * _moveDirection);

        horizontalImput = Input.GetAxisRaw("Horizontal");

        float hMove = horizontalImput * speed * Time.deltaTime;

        _rb.velocity = new Vector2(hMove, _rb.velocity.y);

        if(horizontalImput < 0)
        {
            transform.Translate (new Vector3 (hMove, 0));
            if (horizontalImput <0.5f)
            {
                lookRight = lookLeft;   
            }
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

    public void SetMovementDirection(Vector2 currentDirection)
    {
        _moveDirection = currentDirection;
    }

    public void Jump()
    {
        Debug.Log("Jumped Called");
        if (onGround && !onGround)
        {
            Debug.Log("I jumped");
            _rb.AddForce(Vector2.up * jumpInput, ForceMode2D.Impulse);
        }
    }

    private void CheckGround()
    {
        onGround = Physics2D.Raycast(transform.position, Vector3.down, GetComponent<Collider>().bounds.size.y);
        Debug.DrawRay(transform.position, Vector3.down * GetComponent<Collider>().bounds.size.y, Color.red, 0, false);
    }
}
