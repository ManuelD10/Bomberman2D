using UnityEngine;
using System.Collections;

public class MovBomber : MonoBehaviour {

	private Animator miAnimator;
	float velocidadMovimiento;
	// Use this for initialization


	// Use this for initialization
	void Start () 
	{
		miAnimator = GetComponent<Animator>();
	}

	// Update is called once per frame
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

		// Movimiento arriva
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
		transform.position += movimiento * velocidadMovimiento * Time.deltaTime;
	}
}