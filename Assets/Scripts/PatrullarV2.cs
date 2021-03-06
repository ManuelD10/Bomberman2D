using UnityEngine;
using System.Collections;


public class PatrullarV2 : MonoBehaviour {

	private GameObject jugador;
	Transform bomber;
	public float velocidadMovimiento;
	public float velocidadHorizontal;
	public float velocidadVertical;
	public bool voyHorizontal;
	public bool direccionX;
	public bool direccionY;
	public bool EnemigoAlaVista;
	public bool modoataque;
	public float posicionBomberX;
	public float posicionBomberY;
	public float miPosicionX;
	public float miPosicionY;
	public float distanciaX;
	public float distanciaY;
	public float distanciaMinima;
	public int colisiones;
	public int maxColisiones;
	public GameObject eneMuerto;
	public float posicionEneX;
	public float posicionEney;
	public int meMori;



	// Use this for initialization
	void Start () {
		bomber = GameObject.FindGameObjectWithTag("Player").transform;
		velocidadMovimiento = 2;
		voyHorizontal = false;
		direccionY=false;
		direccionX=false;
		distanciaMinima=4;
		colisiones = 1;
		maxColisiones = 6;
		modoataque = false;

	}

	void Update () {
		
	}


	void OnCollisionStay2D(Collision2D coll) 
	{
		//cambia de dirección cuando hay colisión
		if (voyHorizontal == true)
		{
			if (direccionX == true) 
			{
				direccionX=false;
			} 
			else
			{
				direccionX=true;
			}

		}
		else
		{
			if (direccionY == true) 
			{
				direccionY = false;
			} 
			else
			{
				direccionY = true;
			}

		} 
		colisiones = colisiones + 1;

	}

	void OnCollisionEnter2D(Collision2D coll) 
	{

		if (coll.gameObject.tag == "explosion") 
		{

			posicionEneX=transform.localPosition.x;
			posicionEney=transform.localPosition.y;
			meMori = 1;

			var muerto = Instantiate (eneMuerto) as GameObject;
			muerto.transform.SetParent (transform);
			muerto.transform.localPosition = new Vector3 (posicionEneX, posicionEney);
			Destroy (this.gameObject);





		}



		//cambia de dirección cuando hay colisión
		if (voyHorizontal == true)
		{
			if (direccionX == true) 
			{
				direccionX=false;
			} 
			else
			{
				direccionX=true;
			}
		
		}
		else
		{
			if (direccionY == true) 
			{
				direccionY = false;
			} 
			else
			{
				direccionY = true;
			}
		
		} 
		colisiones = colisiones + 1;
	
	}

	void FixedUpdate() 
	{
		//loop principal
		Calculardistancia ();
		EvaluarColisiones ();
		Ajustar ();
		if (modoataque == true) 
		{
			Atacar ();
		}
		else
		{
			Moverse ();
		}
	}
	void Atacar ()
	{
		// busca si esta bomber cerca, si esta cerca ataca
		EnemigoAlaVista = Radar ();
		if (EnemigoAlaVista)
		{
			Alataque ();	
		}
		else {
			Moverse ();
		}
	}

	void Ajustar()
	{
		if (voyHorizontal)
		{
			velocidadVertical = 0;
		} else
		{
			velocidadHorizontal = 0;
		}

	}

	void Alataque()
	{
		//si va en una direccion cambia de direccion para atacar
		// aca se debe corregir y atacar de acuerdo a al distancia mas coorta


		if (distanciaY < distanciaX) 
		{	
			Atacarx ();
			Moversex ();
		}
		else if (distanciaY > distanciaX)
		{
			Atacary ();
			Moversey ();
		}
		else if (distanciaX == 0)
		{	
			Moversey ();
		} 
		else if (distanciaY == 0) {
			Moversex ();
		}
		else if (distanciaX == distanciaY) 
		{
			Moversex ();
			Moversey ();

		}

		

		
		 
			
	}
		void Atacarx()
	{
		//de acuerod a la direccion de donde esta bomber cambia la ubicacion para atacar
		voyHorizontal = true;
		if ((Mathf.Round(miPosicionX))<(Mathf.Round(posicionBomberX)))
		{
			direccionX = true;
					
		} 
		else 
		{
			direccionX = false;
		
		}
	}
	void Atacary()
	{
		//de acuerod a la direccion de donde esta bomber cambia la ubicacion para atacar
		voyHorizontal = false;
		if ((Mathf.Round(miPosicionY))<(Mathf.Round(posicionBomberY))) 
		{
			
			direccionY = true;
		} 
		else 
		{
			direccionY = false;

		}
	}

	void Moverse ()
	{
		// se mueve de acierdo a la direccion donde este
		if (voyHorizontal)
		{
			Moversex ();
		} else
		{
			Moversey ();
		}
	}

	void Moversex ()
	{
		// se mueve en x
		if (direccionX == true)
		{
			velocidadHorizontal = 1;

		} else
		{
			velocidadHorizontal = -1;
		}
		var movimiento = new Vector3(velocidadHorizontal, velocidadVertical, 0);
		transform.localPosition = new Vector3(transform.localPosition.x, Mathf.RoundToInt(transform.localPosition.y), 0);
		transform.position += movimiento * velocidadMovimiento * Time.deltaTime;
	}
	void Moversey ()
	{
		// se mueve en y
		if (direccionY == true) 
		{
			velocidadVertical = 1;
		} 
		else
		{
			velocidadVertical = -1;
		} 
	 
		var movimiento = new Vector3(velocidadHorizontal, velocidadVertical, 0);
		transform.localPosition = new Vector3(Mathf.RoundToInt(transform.localPosition.x), transform.localPosition.y, 0);
		transform.position += movimiento * velocidadMovimiento * Time.deltaTime;
	}



	void EvaluarColisiones ()
	{
		// lo saca de looop 
		if (colisiones > maxColisiones) 
		{
			voyHorizontal = Direccionalazar ();
			colisiones = 0;
		}
	}
	bool Direccionalazar ()
	{
		bool alzar ;
		var numero=Random.Range (0,10);

		if (numero > 5) 
		{
			alzar = true;
		} else 
		{
			alzar = false;
		}
		return alzar;
	}
	bool Radar ()
	{
		//evalua que tan cerca esta bomber
		bool peligro;
		if ((distanciaX < distanciaMinima) && (distanciaY < distanciaMinima))
		{
			peligro = true;
		} 
		else 
		{
			peligro = false;
		}
		return peligro;
	}

	void Calculardistancia ()
	{
		//calcula la distancia entre el player y bomber
		posicionBomberY=Mathf.Round(bomber.transform.localPosition.y);
		miPosicionY=Mathf.Round(transform.localPosition.y);
		posicionBomberX=Mathf.Round(bomber.transform.localPosition.x);
		miPosicionX=Mathf.Round(transform.localPosition.x);
		distanciaX=(Mathf.Abs ( Mathf.Abs(posicionBomberX) - Mathf.Abs(miPosicionX) ));
		distanciaY=(Mathf.Abs ( Mathf.Abs(posicionBomberY) - Mathf.Abs(miPosicionY) ));


	}

}
