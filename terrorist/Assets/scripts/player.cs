using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	private Rigidbody2D rb;
	public Rigidbody2D[] _rb;
	private Animator anim;
	public float speed;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Update () {
		rb.AddForce (transform.right * speed);
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "tir") {
			ded ();
		}
	}
	void ded(){
		anim.enabled = false;
		for (int i = 0; i < 10; i++) {
			if (_rb [i] != null) {
				_rb [i].mass = 0.1f;
				_rb [i].isKinematic = false;
			} 
		}
	}
}
