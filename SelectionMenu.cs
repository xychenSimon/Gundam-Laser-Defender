using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionMenu : MonoBehaviour {

	public List<GameObject> characterList;
	public int index = 0;


	// Use this for initialization
	void Start () {
		GameObject[] characters = Resources.LoadAll<GameObject> ("prefab");
		foreach (GameObject c in characters) {
			GameObject _char = Instantiate (c) as GameObject;
			_char.transform.SetParent (GameObject.Find ("Characters").transform);

			characterList.Add (_char);
			_char.SetActive (false);
			characterList [index].SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
}
