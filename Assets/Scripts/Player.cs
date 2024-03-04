using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 2f;
    private bool playerOnGround = true;
    private Rigidbody rbPlayer;
    private SpriteRenderer rbSprite;
    private bool lookOnRight = true;
    

    private void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        rbSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * speed);
            if (!lookOnRight)
            {
                rbSprite.flipX = false;
                lookOnRight = true;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed); 
            if(lookOnRight)
            {
                rbSprite.flipX = true;
                lookOnRight = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && playerOnGround)
        {
            rbPlayer.AddForce(Vector3.up * jumpForce);
            playerOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
            playerOnGround = true;
    }
}
