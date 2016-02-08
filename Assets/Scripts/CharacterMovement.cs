using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public float maxSpeed = 5.0f;
    public bool facingRight = true;
    public float moveDirectionX;
    public float moveDirectionY;
    public float jumpSpeed = 700.0f;
    public bool doubleJump = false;

    public bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    public float swordSpeed = 300.0f;
    public Transform swordSpawn;
    public Rigidbody swordPrefab;

    Rigidbody clone;

    void Awake() {
        groundCheck = GameObject.Find("GroundCheck").transform;
        swordSpawn = GameObject.Find("SwordSpawn").transform;
    }
    
    void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        GetComponent<Rigidbody>().velocity = new Vector2(moveDirectionX * maxSpeed, GetComponent<Rigidbody>().velocity.y);

        if (grounded)
            doubleJump = false;

        if (moveDirectionX < 0.0f && facingRight) // player tries to go to the left (-ve) and facing right
            Flip();
        else if (moveDirectionX > 0.0f && !facingRight) // player tries to go to the right (+ve) and facing left
            Flip();
    }
	
	// Update is called once per frame
	void Update () {
        moveDirectionX = Input.GetAxis("Horizontal");

        if ((grounded || !doubleJump) && Input.GetButtonDown("Jump")) {
            //Destroy(clone);
            GetComponent<Rigidbody>().AddForce(new Vector2(0, jumpSpeed));

            if (!doubleJump && !grounded)
                doubleJump = true;
        }

        if ( Input.GetButtonDown("Fire1") ) {
            Attack();
        }
    }

    void Flip () {
        facingRight = !facingRight;
        //transform.Rotate(Vector3.up, 180.0f, Space.World); // make this more efficient
        Vector3 _rotation = transform.localScale;
        _rotation.x *= -1;
        transform.localScale = _rotation;
    }

    void Attack () {
        clone = Instantiate(swordPrefab, swordSpawn.position, swordSpawn.rotation) as Rigidbody;
        //clone = Instantiate(swordPrefab) as Rigidbody;
        if (facingRight)
            clone.AddForce(swordSpawn.transform.right * swordSpeed);
        else
            clone.AddForce(-swordSpawn.transform.right * swordSpeed);
        //Destroy(clone, 1);
    }
}
