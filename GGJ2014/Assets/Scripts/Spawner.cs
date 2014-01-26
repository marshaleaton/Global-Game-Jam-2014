using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject[] enemies;
	public int triggerTime = 1;
	private float Timer = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Timer += Time.deltaTime;
		if (Timer > triggerTime) {
			if(Random.value > .8){
				Instantiate (enemies[Random.Range (0,3)], gameObject.transform.position, Quaternion.identity);
			}
			Timer = 0.0f;
		}
	}
}
