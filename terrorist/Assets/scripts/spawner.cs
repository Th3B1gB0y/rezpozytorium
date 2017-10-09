using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class spawner : MonoBehaviour {
	
	public GameObject guy;
	public GameObject droga0;
	public GameObject droga1;
	public GameObject droga2;
	public GameObject droga3;
	public GameObject most;
	public GameObject budynek;
	public GameObject current;
	public GameObject menu;
	public Transform spawn;
	public Transform destroyer;
	public Transform kierowca;
	public Transform cam;
	public WheelJoint2D[] kola;
	public Text killstxt;
	public static int kills = 0;
	public float time = 1.2f;
	public float size;
	public Animator menu_anim;
	float origin_rozped = 1000;
	int rozped = 1000;
	bool over = false;
	float total=0;
	public int a = 1000;
	float ped;
	public float dist = 15;
	float totalz = 0;
	int x;
	int rand;
	int randx;
	bool teren = false;

	void Start(){
		GameObject first = Instantiate(droga0, new Vector2(0,0), Quaternion.identity)as GameObject;
		total += 1;
		current = first;
		menu.SetActive (false);
		StartCoroutine (spawn_guys());
	}
	void Update(){
		if (!over) {
			if (ped < 0) {
				rozped = (int)(origin_rozped + ped * origin_rozped + 300);
			} else {
				rozped = (int)(origin_rozped - ped * origin_rozped + 300);
			}
			gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.right * ped * rozped * Time.deltaTime);
			float speed = Input.GetAxisRaw ("Horizontal");
			killstxt.text = kills.ToString ();
			if (speed == 1) {
				ped += Time.deltaTime * 0.2f;
			} else if (speed == -1) {
				ped -= Time.deltaTime * 0.2f;
				speed = -speed;
			} else {
				ped = 0;
			}
			if (speed == -1) {
				ped += Time.deltaTime * 0.2f;
			} 
			if (ped > 1) {
				ped = 1;
			} else if (ped < -1) {
				ped = -1;
			}
			JointMotor2D motor = new JointMotor2D{ motorSpeed = speed * a * ped, maxMotorTorque = 2000 };
			for (int i = 0; i < 5; i++) {
				kola [i].motor = motor;
			}
		}
		if (Input.GetKey (KeyCode.R)&&!over) {
			over = true;
			menu.SetActive (true);
			menu_anim.SetTrigger ("over");
			StopAllCoroutines ();
		}
		x = (int)(Random.value * 15);
		rand = (int)(Random.value * 3);
		randx = (int)(Random.value * -3);
		destroyer.position = gameObject.transform.position - new Vector3 (20, 10, 0);
		cam.rotation = Quaternion.identity;
		kierowca.rotation = gameObject.transform.rotation;

		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
		if (hit.collider != null) {
			spawn.position = new Vector2 (gameObject.transform.localPosition.x + 17, hit.point.y-0.75f);
		}

		generate ();
	}
	IEnumerator spawn_guys(){
		for(int i = 0;i < Mathf.Infinity;i++) {
			Instantiate (guy, spawn.position, spawn.rotation);
			yield return new WaitForSeconds (1.2f);
		}
	}
	void generate(){
		if (current != null) {
			if (transform.localPosition.x > current.transform.localPosition.x - 20) {
				float c = current.transform.localPosition.x;
				if (current.name == "droga 2 2(Clone)") {
					c += 3.6f;
				}
				GameObject obj = null;
				GameObject bud = null;
				if (teren&&x==2) {
					x = 5;
					teren = false;
				}
				if (x >= 5) {
					obj = Instantiate (droga0, new Vector2 (c+size-0.1f, totalz), Quaternion.identity)as GameObject;
					bud = Instantiate (budynek, new Vector3 (c+size+randx, totalz+7 + (rand * 0.4f) , -dist*((-rand)*0.9f)), Quaternion.identity)as GameObject;
				} else if (x == 3) {
					obj = Instantiate (most, new Vector2 (c+size-0.1f+3.5f, totalz - 0.2f), Quaternion.identity)as GameObject;
				} else if (x > 3 && x < 5) {
					obj = Instantiate (droga1, new Vector2 (c+size-0.1f, totalz), Quaternion.identity)as GameObject;
					teren = true;
					totalz -= 2.1f;
				} else if (x == 2){
					obj = Instantiate (droga3, new Vector2 (c+size-0.1f, totalz+2.1f), Quaternion.identity)as GameObject;
					totalz += 2.1f;
				} else if (x <= 1) {
					obj = Instantiate (droga2, new Vector2 (c+size-0.1f, totalz), Quaternion.identity)as GameObject;
				}
				current = obj;
				if (bud != null) {
					bud.GetComponent<Renderer> ().sortingOrder = -rand - 3;
				}
			}
		}
	}
}
