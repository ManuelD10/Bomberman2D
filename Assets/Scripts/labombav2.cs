using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Activation : MonoBehaviour
{


	private float t = 0;
	private int pos = 0;
	private int tmp = 0;
	private bool b = true;
	private bool Derecha = true;
	private bool Izquierda = true;
	private bool Arriba = true;
	private bool Abajo = true;
	public Transform explosion;		

	// Use this for initialization
	void Start ()
	{					

	}
	// Update is called once per frame
	void Update ()
	{

		RaycastHit2D hitDerecha;
		RaycastHit2D hitIzquierda;
		RaycastHit2D hitArriba;
		RaycastHit2D hitAbajo;		


		int x = (int)transform.position.x;
		int y = (int)transform.position.y;


		if (b == true ) {						

			hitDerecha = Physics2D.Raycast (new Vector2 (x + pos, y), Vector2.right, 1);
			hitIzquierda = Physics2D.Raycast (new Vector2 (x - pos, y), -Vector2.right, 0);
			hitArriba = Physics2D.Raycast (new Vector2 (x, y + pos), Vector2.up, 0);
			hitAbajo = Physics2D.Raycast (new Vector2 (x, y - pos), -Vector2.up, 0);

			if (hitDerecha.collider != null && hitDerecha.collider.tag == "Block") {										
				Derecha = false;
			}
			if (hitIzquierda.collider != null && hitIzquierda.collider.tag == "Block") {
				Izquierda = false;								
			}

			if (hitArriba.collider != null && hitArriba.collider.tag == "Block") {
				Arriba = false;						

			}

			if (hitAbajo.collider != null && hitAbajo.collider.tag == "Block") {
				Abajo = false;								
			}

			//right
			if (Derecha) {
				Instantiate (explosion, new Vector3 (x + pos, y, -1), 
					Quaternion.Euler (0, 0, 0));
				if (hitDerecha.collider != null && hitDerecha.collider.tag == "Box") {										
					Derecha = false;
					Destroy (hitDerecha.transform.gameObject);
				}
			}

			//left						
			if (Izquierda) {								
				Instantiate (explosion, new Vector3 (x - pos, y, -1), 
					Quaternion.Euler (0, 180, 0));
				if (hitIzquierda.collider != null && hitIzquierda.collider.tag == "Box") {										
					Izquierda = false;
					Destroy (hitIzquierda.transform.gameObject);
				}
			}

			//up						
			if (Arriba) {								
				Instantiate (explosion, new Vector3 (x, y + pos, -1), 
					Quaternion.Euler (0, 0, 90));	
				if (hitArriba.collider != null && hitArriba.collider.tag == "Box") {										
					Arriba = false;
					Destroy (hitArriba.transform.gameObject);
				}
			}

			//down						
			if (Abajo) {								
				Instantiate (explosion, new Vector3 (x, y - pos, -1),	
					Quaternion.Euler (0, 0, 270));	
				if (hitAbajo.collider != null && hitAbajo.collider.tag == "Box") {										
					Abajo = false;
					Destroy (hitAbajo.transform.gameObject);
				}
			}

			b = false;	
			t = Time.time;
			pos += 2;
			tmp++;

		}

		if (Time.time - t > 0.2f) {
			b = true;						
		}
		if (tmp == 0) {
			Destroy (gameObject, 0.1f);
		}
	}

}