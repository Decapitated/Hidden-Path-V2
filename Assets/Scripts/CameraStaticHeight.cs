using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStaticHeight : MonoBehaviour {
	GameObject target;
	// Use this for initialization
	void Start () {
		target = GameObject.Find("Sphere");
	}
		
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3(target.transform.position.x - 3.6f, transform.position.y, target.transform.position.z - 3.6f);
	}
}
