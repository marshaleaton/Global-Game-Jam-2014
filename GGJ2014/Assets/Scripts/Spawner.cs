using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject[] enemies;
	public int triggerTime = 1;
	private float Timer = 0.0f;
	public float Overflow = 5.0f;
	public int scoreToStart = 0;
	public GameObject gameControl;
	// Use this for initialization
	void Start () {
		if (scoreToStart <= gameControl.GetComponent<GameContoller> ().getScore ()) {
			Instantiate (enemies[Random.Range (0,3)], gameObject.transform.position, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(scoreToStart <= gameControl.GetComponent<GameContoller>().getScore()){
			Timer += Time.deltaTime;
			if (Timer > triggerTime) {
				if(Random.value > .8){
					Instantiate (enemies[Random.Range (0,3)], gameObject.transform.position, Quaternion.identity);
				}
				Timer = 0.0f;
			}
			else if (Timer > Overflow){
				Instantiate (enemies[Random.Range (0,3)], gameObject.transform.position, Quaternion.identity);
				Timer = 0.0f;
			}
		}
	}
}
