using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	Vector3 offsets;
	public GameObject target;

	// Use this for initialization
	void Start () {
		offsets = target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.transform.position - offsets;
	}
}
