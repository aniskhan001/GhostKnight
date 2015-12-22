using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public float maxSpeed = 2.0f;
    public bool facingRight = true;
    public float moveDirectionX;
    public float moveDirectionY;
    public float gravitySpeed;

    // Use this for initialization
    void FixedUpdate () {
        GetComponent<Rigidbody>().velocity = new Vector2(moveDirectionX * maxSpeed, moveDirectionY * maxSpeed);

        if (moveDirectionX < 0.0f && facingRight) // player tries to go to the left (-ve) and facing right
            Flip();
        else if (moveDirectionX > 0.0f && !facingRight) // player tries to go to the right (+ve) and facing left
            Flip();
    }
	
	// Update is called once per frame
	void Update () {
        moveDirectionY = Input.GetAxis("Vertical");
        moveDirectionX = Input.GetAxis("Horizontal");
    }

    void Flip () {
        facingRight = !facingRight;

        transform.Rotate(Vector3.up, 180.0f, Space.World);
    }
}
