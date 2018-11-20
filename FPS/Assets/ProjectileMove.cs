using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour {

	public float speed;
	public float fireRate;
	public GameObject muzzlePrefab;

	// Use this for initialization
	void Start () {
		if(muzzlePrefab != null){
			var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
			muzzleVFX.transform.forward = gameObject.transform.forward;
			var psMuzzle = muzzleVFX.GetComponent<ParticleSystem>();
			if(psMuzzle != null){
				Destroy(muzzleVFX, psMuzzle.main.duration);
			}
			else{
				var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
				Destroy(muzzleVFX, psChild.main.duration);
			}
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(speed != 0){
			transform.position += transform.forward * (speed * Time.deltaTime);
		}
		else{
			Debug.Log("No Speed");
		}
		
	}

	void OnCollisionEnter(Collision co){
		speed = 0;
		Destroy(gameObject); 
	}

}
