using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehavior : MonoBehaviour {

	public float speed;
	public int type = 0;

	float timer = 1.0f;
	bool onFly = true;

	// Use this for initialization
	void Start () {
		
	}

	public void Hit(){
		onFly = false;
		//todo : destroy this
		Destroy(this.gameObject);
	}

	void viewUpdate(){
		if (type == 0)
			this.GetComponent<SpriteRenderer> ().color = new Color (1f, 0.4f, 0.4f, 1f);
		else
			this.GetComponent<SpriteRenderer> ().color = new Color(0.4f,0.4f,1f,1f);
	}

	// Update is called once per frame
	void Update () {
		viewUpdate ();
		if (onFly) {
			this.transform.Translate (0, speed * Time.deltaTime, 0);
		}
		timer -= Time.deltaTime;
		if (timer < 0) {
			Destroy (this.gameObject);
		}
	}
}
