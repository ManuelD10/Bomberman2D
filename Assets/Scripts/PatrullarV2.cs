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

	void OnCollisionEnter2D(Collision2D coll) 
	{
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
		//	transform.localPosition = new Vector3(Mathf.Round(transform.localPosition.x), transform.localPosition.y, 0);
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
		//	transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Round(transform.localPosition.y), 0);
		} 
		colisiones = colisiones + 1;
	}

	void FixedUpdate() 
	{
		
		Calculardistancia ();
		EvaluarColisiones ();
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
		EnemigoAlaVista = Radar ();
		if (EnemigoAlaVista)
		{
			Alataque ();	
		}
		else {
			Moverse ();
		}
	}

	void Alataque()
	{
		if (voyHorizontal)
		{
			Atacary ();
		
		} 
		else
		{
			Atacarx ();
		
		} 
			
	}






	void Atacarx()
	{
		voyHorizontal = true;
		if (miPosicionX < posicionBomberX) 
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
		voyHorizontal = false;
		if (miPosicionY < posicionBomberY) 
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
		
		if (direccionX == true)
		{
			velocidadHorizontal = 1;

		} else
		{
			velocidadHorizontal = -1;
		}
		var movimiento = new Vector3(velocidadHorizontal, velocidadVertical, 0);

		transform.position += movimiento * velocidadMovimiento * Time.deltaTime;
	}
	void Moversey ()
	{

		if (direccionY == true) 
		{
			velocidadVertical = 1;
		} 
		else
		{
			velocidadVertical = -1;
		} 
	 
		var movimiento = new Vector3(velocidadHorizontal, velocidadVertical, 0);
	//	transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Round(transform.localPosition.y), 0);
		transform.position += movimiento * velocidadMovimiento * Time.deltaTime;
	}



	void EvaluarColisiones ()
	{
		if (colisiones > maxColisiones) 
		{
			if (voyHorizontal == true)
			{
				voyHorizontal = false;
			} 
			else 
			{
				voyHorizontal = true;
			
			}
			colisiones = 0;
		}
	}
	bool Direccionalazar ()
	{
		bool alzar ;
		var numero=Random.Range (0,1);
		if (numero == 0) 
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
		posicionBomberY=Mathf.Round(bomber.transform.localPosition.y);
		miPosicionY=Mathf.Round(transform.localPosition.y);
		posicionBomberX=Mathf.Round(bomber.transform.localPosition.x);
		miPosicionX=Mathf.Round(transform.localPosition.x);
		distanciaX=(Mathf.Abs ( Mathf.Abs(posicionBomberX) - Mathf.Abs(miPosicionX) ));
		distanciaY=(Mathf.Abs ( Mathf.Abs(posicionBomberY) - Mathf.Abs(miPosicionY) ));


	}

}
