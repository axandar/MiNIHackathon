using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRaisedSurface : MonoBehaviour {

	// Use this for initialization
	private void Start () {
        GetComponent<Renderer>().material.color = new Color(1, 1, 0);
    }
}
