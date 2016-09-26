using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {
	

	public GameObject pink;
	public GameObject blue;
	public Transform trueRotation;
	public float timeLeft = 30.0f;
	public Text text;
	public Text scoreText;

	private int score = 0;

	public static bool scorePink = false;
	public static bool scoreBlue = false;

	// Use this for initialization
	void Start () {
		//Instantiate (pink, spawnLocation.position, spawnLocation.rotation); 
		Spawnable();
	}

	float[] Randomizer () {
		int rand = (int)(Random.Range (0f, 10f)) % 2;

		float[] x = {0,0};


		if (rand == 1) {
			x[0] = -0.97f;
			x [1] = 1f;
		} else {
			x[0] = 0.97f;
			x [1] = -1f;
		}
		return x;

	}

	void Spawnable(){

		float[] x = {0,0};
		x = Randomizer ();

		Vector2 SpawnPositionPink = new Vector2 (x[0], Random.Range (-2f, 3f));
	
		x = Randomizer ();

		Vector2 SpawnPositionBlue = new Vector2 (x[0], SpawnPositionPink.y +(Random.Range (0.7f, 1.3f)*x[1]));
		//Quaternion spawnRotationBlue = new Quaternion(0f, 0f, 90f);
		//Quaternion spawnRotationPink = new Quaternion(0f, 0f, 90f);
		Instantiate (pink, SpawnPositionPink, trueRotation.rotation);
		Instantiate (blue, SpawnPositionBlue, trueRotation.rotation);
	}

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.CompareTag ("BASE") || ( other.CompareTag ("Pink") && other.CompareTag ("Blue") )) {
			other.attachedRigidbody.constraints = RigidbodyConstraints2D.None;

			Revive ();
		}
	}

	public void Revive() {

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		//Spawnable();
		//int randomIndex = Random.Range (0, randomObjective.Length);
	//	Instantiate (randomObjective [randomIndex], Rigidbody2D.transform.position);

	}
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		text.text = "Time Left: " + Mathf.Round(timeLeft);

		if (scoreBlue && scorePink)
		{
			scoreBlue = false;
			scorePink = false;
			score += 100;
			Spawnable();
		}
		if (timeLeft < 0){
//			animation.Play ();
			Revive();
		}
		scoreText.text = "SCORE: " + score;
	}
}
