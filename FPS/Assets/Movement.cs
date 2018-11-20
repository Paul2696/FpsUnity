using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

	private float angle = 0;
	private int radius = 10;
	public float delay = 1;

	public int life = 0;
	public Text winText;

	// Update is called once per frame
	void Update () {
		float x = 0;
		float z = 0;


		Vector2 direction = Vector3.zero;

		x = radius * Mathf.Cos(angle);
		z = radius * Mathf.Sin(angle);

		transform.position = new Vector3(x, 1, z);
		transform.Rotate(Vector3.up * -Time.deltaTime, Space.World);

		angle += 15 * Mathf.Deg2Rad * Time.deltaTime;

	}

	void OnCollisionEnter(Collision co){
		if(co.gameObject.tag == "Bullet"){
			life++;
			if(life == 10){
				Destroy(gameObject);
				winText.text = "Victoria!";

			}
		}

	}
}
