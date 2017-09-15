using UnityEngine;
using System.Collections;

public class InteractiveController : MonoBehaviour {

	public bool isInteracting = false;
	private bool lastState = false;

	private Color DefaultColor = new Color (0, 0, 0, 0);
	private Color ChosenColor = new Color (1.0f, 1.0f, 1.0f, 0);

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(isInteracting != lastState){
			lastState = isInteracting;
			if (isInteracting == false) {
				GetComponent<Renderer> ().material.SetColor ("_RimColor", DefaultColor);
			} else {
				GetComponent<Renderer> ().material.SetColor ("_RimColor", ChosenColor);
			}
		}
	}
	
	void FixedUpdate(){
		if (Input.GetMouseButtonDown(0) && isInteracting) {
			if(this.transform.tag == "Door"){
				//Debug.Log("Door");
				Animator animator = GetComponent<Animator> ();
				animator.SetBool("open",!animator.GetBool("open"));
			}else if(this.transform.tag == "PickUp"){
				//Debug.Log("PickUp");
			}else if(this.transform.tag == "Button"){
				//Debug.Log("Button");
				Animator animator = GetComponent<Animator> ();
				animator.SetBool("down",!animator.GetBool("down"));
				if(animator.GetBool("down") == true){
					if(this.gameObject.name == "R"){
						GameController.RDown = true;
					}else if(this.gameObject.name == "G"){
						GameController.GDown = true;
					}else if(this.gameObject.name == "B"){
						GameController.BDown = true;
					}
				}else{
					if(this.gameObject.name == "R"){
						GameController.RDown = false;
					}else if(this.gameObject.name == "G"){
						GameController.GDown = false;
					}else if(this.gameObject.name == "B"){
						GameController.BDown = false;
					}
				}
			}
		}
	}


}
