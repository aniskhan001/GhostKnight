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
        //gravitySpeed = Physics.gravity.y * 1.5;
        GetComponent<Rigidbody>().AddForce(3 * Physics.gravity);
    }
	
	// Update is called once per frame
	void Update () {
        moveDirectionY = Input.GetAxis("Vertical");
        moveDirectionX = Input.GetAxis("Horizontal");
    }
}
