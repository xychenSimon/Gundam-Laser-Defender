using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

	// Use this for initialization

	void OnDrawGizmos() {
		Gizmos.DrawWireSphere (transform.position, 1);
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
