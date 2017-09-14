using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

	public Transform spawn;
	public GameObject guy;
	float time=0;

	void Update () {
		time += Time.deltaTime;
		if (time > 1) {
			time = 0;
			Instantiate (guy, spawn.position, spawn.rotation);
		}
	}
}
