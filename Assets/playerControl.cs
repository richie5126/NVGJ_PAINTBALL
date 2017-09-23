using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerControl : MonoBehaviour
{

    // Use this for initialization
    private Rigidbody2D rb;

    public float walkSpeed = 6f;
    public float acceleration = 1.0f;
    public float jumpForce = 100f;

    public Color colorOfSpeed = Color.red;
    public Color colorOfJump = Color.blue;
    public Color colorOfWallJump = Color.green;
    public Color colorOfNothing = Color.grey;

    public KeyCode jumpButton = KeyCode.W;
    public KeyCode resetLevel = KeyCode.R;
    public KeyCode resetState = KeyCode.Space;

    public float jumpsPossible = 2.0f;
    private float jumpsRemaining;


    public void ChangeColor(Color color)
    {
        if (gameObject.GetComponent<SpriteRenderer>() != null)
            gameObject.GetComponent<SpriteRenderer>().color = color;
    }

    public bool isGround = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = jumpsPossible;
        ChangeColor(colorOfNothing);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(resetState))
        {
            ChangeColor(colorOfNothing);
        }

        if (Input.GetKeyDown(resetLevel))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        if (Mathf.Abs(rb.velocity.x) > walkSpeed)
        {
            rb.AddForce(new Vector2(-rb.velocity.x * rb.mass, 0f));
        }
        //move player horizontally
        else if (Input.GetAxis("Horizontal") != 0 && Mathf.Abs(rb.velocity.x) <= walkSpeed)
        {
            rb.AddForce(new Vector2(acceleration * Input.GetAxis("Horizontal"), 0));
        }
        else if (isGround && Mathf.Abs(rb.velocity.x) > 0.0f)
        {
            rb.AddForce(new Vector2(-rb.velocity.x * rb.mass, 0f));
        }
        

        if (isGround && Input.GetKeyDown(jumpButton))
        {
            rb.AddForce(new Vector2(0, (-rb.velocity.y * rb.mass) + jumpForce));

            jumpsRemaining--;

            if (jumpsRemaining == 0)
                isGround = false;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isGround = true;
        jumpsRemaining = jumpsPossible;
    }
}