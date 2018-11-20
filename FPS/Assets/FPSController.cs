using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class FPSController : MonoBehaviour {

	public float speed = 5f;
	public Text countText;

	private Transform cam;
	private Rigidbody rb;
	private Vector3 velocity = Vector3.zero;
	private float mouseSensitivity = 250f;
	private float verticalLookRotation;
	private Quaternion rotation;
	private int count;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		cam = Camera.main.transform;
		count = 0;
		SetCountText();
		
	}
	
	// Update is called once per frame
	void Update () {
		float xMov = Input.GetAxisRaw("Horizontal");
		float yMov = Input.GetAxisRaw("Vertical");
		float zMov = Input.GetAxisRaw("Jump");

		Vector3 movHorizontal = transform.right * xMov; //(1, 0, 0)
		Vector3 movVertical = transform.forward * yMov; // (0, 0, 1)
		Vector3 movUp = transform.up * zMov; // (0, 1, 0)
		velocity = (movHorizontal + movVertical + movUp).normalized * speed;

		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity);
		verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
		verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
		cam.localEulerAngles = Vector3.left * verticalLookRotation;
	}

	private void FixedUpdate(){
		if (velocity != Vector3.zero){
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		}
	}

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Pick up")){
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText(){
    	countText.text = "Count: " + count.ToString();
    }

	public float GetRotation(){
		return verticalLookRotation;
	}
}
