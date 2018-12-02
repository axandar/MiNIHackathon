using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeWall : MonoBehaviour {

	private void Start () {
        GetComponent<Renderer>().material.color = new Color(1, 0, 0);
    }
}
