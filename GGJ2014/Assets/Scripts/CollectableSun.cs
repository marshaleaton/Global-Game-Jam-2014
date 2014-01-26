using UnityEngine;
using System.Collections;

public class CollectableSun : MonoBehaviour {
	public float timer = 0.0f;
	public float delay = 5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > delay) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == "Player") {
			Destroy (gameObject);
		}
	}

}
