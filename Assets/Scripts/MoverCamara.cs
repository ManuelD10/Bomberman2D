using UnityEngine;
using System.Collections;

public class MoverCamara : MonoBehaviour {
	private GameObject cam;
	Transform camara;
	private GameObject bom;
	Transform bomber;
	float posicionBomberX;
	float posicionCameraX;
	int velocidadHorizontal;

	int velocidadMovimiento;

	// Use this for initialization
	void Start () {
		camara = GameObject.FindGameObjectWithTag("Main Camera").transform;
		bomber = GameObject.FindGameObjectWithTag("Player").transform;
		velocidadMovimiento=1;
	}
	
	// Update is called once per frame
	void Update () {
		Posiciones();
		Movimiento();
	}
	void Movimiento()
	{
		if (posicionBomberX>7)
		{
			velocidadHorizontal=1;
			var movimiento = new Vector3(velocidadHorizontal, 0, 0);
			camara.transform.position += movimiento * velocidadMovimiento * Time.deltaTime;
		}
		else
		{
			velocidadHorizontal=-1;
			var movimiento = new Vector3(velocidadHorizontal, 0, 0);
			camara.transform.position += movimiento * velocidadMovimiento * Time.deltaTime;
		}	
	}

	void Posiciones ()
	{
		
		posicionBomberX=bomber.transform.localPosition.x;
		posicionCameraX=camara.transform.localPosition.x;

	}
}
