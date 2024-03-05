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
    [SerializeField] GameObject particleDeath;
    [SerializeField] AudioClip audioClip;
    private AudioSource audioSource;
    [SerializeField] private GameObject enemyOne;
    public static bool enemyClose { get; private set; }
    

    private void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        rbSprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        enemyClose = enemyOne.transform.position.x - gameObject.transform.position.x > 8.25f;
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
        if (Input.GetKeyDown(MainMenu.JumpHotKey) && playerOnGround)
        {
            rbPlayer.AddForce(Vector3.up * jumpForce);
            audioSource.PlayOneShot(audioClip, 1f);
            playerOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
            playerOnGround = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(particleDeath, gameObject.transform.position, gameObject.transform.rotation);
            gameObject.SetActive(false);
        }
    }
}