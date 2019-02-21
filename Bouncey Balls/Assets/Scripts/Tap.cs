using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour {

	public float force;
	public Rigidbody2D myRigidbody;
	public Transform pos;
	private Vector3 TPos;

	void Start(){
		float ran = Random.Range (-4, 4);
		while (ran < 3 && ran > -3) {
			ran = Random.Range (-4, 4);
		}
		myRigidbody.velocity = new Vector2 (ran,myRigidbody.velocity.y);
	}
	
	void Update () {
		if(GameController.controller.isPaused == false && GameController.controller.isStarted == true){
			pos = this.transform;
			for (int i = 0; i < Input.touchCount; ++i) {
				if (Input.GetTouch (i).phase == TouchPhase.Began) {
					TPos = Camera.main.ScreenToWorldPoint (Input.GetTouch (i).position);
					if (TPos.x < pos.position.x + 1.25f && TPos.x > pos.position.x - 1.25f) {
						if (TPos.y < pos.position.y + 1.5f && TPos.y > pos.position.y - 1.5f) {
							GameController.controller.taps += 1;
							myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0);
							myRigidbody.AddForce (new Vector2 (0, force));
						}
					}
				}
			}
		}
	}
	void OnCollisionEnter2D(Collision2D colObj){
		if(colObj.gameObject.tag == "Bottom"){
			myRigidbody.velocity = new Vector2 (0,0);
		}
	}
}
