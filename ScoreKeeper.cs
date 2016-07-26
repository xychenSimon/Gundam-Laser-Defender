using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public static int score = 0;

	private Text score_txt;
	// Use this for initialization
	void Start () {
		score_txt = GetComponent<Text> ();
		reset ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Score (int points) {
		score += points;
		score_txt.text = score.ToString();
	}

	public static void reset () {
		score = 0;
	}
}
