using UnityEngine;
using System.Collections;

public class SunBeamController : MonoBehaviour {
	public int direction;
	public float speed;
	private Vector3 moveDirection = Vector3.zero;
	// Use this for initialization
	void Start () {

	}
	public void setDir(int dir){
		direction = dir;
		moveDirection = new Vector3 (direction * speed, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (moveDirection);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Wall") {
			direction *= -1;
		}
		Destroy (gameObject);
	}
}
