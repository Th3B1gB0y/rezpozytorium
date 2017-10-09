using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class player : MonoBehaviour {

	private Rigidbody2D rb;
	public Rigidbody2D[] _rb;
	private Animator anim;
	public float speed;
	public static bool dead = false;
	List<GameObject> obj = new List<GameObject>();

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Update () {
		rb.AddForce (transform.right * speed);
		rb.AddForce (transform.up * 0.5f);
		foreach (GameObject ob in obj) {
			if (ob == null) {
				obj.Remove(ob);
			}
		}
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
		if (hit.collider != null) {
			if (hit.distance < 0.2f) {
				rb.AddForce (transform.up * 2);
			}
			if (hit.distance > 0.4f) {
				rb.AddForce (-transform.up * 10);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col){
			if (col.tag == "tir") {
			int i = 0;
			foreach (GameObject ob in obj) {
				if (ob == gameObject) {
					i += 1;
				}
			}
			if (i == 0) {
				obj.Add (gameObject);
				spawner.kills += 1;
				ded ();
			}
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
