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
		velocidadMovimiento = 3;
		var movimiento = new Vector3(Mathf.Round(Input.GetAxis("Horizontal")), Mathf.Round(Input.GetAxis("Vertical")), 0);
		transform.position += movimiento * velocidadMovimiento * Time.deltaTime;
	}
}
