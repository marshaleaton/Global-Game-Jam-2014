using UnityEngine;
using System.Collections;

public class SunSpawner : MonoBehaviour {
	public GameObject gameCont;
	public float[] probabilities;
	public GameObject sun;
	public GameObject currentSun;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		generateSuns ();
	}

	void generateSuns(){
		if(currentSun == null){
			int hp = gameCont.GetComponent<GameContoller> ().getHealth ();
			if(hp <= 0){hp = 1;}
			if (Random.value <= probabilities[hp-1]) {
			currentSun = (GameObject) Instantiate (sun, gameObject.transform.position, Quaternion.identity);
			}
		}
	}
}
