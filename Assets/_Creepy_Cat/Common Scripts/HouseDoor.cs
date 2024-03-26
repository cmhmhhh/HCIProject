using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDoor : MonoBehaviour {
	public float smooth = 2.0f;
	public float doorOpenAngle = 90.0f;
	public AudioSource myaudio;

	private float doorCloseAngle = 0.0f;
	private bool open = false;
	private bool enter = false;



	// Use this for initialization
	void Start () {
		myaudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		// Si ma porte est ouverte
		if(open == true) {
			Quaternion target = Quaternion.Euler (0 , doorOpenAngle , 0);
			transform.localRotation = Quaternion.Slerp (transform.localRotation, target, Time.deltaTime * smooth);
		}

		// Si ma porte est fermée
		if(open == false) {
			Quaternion target1 = Quaternion.Euler (0 , doorCloseAngle , 0);
			transform.localRotation = Quaternion.Slerp (transform.localRotation, target1, Time.deltaTime * smooth);
		}


	}

	void OnTriggerEnter(Collider other) {
		enter = true;
		open = true;

		myaudio.Play();
	}

	void OnTriggerExit(Collider other) {
		enter = false;
		open = false;

		myaudio.Play();
	}
}
