using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DirectionIndicator))]
public class Spawnable : MonoBehaviour {
	
	public void Init(GameObject cursor){
        var directionIndicator = gameObject.GetComponent<DirectionIndicator>();
        directionIndicator.Cursor = cursor;
    }
}
