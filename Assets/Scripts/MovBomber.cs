using UnityEngine;
using System.Collections;

public class MovBomber : MonoBehaviour {

<<<<<<< Updated upstream
	// Use this for initialization
	void Start () {

	}
	float velocidadMovimiento;


	void Update () {
=======
	private Animator miAnimator;
	float velocidadMovimiento;

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
>>>>>>> Stashed changes

	}

	void FixedUpdate(){
		velocidadMovimiento = 3;
		var movimiento = new Vector3(Mathf.Round(Input.GetAxis("Horizontal")), Mathf.Round(Input.GetAxis("Vertical")), 0);
		transform.position += movimiento * velocidadMovimiento * Time.deltaTime;
	}
<<<<<<< Updated upstream
}
=======
}
>>>>>>> Stashed changes
