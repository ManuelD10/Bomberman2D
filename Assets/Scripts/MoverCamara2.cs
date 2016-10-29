using UnityEngine;
using System.Collections;

public class MoverCamara2 : MonoBehaviour {
	Transform bomber;
	float posicionBomberX; 
	float posicionCameraX;
	int velocidadHorizontal;
	int velocidadMovimiento; 

	// Use this for initialization
	void Start () { 

		bomber = GameObject.FindGameObjectWithTag("Player").transform;
		velocidadMovimiento=1;
	}
	
	// Update is called once per frame
	void FixedUpdate() 
	{
		posicionBomberX=bomber.transform.localPosition.x;


		if ((posicionBomberX>7) && (posicionBomberX<32))
		{
			
			if (Input.GetKey (KeyCode.RightArrow))
			{	
				Debug.Log ("hola");
				velocidadHorizontal = 2;
				var movimiento = new Vector3 (velocidadHorizontal, 0, 0);
				transform.position += movimiento * velocidadMovimiento * Time.deltaTime;
			}
			else if (Input.GetKey (KeyCode.LeftArrow))
			{	
				velocidadHorizontal = -2;
				var movimiento = new Vector3 (velocidadHorizontal, 0, 0);
				transform.position += movimiento * velocidadMovimiento * Time.deltaTime;
			}




		}
	}

}
