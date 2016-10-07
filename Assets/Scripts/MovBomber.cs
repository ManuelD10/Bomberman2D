using UnityEngine;
using System.Collections;

public class MovBomber : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	float velocidadMovimiento;


	void Update () {

	}

	void FixedUpdate(){
		velocidadMovimiento = 2;
		var movimiento = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		transform.position += movimiento * velocidadMovimiento * Time.deltaTime;
	}
}
