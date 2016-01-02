using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public float maxSpeed = 5.0f;
    public bool facingRight = true;
    public float moveDirectionX;
    public float moveDirectionY;
    public float jumpSpeed = 700.0f;

    public bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    void Awake() {
        groundCheck = GameObject.Find("GroundCheck").transform;
    }
    
    void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        GetComponent<Rigidbody>().velocity = new Vector2(moveDirectionX * maxSpeed, GetComponent<Rigidbody>().velocity.y);

        if (moveDirectionX < 0.0f && facingRight) // player tries to go to the left (-ve) and facing right
            Flip();
        else if (moveDirectionX > 0.0f && !facingRight) // player tries to go to the right (+ve) and facing left
            Flip();
    }
	
	// Update is called once per frame
	void Update () {
        moveDirectionX = Input.GetAxis("Horizontal");

        if (grounded && Input.GetButtonDown("Jump"))
            GetComponent<Rigidbody>().AddForce(new Vector2(0, jumpSpeed));
    }

    void Flip () {
        facingRight = !facingRight;

        transform.Rotate(Vector3.up, 180.0f, Space.World);
    }
}
