using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject enemigo;
	public Vector3 spawnValues;
	public int cuentaEnemigos;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnEnemigos());
	}
	
	
	IEnumerator SpawnEnemigos () {
		yield return new WaitForSeconds (startWait);
		while (true){	
			for (int i =0; i<cuentaEnemigos;i++){
				Vector3 spawnPos = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Instantiate(enemigo, spawnPos, Quaternion.identity);
				yield return new WaitForSeconds (spawnWait);	
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}
