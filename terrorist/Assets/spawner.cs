using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
	
	public GameObject guy;
	public GameObject droga0;
	public GameObject droga1;
	public GameObject droga2;
	public GameObject droga3;
	public GameObject most;
	public GameObject current;
	public Transform spawn;
	public Transform destroyer;
	public Transform kierowca;
	public Transform cam;
	public WheelJoint2D[] kola;
	public float time = 1.2f;
	public float size;
	float total=0;
	public int a = 1000;
	float ped;
	float totalz = 0;
	int x;

	void Start(){
		GameObject first = Instantiate(droga0, new Vector2(0,0), Quaternion.identity)as GameObject;
		total += 1;
		current = first;
		StartCoroutine (spawn_guys());
	}
	void Update(){
		float speed = Input.GetAxisRaw ("Horizontal");
		if (speed == 1) {
			ped += Time.deltaTime*0.2f;
			Debug.Log (ped);
		} 
		else if (speed == -1) {
			ped -= Time.deltaTime*0.2f;
			speed = -speed;
		} 
		else {
			ped = 0;
		}
		if (speed == -1) {
			ped += Time.deltaTime*0.2f;
		} 
		if (ped > 1) {
			ped = 1;
		} 
		else if (ped < -1) {
			ped = -1;
		}
		JointMotor2D motor = new JointMotor2D{ motorSpeed = speed * a*ped, maxMotorTorque = 2000 };
		for(int i = 0;i< 5;i++) {
			kola [i].motor = motor;
		}
		x = (int)(Random.value * 15);
		spawn.position = gameObject.transform.position + new Vector3(17,0,0);
		destroyer.position = gameObject.transform.position - new Vector3(20,10,0);
		cam.rotation = Quaternion.identity;
		kierowca.rotation = gameObject.transform.rotation;
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
				if (x >= 5) {
					obj = Instantiate (droga0, new Vector2 (c+size-0.1f, totalz), Quaternion.identity)as GameObject;
				} else if (x == 3) {
					obj = Instantiate (most, new Vector2 (c+size-0.1f+3.5f, totalz - 0.2f), Quaternion.identity)as GameObject;
				} else if (x > 3 && x < 5) {
					obj = Instantiate (droga1, new Vector2 (c+size-0.1f, totalz), Quaternion.identity)as GameObject;
					totalz -= 2.1f;
				} else if (x == 2){
					obj = Instantiate (droga3, new Vector2 (c+size-0.1f, totalz+2.1f), Quaternion.identity)as GameObject;
					totalz += 2.1f;
				} else if (x <= 1) {
					obj = Instantiate (droga2, new Vector2 (c+size-0.1f, totalz), Quaternion.identity)as GameObject;
				}
				current = obj;
			}
		}
	}
}
