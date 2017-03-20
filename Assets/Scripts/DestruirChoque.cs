using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirChoque : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerExit(Collider other){
		if (other.tag == "Frontera")
		{
			return;
		}

		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
		}
		
		Instantiate(explosion, other.transform.position, other.transform.rotation);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
