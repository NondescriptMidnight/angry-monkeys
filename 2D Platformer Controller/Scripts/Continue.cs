using UnityEngine;
using System.Collections;

public class Continue : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	void OnMouseDown() {


		Application.OpenURL("http://www.dddragon.cn/endgame.php"); 
		//Application.Quit();

	}
	
	// Update is called once per frame
	void Update () {



		if (Input.touchCount != 0) {
			Application.OpenURL("http://www.dddragon.cn/endgame.php");

			//Application.Quit();
		}
	
	} 


	void OnMouseOver() {


		//Application.OpenURL("http://www.dddragon.cn/endgame.php"); 
	//Application.Quit();

	}
}
