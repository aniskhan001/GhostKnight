using UnityEngine;
using System.Collections;

public class SwordDestructor : MonoBehaviour {
    public float lifeSpan = 3.0f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeSpan);
	}
	
}
