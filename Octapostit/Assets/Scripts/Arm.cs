using UnityEngine;
using System.Collections;

/*[System.Serializable]
public class Boundary{
	public float xMin, xMax, yMin, yMax;
}*/

public class Arm : MonoBehaviour {
	public Rigidbody2D rb;
	public float velocity;
	public float playerNumber;
	public float startTime = 0;

	private bool right = false;
	private bool left = false;
	private Vector2 temp; 
	private int counter =0;



//	// Use this for inleftitialization vector
//	void Start () {
//
//	}
//

	//public bool IsTouching(Collider2D left);

	void OnTriggerEnter2D(Collider2D other){

		temp = rb.transform.position;

		if (other.CompareTag ("Left Wall")) {
			left = true;
			right = false;
			counter = 0;
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
		}

		if (other.CompareTag ("Right Wall")) {
			right = true;
			left = false;
			counter = 0;
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
		}
		if (other.CompareTag ("PinkObjective")) {
			right = true;
			left = false;
			//counter = 0;
		}
		if (other.CompareTag ("BlueObjective")) {
			right = true;
			left = false;
			//counter = 0;
		}
		rb.transform.position = temp;
		//if (Input.GetButton ("Fire1")) {
		counter = 0;
		//rb.constraints = RigidbodyConstraints2D.FreezeAll;
		/*if (other.CompareTag ("Pink")||other.CompareTag ("Blue")) {
			rb.constraints = RigidbodyConstraints2D.None;
		}*/
	}



	// Update is called once per frame
	void FixedUpdate () {

		startTime += Time.time;

		if (Input.GetButton("Fire1") /*&& !Input.GetButton("Fire2")*/ && right == false && left == false&& counter < 20) {
			rb.constraints = RigidbodyConstraints2D.None;
			//if (counter < 20) {
				rb.AddForce (velocity * (Vector2.left + playerNumber * Vector2.up), ForceMode2D.Impulse);
			//}

			/*if (Input.GetButton ("Fire1") && !Input.GetButton ("Fire2") && right == false && left == false) {
			
				rb.AddForce (velocity * (Vector2.left + playerNumber * Vector2.up), ForceMode2D.Impulse);
			}*/
			counter++;

		} else if (Input.GetButton("Fire1") /*&& !Input.GetButton("Fire2")*/ && right == true && counter < 20) {
			rb.constraints = RigidbodyConstraints2D.None;
			//if (counter < 20) {
				rb.AddForce (velocity * (Vector2.left + playerNumber * Vector2.up), ForceMode2D.Impulse);
			//}
			/*if (Input.GetButton ("Fire1") && !Input.GetButton ("Fire2") && right == true) {
				rb.AddForce (velocity * (Vector2.right + playerNumber * Vector2.up), ForceMode2D.Impulse);
			}*/
			counter++;


		} else if (Input.GetButton("Fire1") /*&& !Input.GetButton("Fire2")*/ && left == true && counter < 20) {
			rb.constraints = RigidbodyConstraints2D.None;
			//if (counter < 20) {
				rb.AddForce (velocity * (Vector2.right + playerNumber * Vector2.up), ForceMode2D.Impulse);
			//}
			/*if (Input.GetButton ("Fire1") && !Input.GetButton ("Fire2") && left == true) {
				rb.AddForce (velocity * (Vector2.left + playerNumber * Vector2.up), ForceMode2D.Impulse);
			}*/
			counter++;

		}

		rb.position = new Vector2 (Mathf.Clamp(rb.position.x, -1.1f,1.1f),
			Mathf.Clamp(rb.position.y, -4f, 6f));

	}
}
