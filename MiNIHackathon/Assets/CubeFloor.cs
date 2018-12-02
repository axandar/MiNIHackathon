using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFloor : MonoBehaviour {

	private void Start () {
        GetComponent<Renderer>().material.color = new Color(0, 0, 1);
    }
}
