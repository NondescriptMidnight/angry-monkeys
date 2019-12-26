using UnityEngine;
using System.Collections;

public class Repeat : MonoBehaviour {

	// Use this for initialization
	void Start () {

	
	
	}


	void OnMouseDown() {


		//GameManager.lvl = 0;

		Application.LoadLevel (0);  

	}
	
	// Update is called once per frame
	void Update () {

	

		if (Input.touchCount > 0) {

			//GameManager.lvl = 0;

			Application.LoadLevel (0);  
		}

	
	} 
}
