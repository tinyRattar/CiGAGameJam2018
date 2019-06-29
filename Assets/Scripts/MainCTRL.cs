using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCTRL : MonoBehaviour {
	
	public int life;
	public int speed;

	[SerializeField]bool ableMove = true;
	[SerializeField]PlayerBehavior playerL;
	[SerializeField]PlayerBehavior playerR;

	float fireTimer = 0f;
	float fireCDTime = 1f;



	// Use this for initialization
	void Start () {
		
	}

	public void lifeChange(int value){
		life += value;
		if (life > 3)
			life = 3;
		if (life < 0)
			life = 0;
	}

	void LeftCTRL(){
		if (Input.GetKeyDown (KeyCode.A)) {
			playerL.move (true);
		} else if (Input.GetKeyDown (KeyCode.D)) {
			playerL.move (false);
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			playerL.shieldSwitch ();
			playerR.shieldSwitch ();
		}
	}

	void RightCTRL(){
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			playerR.move (true);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			playerR.move (false);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (fireTimer <= 0) {
				playerL.fire ();
				playerR.fire ();
				fireTimer = fireCDTime;
			}
		}
	}

	void AutoMove(){
		this.transform.Translate (new Vector3 (0, speed * Time.deltaTime, 0));
	}

	// Update is called once per frame
	void Update () {
		if (!ableMove)
			return;
		LeftCTRL ();
		RightCTRL ();
		AutoMove ();
		if (fireTimer > 0)
			fireTimer -= Time.deltaTime;
	}
}
