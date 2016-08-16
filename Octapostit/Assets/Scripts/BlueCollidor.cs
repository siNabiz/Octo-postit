using UnityEngine;
using System.Collections;

public class BlueCollidor : MonoBehaviour {
	public Sprite texture;


	// Use this for initialization
//	void Start () {
//
//	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Blue")) {
			Respawn.scoreBlue = true;
			SpriteRenderer renderer = GetComponent<SpriteRenderer>();
			renderer.sprite = texture;

			renderer.enabled = false;

		}
	}

	// Update is called once per frame
//	void Update () {
//
//	}
}