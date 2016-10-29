using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	public GameObject ondaderecha;
	public GameObject ondaizquierda;
	public GameObject ondaarriba;
	public GameObject ondaabajo;
	public GameObject animurodes;


	private bool despejadoDerecha ;
	private bool despejadoIzquierda;
	private bool despejadoArriba;
	private bool despejadoAbajo;
	int posicionExplosionX;
	int posicionExplosiony;
	RaycastHit2D hitDerecha;
	RaycastHit2D hitIzquierda;
	RaycastHit2D hitArriba;
	RaycastHit2D hitAbajo;
	string nombreObjeto;
	Transform mundo;
	public int x;
	public int y;

	// Use this for initialization
	void Start () 
	{
        GetComponent<AudioSource>();
        x = (int)transform.position.x;
		x = Mathf.RoundToInt (x);
		y = (int)transform.position.y;
		y = Mathf.RoundToInt (y);
		mundo = GameObject.FindGameObjectWithTag("Mundo").transform;
		Destroy(GameObject.FindGameObjectWithTag("explosion"),.8f);
		evaluador();
		onda ();
        

	}

			
//	void OnTriggerExit2D(Collider2D  other) {
//		GetComponent<CircleCollider2D>().isTrigger = false;
//	}

	void onda()
	{
		


		if (despejadoDerecha)
		{
			var ondaExplosionDer = Instantiate (ondaderecha) as GameObject;
			ondaExplosionDer.transform.SetParent (mundo);
			ondaExplosionDer.transform.localPosition = new Vector3 (x+1, y);
			Destroy(ondaExplosionDer,.8f);
		}
		else
		{
			if (hitDerecha.transform.tag == "bloque_des")
			{
				Destroy (hitDerecha.transform.gameObject);
				int animX;
				int animY;
				animX=x+1;
				animY=y;
				var murodes = Instantiate (animurodes) as GameObject;
				murodes.transform.SetParent (mundo);
				murodes.transform.localPosition = new Vector3 (animX, animY);
				Destroy(murodes,.8f);
			}
		}


		if (despejadoIzquierda)
		{

			var ondaExplosionIzq = Instantiate (ondaizquierda) as GameObject;
			ondaExplosionIzq.transform.SetParent (mundo);
			ondaExplosionIzq.transform.localPosition = new Vector3 (x-1, y);
			Destroy(ondaExplosionIzq,.8f);


		}
		else
		{
			if (hitIzquierda.transform.tag == "bloque_des")
			{
				Destroy (hitIzquierda.transform.gameObject);
				int animX;
				int animY;
				animX=x-1;
				animY=y;
				var murodes = Instantiate (animurodes) as GameObject;
				murodes.transform.SetParent (mundo);
				murodes.transform.localPosition = new Vector3 (animX, animY);
				Destroy(murodes,.8f);
			}
		}
		if (despejadoArriba)
		{

			var ondaExplosionArr = Instantiate (ondaarriba) as GameObject;
			ondaExplosionArr.transform.SetParent (mundo);
			ondaExplosionArr.transform.localPosition = new Vector3 (x, y+1);
			Destroy(ondaExplosionArr,.8f);


		}
		else
		{
			if (hitArriba.transform.tag == "bloque_des")
			{
				Destroy (hitArriba.transform.gameObject);
				int animX;
				int animY;
				animX=x;
				animY=y+1;
				var murodes = Instantiate (animurodes) as GameObject;
				murodes.transform.SetParent (mundo);
				murodes.transform.localPosition = new Vector3 (animX, animY);
				Destroy(murodes,.8f);
			}
		}
		if (despejadoAbajo)
		{

			var ondaExplosionAbj = Instantiate (ondaabajo) as GameObject;
			ondaExplosionAbj.transform.SetParent (mundo);
			ondaExplosionAbj.transform.localPosition = new Vector3 (x, y-1);
			Destroy(ondaExplosionAbj,.8f);

		}
		else
		{
			if (hitAbajo.transform.tag == "bloque_des")
			{
				Destroy (hitAbajo.transform.gameObject);
				int animX;
				int animY;
				animX=x;
				animY=y-1;
				var murodes = Instantiate (animurodes) as GameObject;
				murodes.transform.SetParent (mundo);
				murodes.transform.localPosition = new Vector3 (animX, animY);
				Destroy(murodes,.8f);
			}
		}


	}




	
	// Update is called once per frame
	void Update () {
		lineas();
	
	}


	void lineas()
	{
		
		//derecha
		Debug.DrawLine(new Vector2(x+.8f,y-0.5f), new Vector2(x+1.5f,y-0.5f), Color.red,Time.deltaTime);
		//izquierda
		Debug.DrawLine(new Vector2(x,y-0.5f), new Vector2(x-0.5f,y-0.5f), Color.green,Time.deltaTime);
		//abajo
		Debug.DrawLine(new Vector2(x+0.5f,y-.8f), new Vector2(x+0.5f,y-1.5f), Color.red,Time.deltaTime);
		//arriba
		Debug.DrawLine(new Vector2(x+0.5f,y), new Vector2(x+0.5f,y+0.5f), Color.blue,Time.deltaTime);
	}

	void evaluador ()
	{
		
		int layerMask = 1 << 8;
		// Debug.Log (LayerMask.LayerToName (8));
		layerMask = ~layerMask;
		hitDerecha = Physics2D.Raycast (new Vector2(x+.8f,y-0.5f), new Vector2(x+1.5f,y-0.5f), 0.6f,layerMask );
		hitIzquierda = Physics2D.Raycast (new Vector2(x,y-0.5f), new Vector2(x-0.5f,y-0.5f),0.6f, layerMask);
		hitAbajo = Physics2D.Raycast (new Vector2(x+0.5f,y-.8f), new Vector2(x+0.5f,y-1.5f), 0.6f, layerMask );
		hitArriba = Physics2D.Raycast (new Vector2(x+0.5f,y), new Vector2(x+0.5f,y+0.5f), 0.6f,layerMask);
		// elvalua la derecha
		if (hitDerecha.collider == null )
		{										
			despejadoDerecha=true;
		}
		else
		{
			despejadoDerecha=false;
			Debug.Log (hitDerecha.collider.name);
			Debug.Log ("bloqueadoderecha");

		}
		// elvalua la izquierda
		if (hitIzquierda.collider == null )
		{										
			despejadoIzquierda=true;
		}
		else
		{
			despejadoIzquierda=false;
			Debug.Log (hitIzquierda.collider.name);
			Debug.Log ("bloqueadoizquierda");
		}
		// elvalua abajo
		if (hitAbajo.collider == null )
		{										
			despejadoAbajo = true;
		}
		else
		{
			despejadoAbajo = false;
			Debug.Log (hitAbajo.collider.name);
			Debug.Log ("bloqueadoabajo");
		}
		// elvalua arriba
		if (hitArriba.collider == null )
		{										
			despejadoArriba=true;
			Debug.Log ("despejadosiarriba");
		}
		else
		{
			despejadoArriba=false;
			Debug.Log (hitArriba.collider.name);
			Debug.Log ("bloqueadoiarriba");
		}
	}
}

			