using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class BombSpawner: MonoBehaviour, IInputClickHandler{

	public GameObject Cursor;
	public Bomb Bomb;
	
	public void OnInputClicked(InputClickedEventData eventData){
		var clickedPosition = Cursor.gameObject.transform;
		var vector3 = clickedPosition.position;
		vector3.y += 5;
		
		var instantiated = Instantiate(Bomb);
		instantiated.transform.position = vector3;
		instantiated.transform.parent = null;
		instantiated.AttachTarget(Cursor);
	}
}