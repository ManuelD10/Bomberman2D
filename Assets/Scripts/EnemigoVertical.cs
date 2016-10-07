using UnityEngine;
using System.Collections;

public class EnemigoVertical : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	public float velocidadMovimiento;
	public float velocidadHorizontal;
	public float velocidadVertical;
	public bool positivoHorizontal;
	public bool positivoVertical;


	void Update () {

	}
		

	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == "pared_sup")
			
			positivoVertical = false;
		
		else if (coll.gameObject.tag == "pared_inf")
			
			positivoVertical= true;
		
		else if ((positivoVertical == true ) || (coll.gameObject.tag == "bloque_ind" ))
			
			positivoHorizontal = false;
		
		else if ((positivoVertical == false ) || (coll.gameObject.tag == "bloque_ind" ))
			
			positivoHorizontal = true;

	}





	void FixedUpdate(){

		velocidadMovimiento = 2;


		if (positivoVertical == true) {
			velocidadVertical = 1;
		} else if (positivoVertical == false) {
			velocidadVertical = -1;
		}

		var movimiento = new Vector3(velocidadHorizontal, velocidadVertical, 0);
		transform.position += movimiento * velocidadMovimiento * Time.deltaTime;


	}
}