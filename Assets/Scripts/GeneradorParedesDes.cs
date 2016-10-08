using UnityEngine;
using System.Collections;

public class GeneradorParedesDes : MonoBehaviour 
{
	public GameObject PrefabBloqueInd;
	public GameObject PrefabBloqueDes;

	// Use this for initialization
	void Start () 
	{
		int posX;
		int posY;
		int posDesX;
		int posDesY;
		for ( int i=0; i<16; i++)
		{
			for( int j=0; j<6; j++)
			{
				posX = 2*i;
				posY = -2*j;
				var miBloque=Instantiate(PrefabBloqueInd) as GameObject;
				miBloque.transform.SetParent (transform);
				miBloque.transform.localPosition = new Vector3 (posX, posY);

				if ( i % 2 != 0) 
				{ 
					posX = i;
					posY=Random.Range(0,-12);

				}
				else 
				{
					posX = i;
					posY = 2 * Random.Range (0, 15);
				}

				var otroBloque=Instantiate(PrefabBloqueDes) as GameObject;
				otroBloque.transform.SetParent (transform);
				otroBloque.transform.localPosition = new Vector3 (posX, posY);
					
					


			}
		}
	}
}

