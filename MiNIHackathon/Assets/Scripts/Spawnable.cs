using HoloToolkit.Unity;
using UnityEngine;

[RequireComponent(typeof(DirectionIndicator))]
public class Spawnable : MonoBehaviour {
	
	public void Init(GameObject cursor){
        var directionIndicator = gameObject.GetComponent<DirectionIndicator>();
        directionIndicator.Cursor = cursor;
    }
}
