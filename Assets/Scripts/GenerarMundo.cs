using UnityEngine;
using System.Collections;

public class GenerarMundo : MonoBehaviour {
		public GameObject PrefabBloqueInd;
		public GameObject PrefabBloqueDes;
		int posX;
		int posY;
		int posDesX;
		int posDesY;
		int numBloques;
		int contador;
		
		// Use this for initialization
		void Start () 
		{
			Bloquesind ();
			Bloquesdes ();
			Enemigos();
			
		}
		

		


	void Bloquesind ()
		{
			for ( int i=0; i<16; i++)
			{
				for( int j=0; j<6; j++)
				{
					posX = 2*i;
					posY = -2*j;
					var miBloque=Instantiate(PrefabBloqueInd) as GameObject;
					miBloque.transform.SetParent (transform);
					miBloque.transform.localPosition = new Vector3 (posX, posY);
				}
			}
		}

	void Bloquesdes()
		{
			int i=3;
			numBloques = 10;

			while (i < numBloques)
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

				var otroBloque = Instantiate (PrefabBloqueDes) as GameObject;
				otroBloque.transform.SetParent (transform);
				otroBloque.transform.localPosition = new Vector3 (posDesX, posDesY);
				i = i + 1;
			}
		}

	void Enemigos()
	{
		int numEnemigos =6;	
		int contador=1;
		while (contador<numEnemigos)
		{
			contador=contador+1;
		}

	}
}