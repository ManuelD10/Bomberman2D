using UnityEngine;
using System.Collections;


public class Patrullar : MonoBehaviour {

	private GameObject jugador;
	Transform bomber;
	public float velocidadMovimiento;
	public float velocidadHorizontal;
	public float velocidadVertical;
	public bool positivoHorizontal;
	public bool positivoVertical;
	public float posicionBomberY;
	public float posicionMiaY;
	public float posicionBomberX;
	public float posicionMiaX;


	// Use this for initialization
	void Start () {
		bomber = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update () {
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{

		if (positivoHorizontal == false)
			positivoHorizontal=true;
		else if (positivoHorizontal == true)
			positivoHorizontal=false;
		else if (positivoVertical == false)
			positivoVertical=true;
		else
			positivoVertical=false;

	}

	void FixedUpdate() 
	{


		posicionBomberY=Mathf.Round(bomber.transform.position.y);
		posicionMiaY=Mathf.Round(transform.position.y);
		posicionBomberX=Mathf.Round(bomber.transform.position.x);
		posicionMiaX=Mathf.Round(transform.position.x);
		Debug.Log (posicionBomberY);
		Debug.Log (posicionMiaY);

	

		if (posicionBomberY==posicionMiaY) {
			velocidadMovimiento = 1;

		} else {
			velocidadMovimiento = 1;
		}


		if (posicionBomberX == posicionMiaX)
		{
			if (posicionBomberY > posicionMiaY) {
				velocidadVertical = 3;
			} else {
				velocidadVertical = -3;
			}
		//	positivoVertical = true;
		//	velocidadHorizontal = 0;
		} 
		else if (posicionBomberY == posicionMiaY)
		{
			if (posicionBomberX > posicionMiaX) {
				velocidadHorizontal = 3;
			} else {
				velocidadHorizontal = -3;
			}
		//	positivoHorizontal = true;
		//	velocidadVertical = 0;

		}
		else
		{
			if (positivoHorizontal == true) {
				velocidadHorizontal = 1;
			} else if (positivoHorizontal == false) {
				velocidadHorizontal = -1;
			} else if (positivoVertical == true) {
				velocidadVertical = 1;
			} else {
				velocidadVertical = -1;
			}
		}

		var movimiento = new Vector3(velocidadHorizontal, velocidadVertical, 0);
		transform.position += movimiento * velocidadMovimiento * Time.deltaTime;
	}
}