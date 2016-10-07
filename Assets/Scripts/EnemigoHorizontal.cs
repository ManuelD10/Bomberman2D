using UnityEngine;
using System.Collections;

public enum TiposEnemigo
{
	Horizontal,
	Vertical,
	Sigue,
	BomberEnemigo
}

public class EnemigoHorizontal : MonoBehaviour {

	public TiposEnemigo miTipo;

	private GameObject jugador;
	public float velocidadMovimiento;
	public float velocidadHorizontal;
	public float velocidadVertical;
	public bool positivoHorizontal;
	public bool positivoVertical;

	// Use this for initialization
	void Start () {
		miTipo = TiposEnemigo.Horizontal;
		jugador = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () {
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "pared_der" )
			positivoHorizontal = false;
		else if (coll.gameObject.tag == "pared_izq")
			positivoHorizontal = true;
		else if ((positivoHorizontal == true ) || (coll.gameObject.tag == "bloque_ind" ))
			positivoHorizontal = false;
		else if ((positivoHorizontal == false ) || (coll.gameObject.tag == "bloque_ind" ))
			positivoHorizontal = true;
	}

	void FixedUpdate() 
	{
		velocidadMovimiento = 3;
		if (positivoHorizontal == true) {
			velocidadHorizontal = 1;
		} else if (positivoHorizontal == false) {
			velocidadHorizontal = -1;
		}

		var movimiento = new Vector3(velocidadHorizontal, velocidadVertical, 0);
		transform.position += movimiento * velocidadMovimiento * Time.deltaTime;
	}
}