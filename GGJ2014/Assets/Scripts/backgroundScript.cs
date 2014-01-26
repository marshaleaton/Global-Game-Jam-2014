using UnityEngine;
using System.Collections;

public class backgroundScript : MonoBehaviour {
	public GameObject[] bkgrounds;
	public int playerHP;
	// Use this for initialization
	void Start () {
		GameObject gameController = GameObject.Find("GameController");
		playerHP = gameController.GetComponent<GameContoller> ().getHealth();
		for (int i = 0; i < 5; i++) {
						Vector3 temp;
						if (playerHP == i) {
								temp = bkgrounds [i].gameObject.transform.position;
								temp.z = 1;
								bkgrounds [i].gameObject.transform.position = temp;
						} else {
								temp = bkgrounds [i].gameObject.transform.position;
								temp.z = 2;
								bkgrounds [i].gameObject.transform.position = temp;
						}
				}
	}
	
	// Update is called once per frame
	void Update () {
		GameObject gameController = GameObject.Find("GameController");
		playerHP = gameController.GetComponent<GameContoller> ().getHealth();
		for (int i = 0; i < 5; i++) {
			Vector3 temp;
			if(playerHP-1 == i){
				temp = bkgrounds[i].gameObject.transform.position;
				temp.z = 1;
				bkgrounds[i].gameObject.transform.position = temp;
			}
			else{
				temp = bkgrounds[i].gameObject.transform.position;
				temp.z = 2;
				bkgrounds[i].gameObject.transform.position = temp;
			}
		}
	}
}
