using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour {

	public GameObject firePoint;
	public List<GameObject> vfx = new List<GameObject>();
	public GameObject xAxis;
	public GameObject yAxis;

	private GameObject effectToSpawn;
	private float timeToFire = 0;

	
	void Start () {
		effectToSpawn = vfx[0];	
	}
	
	
	void Update () {
		bool shotState = false;
		float fire = Input.GetAxisRaw("Fire");
		if(fire != 0 && Time.time >= timeToFire){
			timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
			shotState = true;
			SpawnVFX(shotState);
		}
		shotState = false;
		
		
	}

	void SpawnVFX(bool shotState){
		GameObject vfx;
		if(firePoint != null){
			vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
			vfx.transform.localRotation = yAxis.transform.localRotation;
		}
		else{
			Debug.Log("No Fire Point");
		}
	}
}
