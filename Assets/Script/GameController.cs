using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public float INTERACTIVE_DISTANCE = 3.0f;
	public GameObject interactObj = null;

	//Button Control
	public static bool RDown = false;
	public static bool GDown = false;
	public static bool BDown = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape)){
			Application.Quit(); 
		}



		Cursor.lockState = CursorLockMode.Locked;

		//Cursor.visible = false;

		//resetItemShader ();

		//Color color = new Color (0, 0, 0, 0);
		//GameObject[] interactives = GameObject.FindGameObjectsWithTag ("Interactive");
		//for(int i=0;i<interactives.Length;i++){
		//	interactives[i].GetComponent<Renderer> ().material.SetColor ("_RimColor", color);
		//}

		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit rayHit;
		if (Physics.Raycast (mouseRay, out rayHit)) {
			//当弹道碰撞到物体时触发If语句中的内容
			float d = Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, rayHit.transform.position);
			//Debug.Log(d);
			//if(interactObj != rayHit.collider.gameObject){
				//if(interactObj != null){
				//	Color color = new Color (0, 0, 0, 0);
				//	interactObj.GetComponent<Renderer> ().material.SetColor ("_RimColor", color);
				//}

			if(interactObj != rayHit.collider.gameObject && interactObj!=null){
				interactObj.GetComponent<InteractiveController>().isInteracting = false;
			}

			if ((rayHit.transform.tag == "Door"||rayHit.transform.tag == "PickUp"||rayHit.transform.tag =="Button") && d < INTERACTIVE_DISTANCE) {
				interactObj = rayHit.collider.gameObject;
				//Color color = new Color (1.0f, 1.0f, 1.0f, 0);
				//interactObj.GetComponent<Renderer> ().material.SetColor ("_RimColor", color);
				interactObj.GetComponent<InteractiveController>().isInteracting = true;
				Debug.Log(interactObj);
			}


			//else{
			//		interactObj.GetComponent<InteractiveController>().isInteracting = false;
			//		Color _color = new Color (0, 0, 0, 0);
			//		interactObj = null;
			//	}
			//}

		}

		//Button Control
		ButtonResultControl();
	}

	void FixedUpdate () {

	}

	/*
	void resetItemShader(){
		Color color = new Color (0, 0, 0, 0);

		GameObject[] doors = GameObject.FindGameObjectsWithTag ("Door");
		for(int i=0;i<doors.Length;i++){
			doors[i].GetComponent<Renderer> ().material.SetColor ("_RimColor", color);
		}
		GameObject[] pickUps = GameObject.FindGameObjectsWithTag ("PickUp");
		for(int i=0;i<pickUps.Length;i++){
			pickUps[i].GetComponent<Renderer> ().material.SetColor ("_RimColor", color);
		}
		GameObject[] interactives = GameObject.FindGameObjectsWithTag ("Button");
		for(int i=0;i<interactives.Length;i++){
			interactives[i].GetComponent<Renderer> ().material.SetColor ("_RimColor", color);
		}

	}
	*/

	//Button Control
	void ButtonResultControl(){
		if (RDown == true && GDown == true && BDown == true) {
			GameObject.Find("Monitor").GetComponent<Renderer>().material.color = Color.white;
		}else if (RDown == false && GDown == true && BDown == true) {
			GameObject.Find("Monitor").GetComponent<Renderer>().material.color = Color.cyan;
		}else if (RDown == true && GDown == false && BDown == true) {
			GameObject.Find("Monitor").GetComponent<Renderer>().material.color = Color.magenta;
		}else if (RDown == true && GDown == true && BDown == false) {
			GameObject.Find("Monitor").GetComponent<Renderer>().material.color = Color.yellow;
		}else if (RDown == false && GDown == false && BDown == true) {
			GameObject.Find("Monitor").GetComponent<Renderer>().material.color = Color.blue;
		}else if (RDown == false && GDown == true && BDown == false) {
			GameObject.Find("Monitor").GetComponent<Renderer>().material.color = Color.green;
		}else if (RDown == true && GDown == false && BDown == false) {
			GameObject.Find("Monitor").GetComponent<Renderer>().material.color = Color.red;
		}else if (RDown == false && GDown == false && BDown == false) {
			GameObject.Find("Monitor").GetComponent<Renderer>().material.color = Color.black;
		}
	}
}
