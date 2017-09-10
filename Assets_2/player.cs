using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	private Rigidbody2D rb;
	public float speed;
	public float offset;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		speed -= offset;
		if (speed < 0) {
			speed = 0;
		} else {
			rb.AddForce (transform.right * speed);
		}
	}
}
