using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {

	void OnTriggerExit2D(Collider2D ludz){
		Destroy (ludz.gameObject);
	}
}
