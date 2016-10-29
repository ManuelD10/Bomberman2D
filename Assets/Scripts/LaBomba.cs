using UnityEngine;
using System.Collections;

public class LaBomba : MonoBehaviour {
	Transform bomba;
	Transform mundo;
	public GameObject explosion;
	float posicionBombaX;
	float posicionBombaY;
	float posicionExplosionX;
	float posicionExplosionY;
	void Start ()
	{
		bomba = GameObject.FindGameObjectWithTag("Bomba").transform;
		mundo = GameObject.FindGameObjectWithTag("Mundo").transform;
		posicionBombaX=bomba.transform.localPosition.x;
		posicionBombaY=bomba.transform.localPosition.y;
		Invoke("Destruirbomba", 2);
	}


	// Update is called once per frame


	void OnTriggerExit2D(Collider2D  other) {
		GetComponent<CircleCollider2D>().isTrigger = false;
	}
	void Update ()
	{

	
	}
	void Destruirbomba()
	{
		Destroy (GameObject.FindGameObjectWithTag("Bomba"));
		var laExplosion = Instantiate (explosion) as GameObject;
		laExplosion.transform.SetParent (mundo);
		posicionExplosionX= Mathf.Round (posicionBombaX);
		posicionExplosionY= Mathf.Round (posicionBombaY);
		laExplosion.transform.localPosition = new Vector3 (posicionBombaX, posicionBombaY);	
	}

	void FixedUpdate()
	{
		
	}

}
