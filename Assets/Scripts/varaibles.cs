using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class varaibles : MonoBehaviour {

	private Animator miAnimator;
	float velocidadMovimiento;
	int vidasBomber;
	public Text vidasBomberText;
	public float minPosX;
	public float minPosY;
	public float maxPosX;
	public float maxPosY;
	public float BombermanX;
	public float BombermanY;
	// Use this for initialization


	// Use this for initialization
	void Start () 
	{

		minPosX = .9f;
		minPosY=-.9f;
		maxPosX=31.1f;
		maxPosY=-11.1f;
		miAnimator = GetComponent<Animator>();
		vidasBomber = 3;
		vidasBomberText.text = vidasBomber.ToString ();

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemigo1") 
		{
			vidasBomber = vidasBomber - 1;
			vidasBomberText.text = vidasBomber.ToString ();
		}	

	}


	// Update is called once per frame

	public Vector3 direction;
	void Update () 
	{
		// Movimiento a la derecha
		if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			if (miAnimator.GetBool("caminarDerecha") == true)
			{
				miAnimator.SetBool ("caminarDerecha", false);
			}
			else
			{
				miAnimator.SetBool ("caminarDerecha", true);
			}
		}

		if (Input.GetKeyUp (KeyCode.RightArrow)) 
		{
			if (miAnimator.GetBool("caminarDerecha") == true)
			{
				miAnimator.SetBool ("caminarDerecha", false);
			}
			else
			{
				miAnimator.SetBool ("caminarDerecha", true);
			}
		}

		// Movimiento a la izquierda
		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			if (miAnimator.GetBool("caminarIzquierda") == true)
			{
				miAnimator.SetBool ("caminarIzquierda", false);
			}
			else
			{
				miAnimator.SetBool ("caminarIzquierda", true);
			}
		}

		if (Input.GetKeyUp (KeyCode.LeftArrow)) 
		{
			if (miAnimator.GetBool("caminarIzquierda") == true)
			{
				miAnimator.SetBool ("caminarIzquierda", false);
			}
			else
			{
				miAnimator.SetBool ("caminarIzquierda", true);
			}
		}

		// Movimiento abajo
		if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			if (miAnimator.GetBool("caminarAbajo") == true)
			{
				miAnimator.SetBool ("caminarAbajo", false);
			}
			else
			{
				miAnimator.SetBool ("caminarAbajo", true);
			}
		}

		if (Input.GetKeyUp (KeyCode.DownArrow)) 
		{
			if (miAnimator.GetBool("caminarAbajo") == true)
			{
				miAnimator.SetBool ("caminarAbajo", false);
			}
			else
			{
				miAnimator.SetBool ("caminarAbajo", true);
			}
		}

		// Movimiento arriba
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			if (miAnimator.GetBool("caminarArriba") == true)
			{
				miAnimator.SetBool ("caminarArriba", false);
			}
			else
			{
				miAnimator.SetBool ("caminarArriba", true);
			}
		}

		if (Input.GetKeyUp (KeyCode.UpArrow)) 
		{
			if (miAnimator.GetBool("caminarArriba") == true)
			{
				miAnimator.SetBool ("caminarArriba", false);
			}
			else
			{
				miAnimator.SetBool ("caminarArriba", true);
			}
		}
	}

	void FixedUpdate(){
		velocidadMovimiento = 2;
		var movimiento = new Vector3(Mathf.Round(Input.GetAxis("Horizontal")), Mathf.Round(Input.GetAxis("Vertical")), 0);
		BombermanX =transform.position.x;
		BombermanY =transform.position.y;
		transform.position += movimiento * velocidadMovimiento * Time.deltaTime;

//		if ((BombermanX > minPosX) && (BombermanX < maxPosX) && (BombermanY < minPosY ) && (BombermanY > maxPosY ))
//		{
//			transform.position += movimiento * velocidadMovimiento * Time.deltaTime;
//		}
			
		
			
	}
}