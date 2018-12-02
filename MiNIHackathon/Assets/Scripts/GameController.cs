using UnityEngine;

public class GameController : MonoBehaviour {
    
    public GameObject Cursor;
    public Spawnable SpawnObjectPrefab;

    private bool _isGravity;

    public void StartGame(){
        //SpawnObject();
    }

    public void SpawnObject(){
        Spawn(SpawnObjectPrefab, new Vector3(0, 0, 2), Quaternion.identity);
    }

    public void Spawn(Spawnable spawnObjectPrefab, Vector3 position, Quaternion rotation){
        var spawnedObject = Instantiate(spawnObjectPrefab, position, rotation, null);

        SpawnInit(spawnedObject);
    }

    private void SpawnInit(Spawnable spawnedObject){
        spawnedObject.Init(Cursor);
        var rigid = spawnedObject.GetComponent<Rigidbody>();
        if(rigid != null){
            rigid.isKinematic = !_isGravity;
        }
    }

    public void ToggleGravity(){
        if (_isGravity){
            GravityOff();
        }else{
            GravityOn();
        }
    }

    public void GravityOn(){
        _isGravity = true;
        var foundObjects = FindObjectsOfType<Rigidbody>();
        foreach(var foundObject in foundObjects){
            foundObject.isKinematic = false;
        }
    }

    public void GravityOff(){
        _isGravity = false;
        var foundObjects = FindObjectsOfType<Rigidbody>();
        foreach (var foundObject in foundObjects){
            foundObject.isKinematic = true;
        }
    }
}
