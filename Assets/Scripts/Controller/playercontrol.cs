using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] public float speed;
    [SerializeField] public float jumpSpeed;

    private bool onGround = false;
    private Vector2 lookLeft, lookRight;

     void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //OnCollisionEnter2D();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BG")
        {

            onGround = true;
        }
    }

}
