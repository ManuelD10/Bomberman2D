using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public int vidasBomberman;
	public int Enemigos;
	public int numMuerto;
	public MovBomber scriptA;
	public GenerarMundo scriptB;
	public PatrullarV2 scriptC;







	// Use this for initialization
	void Start () {
		scriptA = GameObject.Find ("Bomber").GetComponent<MovBomber> ();
		vidasBomberman = scriptA.vidasBomber;

		scriptB = GameObject.Find ("Escenario").GetComponent<GenerarMundo> ();
		Enemigos = scriptB.numEnemigos;



	
	}
	
	// Update is called once per frame
	void Update () 
	{
		scriptC = GameObject.Find ("enemigo1").GetComponent<PatrullarV2> ();
		numMuerto = scriptC.meMori;


		Enemigos = Enemigos - numMuerto;
		Debug.Log ("los muertos");
		Debug.Log (Enemigos);
		Debug.Log (numMuerto);





	
	}
}
