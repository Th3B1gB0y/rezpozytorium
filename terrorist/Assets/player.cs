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
			Debug.Log ("ooo!!!");
		}
	}
	void ded(){
		for (int i = 0; i < 10; i++) {
			anim.enabled = false;
			_rb[i].mass = 0.1f;
			_rb [i].isKinematic = false;
		}
	}
}
