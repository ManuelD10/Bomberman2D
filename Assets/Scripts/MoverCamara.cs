using UnityEngine;
using System.Collections;

public class MoverCamara : MonoBehaviour {
	public GameObject bomber;
	private Vector3 seguidor;
	public float posicionBomberX; 
	public float posicionBomberY; 
	MovBomber scriptA;



	// Use this for initialization
	void Start () { 

		seguidor = transform.position = bomber.transform.position;
		scriptA = GameObject.Find ("Bomber").GetComponent<MovBomber> ();
	
	}

	void Update()
	{
		posicionBomberX=scriptA.BombermanX;
		posicionBomberY=scriptA.BombermanX;
		if ((posicionBomberX > 1) && (posicionBomberX < 31) && (posicionBomberY < -1) && (posicionBomberY > -11))
		{
			transform.position = bomber.transform.position + seguidor;
		}
	
	}
}			
