using UnityEngine;
using System.Collections;

public class camaraSigue : MonoBehaviour {
	
	public GameObject bomberman;
	public Transform tbomberman;

	float camaraX;

	Vector3 Velocidad = Vector3.zero;

	// Use this for initialization
	void Start () {
		tbomberman = GameObject.FindGameObjectWithTag("bomber").transform;
	}

	// Update is called once per frame
	void FixedUpdate () {


	//	Vector3 current = new  Vector3 (tbomberman.position.x, tbomberman.position.y,-1);
		Vector3 target = new Vector3(Mathf.Clamp(Time.deltaTime, 10.64F, -10.64F),6,-1);
	
	

	}
}
