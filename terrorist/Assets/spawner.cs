using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
	
	public GameObject guy;
	public GameObject droga;
	public GameObject droga2;
	public GameObject current;
	public Transform spawn;
	public Transform destroyer;
	public Transform kierowca;
	public Transform cam;
	public float time = 1.2f;
	public float size;
	float total=0;
	int x;

	void Start(){
		GameObject first = Instantiate(droga, new Vector2(0,0), Quaternion.identity)as GameObject;
		total += 1;
		current = first;
		StartCoroutine (spawn_guys());
	}
	void Update(){
		x = (int)(Random.value * 5);
		spawn.position = gameObject.transform.position + new Vector3(17,0,0);
		destroyer.position = gameObject.transform.position - new Vector3(0,10,0);
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
		if (transform.localPosition.x > current.transform.localPosition.x-20) {
			GameObject obj = null;
			if (x != 1) {
				obj = Instantiate (droga, new Vector2 (total * size, 0), Quaternion.identity)as GameObject;
			} 
			else {
				obj = Instantiate (droga2, new Vector2 (total * size, 0), Quaternion.identity)as GameObject;
			}
			current = obj;
			total += 1;
		}
	}
}
