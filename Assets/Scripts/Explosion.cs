using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	public GameObject ondaderecha;
	public GameObject ondaizquierda;
	public GameObject ondaarriba;
	public GameObject ondaabajo;
	public GameObject exp;
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
	Transform mundo;

	public LayerMask bomberman=8;


	// Use this for initialization
	void Start () 
	{
		int x = (int)transform.position.x;
		int y = (int)transform.position.y;
		mundo = GameObject.FindGameObjectWithTag("Mundo").transform;
		exp = GameObject.FindGameObjectWithTag("explosion");
		evaluador();
		if (despejadoDerecha)
		{
			
			var ondaExplosionDer = Instantiate (ondaderecha) as GameObject;
			ondaExplosionDer.transform.SetParent (mundo);
			ondaExplosionDer.transform.localPosition = new Vector3 (x+1, y);
			//aqui pasa la magia
			Destroy(ondaExplosionDer,.5f);

			}
			
		if (despejadoIzquierda)
		{

			var ondaExplosionIzq = Instantiate (ondaizquierda) as GameObject;

			ondaExplosionIzq.transform.SetParent (mundo);
			ondaExplosionIzq.transform.localPosition = new Vector3 (x-1, y);
			//aqui pasa la magia
			Destroy(ondaExplosionIzq,.5f);

		}
		if (despejadoArriba)
		{

			var ondaExplosionArr = Instantiate (ondaarriba) as GameObject;

			ondaExplosionArr.transform.SetParent (mundo);
			ondaExplosionArr.transform.localPosition = new Vector3 (x, y+1);
			//aqui pasa la magia
			Destroy(ondaExplosionArr,.5f);

		}
		if (despejadoAbajo)
		{

			var ondaExplosionAbj = Instantiate (ondaabajo) as GameObject;

			ondaExplosionAbj.transform.SetParent (mundo);
			ondaExplosionAbj.transform.localPosition = new Vector3 (x, y-1);
			//aqui pasa la magia
			Destroy(ondaExplosionAbj,.5f);

		}

		Destroy(exp,.5f);
	}

			


	

	
	// Update is called once per frame
	void Update () {
		lineas();
	
	}


	void lineas()
	{
		int x = (int)transform.position.x;
		int y = (int)transform.position.y;
		//derecha
		Debug.DrawLine(new Vector2(x+1f,y-0.5f), new Vector2(x+1.5f,y-0.5f), Color.red,Time.deltaTime);
		//izquierda
		Debug.DrawLine(new Vector2(x,y-0.5f), new Vector2(x-0.5f,y-0.5f), Color.green,Time.deltaTime);
		//abajo
		Debug.DrawLine(new Vector2(x+0.5f,y-1f), new Vector2(x+0.5f,y-1.5f), Color.red,Time.deltaTime);
		//arriba
		Debug.DrawLine(new Vector2(x+0.5f,y), new Vector2(x+0.5f,y+0.5f), Color.blue,Time.deltaTime);
	}

	void evaluador ()
	{
		int x = (int)transform.position.x;
		int y = (int)transform.position.y;
	

		hitDerecha = Physics2D.Raycast (new Vector2(x+1f,y-0.5f), new Vector2(x+1.5f,y-0.5f), 0.5f,bomberman);
		hitIzquierda = Physics2D.Raycast (new Vector2(x,y-0.5f), new Vector2(x-0.5f,y-0.5f),0.5f,bomberman);
		hitAbajo = Physics2D.Raycast (new Vector2(x+0.5f,y-1f), new Vector2(x+0.5f,y-1.5f), 0.5f,bomberman);
		hitArriba = Physics2D.Raycast (new Vector2(x+0.5f,y), new Vector2(x+0.5f,y+0.5f), 0.5f,bomberman);
		// elvalua la derecha
		if (hitDerecha.collider == null )
		{										
			despejadoDerecha=true;
		}
		else
		{
			despejadoDerecha=false;
			Debug.Log (hitDerecha.collider.name);
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
		}
		// elvalua arriba
		if (hitArriba.collider == null )
		{										
			despejadoArriba=true;
		}
		else
		{
			despejadoArriba=false;
			Debug.Log (hitArriba.collider.name);
		}
	}
}

