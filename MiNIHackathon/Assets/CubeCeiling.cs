using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCeiling : MonoBehaviour {
	
	private void Start () {
        GetComponent<Renderer>().material.color = new Color(0, 1, 0);
    }
}
