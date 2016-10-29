using UnityEngine;
using System.Collections;

public class CrearBomba : MonoBehaviour {
	Transform bomber;
	public GameObject Bomba;
	float posicionBomberX;
	float posicionBomberY;
	float posicionBombaX;
	float posicionBombaY;
	int numBombas;
	int maxBombas;


	// Use this for initialization
	void Start () {
		bomber = GameObject.FindGameObjectWithTag("Player").transform;
		numBombas=0;
		maxBombas=9999;
	
	}

	
	// Update is called once per frame
	void Update () 
	{
		posicionBomberX=bomber.transform.localPosition.x;
		posicionBomberY=bomber.transform.localPosition.y;

        if (Input.GetKeyDown(KeyCode.Z) && (numBombas < maxBombas))
        {
            var laBomba = Instantiate(Bomba) as GameObject;
            laBomba.transform.SetParent(transform);
            posicionBombaX = Mathf.Round(posicionBomberX);
            posicionBombaY = Mathf.Round(posicionBomberY);
            laBomba.transform.localPosition = new Vector3(posicionBombaX, posicionBombaY);
            numBombas = numBombas + 1;
            GetComponent<AudioSource>().UnPause();
        }
        else
        {
            GetComponent<AudioSource>().Pause(); 
        
		}
		
	}
}
