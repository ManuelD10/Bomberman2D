using UnityEngine;
using System.Collections;

public class GeneradorParedesDes : MonoBehaviour 
	{
		public GameObject paredPrefab;

		// Use this for initialization
		void Start () 
		{
			int posX;
			int posY;
			int numParedes = 30;
			for ( int i=0; i<numParedes;i++)
			{
				//	posX = 2 * Random.Range (-3, 3);
				//	posY = 2 * Random.Range (-3, 3);
				posX = Random.Range (-6, 6);
				posY = Random.Range (-6, 6);
				Instantiate(paredPrefab, new Vector3(posX,posY), transform.rotation);
			}
		}

		// Update is called once per frame
		void Update () {
		
		}
	}

