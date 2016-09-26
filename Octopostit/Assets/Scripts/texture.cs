using UnityEngine;
using System.Collections;

public class texture : MonoBehaviour {
	public Texture2D text;


	// Use this for initialization
	void Start () {
		Texture2D texture = new Texture2D (128, 128);
		Renderer renderer = GetComponent<Renderer> ();
		renderer.material.mainTexture = texture;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
