using UnityEngine;
using System.Collections;

public class GenerarMundo : MonoBehaviour {
	public GameObject PrefabBloqueInd;
	public GameObject PrefabBloqueDes;
	public GameObject PrefabEnemigoUno;
	public GameObject Lapuerta;
	int posX;
	int posY;
	int posDesX;
	int posDesY;
	int numBloques;
	int contador;
	public int numEnemigos;	

		
		// Use this for initialization
		void Start () 
		{
			Bloquesind ();
			Bloquesdes ();
			Enemigos();
			Puerta();
			
		}

	void Bloquesind ()
		{
			for ( int i=1; i<16; i++)
			{
				for( int j=1; j<6; j++)
				{
					posX = 2*i;
					posY = -2*j;
					var miBloque=Instantiate(PrefabBloqueInd) as GameObject;

					miBloque.transform.SetParent (transform);
					miBloque.transform.localPosition = new Vector3 (posX, posY);
					string lax=posX.ToString();
					string lay=posY.ToString();
					miBloque.name="nodestruye [" + lax + ", " + lay + "]";


				}
			}
		}

	void Bloquesdes()
		{
			int i=3;
			numBloques = 50;

			while (i < numBloques)
			{	
				posDesX = Random.Range(0,30);
				posDesY = Random.Range (1, 11);

				if (posDesX % 2 != 0)
				{
					posDesY=-1*Random.Range(1,12);
				}
				else
				{
				    posDesX = posDesX + 1;
					posDesY=-2*Random.Range(1,6);
				}
				var otroBloque = Instantiate (PrefabBloqueDes) as GameObject;
				otroBloque.transform.SetParent (transform);
				otroBloque.transform.localPosition = new Vector3 (posDesX, posDesY);
				string lax=posDesX.ToString();
				string lay=posDesY.ToString();
				otroBloque.name="destruye [" + lax + ", " + lay + "]";
				i = i + 1;
			}
		}

	void Enemigos()
	{
		numEnemigos =6;	
		int contador=1;
		while (contador<numEnemigos)
		{
			posDesX = Random.Range(1,31);
			posDesY = Random.Range (1, 11);

			if (posDesX % 2 != 0)
			{
				posDesY=-1*Random.Range(1,12);
			}
			else
			{
				posDesY=-2*Random.Range(1,6);
			}

			var enemigoUno = Instantiate (PrefabEnemigoUno) as GameObject;
			enemigoUno.transform.SetParent (transform);
			enemigoUno.transform.localPosition = new Vector3 (posDesX, posDesY);
			contador=contador+1;

		}

	}

	void Puerta()
	{
			
		posDesX = Random.Range(12,30);
		posDesY = Random.Range (5, 11);

		if (posDesX % 2 != 0)
		{
			posDesY=-1*Random.Range(1,12);
		}
		else
		{
			posDesX = posDesX + 1;
			posDesY=-2*Random.Range(1,6);
		}
		var salida = Instantiate (Lapuerta) as GameObject;
		salida.transform.SetParent (transform);
		salida.transform.localPosition = new Vector3 (posDesX, posDesY);

		var otroBloque = Instantiate (PrefabBloqueDes) as GameObject;
		otroBloque.transform.SetParent (transform);
		otroBloque.transform.localPosition = new Vector3 (posDesX, posDesY);







	}

}