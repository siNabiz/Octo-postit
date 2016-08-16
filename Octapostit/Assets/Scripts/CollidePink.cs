using UnityEngine;
using System.Collections;

public class CollidePink : MonoBehaviour {
	public Sprite texture;


	// Use this for initialization
//	void Start () {
//		
//	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Pink")) {
			Respawn.scorePink = true;
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
