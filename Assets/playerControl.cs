using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerControl : MonoBehaviour
{

    // Use this for initialization
    private Rigidbody2D rb;

    public float walkSpeed = 6f;
	public float redSpeed = 18.0f;
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
	private int currentState = 0;
	private float trueWalkSpeed;
	public int getCurrentState(){
		return currentState;
	}
	public Color getCurrentColor()
	{
		if (currentState == 1)
			return colorOfSpeed;
		if (currentState == 2)
			return colorOfJump;
		if (currentState == 3)
			return colorOfWallJump;

		return colorOfNothing;
	}
    public void ChangeColor(Color color)
    {
		if (color.Equals (colorOfSpeed)) {
			currentState = 1;

			GetComponent<TrailRenderer> ().material.SetColor ("_TintColor", colorOfSpeed);
			GetComponent<ParticleSystemRenderer>().material.SetColor("_TintColor", colorOfSpeed);
		}
		if (color.Equals (colorOfJump)) {

			GetComponent<TrailRenderer> ().material.SetColor ("_TintColor", colorOfJump);
			GetComponent<ParticleSystemRenderer>().material.SetColor("_TintColor", colorOfJump);
			currentState = 2;
		}
		if (color.Equals (colorOfWallJump)) {
			currentState = 3;
			GetComponent<TrailRenderer> ().material.SetColor ("_TintColor", colorOfWallJump);
			GetComponent<ParticleSystemRenderer> ().material.SetColor ("_TintColor", colorOfWallJump);
		}
		
        if (gameObject.GetComponent<SpriteRenderer>() != null)
            gameObject.GetComponent<SpriteRenderer>().color = color;
		
    }


	public void ChangeColor(int pState)
	{
		if (pState == 1) {
			ChangeColor (colorOfSpeed);
		}
		if (pState == 2) {
			ChangeColor (colorOfJump);
		}
		if(pState == 3)
			ChangeColor(colorOfWallJump);
	}

    public bool isGround = true;

    void Start()
    {
		trueWalkSpeed = walkSpeed;
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = jumpsPossible;
        ChangeColor(colorOfNothing);
    }

    // Update is called once per frame
    void Update()
    {


		if (currentState == 2)
			jumpsPossible = 2;
		else
			jumpsPossible = 1;
		
        if (Input.GetKeyDown(resetState))
        {
            ChangeColor(colorOfNothing);
        }
		if (currentState == 1)
			trueWalkSpeed = redSpeed;
		else
			trueWalkSpeed = walkSpeed;

        if (Input.GetKeyDown(resetLevel))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        if (Mathf.Abs(rb.velocity.x) > trueWalkSpeed)
        {
            rb.AddForce(new Vector2(-rb.velocity.x * rb.mass, 0f));
        }
        //move player horizontally
        else if (Input.GetAxis("Horizontal") != 0 && Mathf.Abs(rb.velocity.x) <= trueWalkSpeed)
        {
            rb.AddForce(new Vector2(acceleration * Input.GetAxis("Horizontal"), 0));
        }
        else if (isGround && Mathf.Abs(rb.velocity.x) > 0.0f)
        {
            rb.AddForce(new Vector2(-rb.velocity.x * rb.mass, 0f));
        }
        

        if (isGround && Input.GetKeyDown(jumpButton))
        {
			GetComponent<ParticleSystem>().Emit(10);
			rb.velocity = new Vector2 (rb.velocity.x, 0.0f);

            rb.AddForce(new Vector2(0, jumpForce));

            jumpsRemaining--;

            if (jumpsRemaining == 0)
                isGround = false;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
		if(other.collider.tag.Equals("ground"))
		{
        isGround = true;
		jumpsRemaining = jumpsPossible;
		}

		if (other.collider.tag.Equals ("jumpable_wall") && currentState == 3) 
		{
			isGround = true;
			jumpsRemaining = jumpsPossible;
		}
        

    }
}