using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour {
    
    public GameObject Cursor;
    public Spawnable SpawnObjectPrefab;

    private bool _isGravity;

    private void Start(){
        if (!Cursor){
            Debug.LogError("!Cursor");
        }
        if (!SpawnObjectPrefab){
            Debug.LogError("!spawnObjectPrefab");
        }

        //GravityOff();
    }

    public void StartGame(){
        Debug.Log("GameController::StartGame");

        SpawnObject();
    }

    public void SpawnObject(){
        Spawn(SpawnObjectPrefab, new Vector3(0, 0, 2), Quaternion.identity);
    }

    public void Spawn(Spawnable spawnObjectPrefab, Vector3 position, Quaternion rotation){
        Debug.Log("Spawner::Spawn");
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

        Debug.Log("Spawner::GravityOn");

        var foundObjects = FindObjectsOfType<Rigidbody>();
        foreach(var foundObject in foundObjects){
            foundObject.isKinematic = false;
        }
    }

    public void GravityOff(){
        _isGravity = false;

        Debug.Log("Spawner::GravityOff");

        var foundObjects = FindObjectsOfType<Rigidbody>();
        foreach (var foundObject in foundObjects){
            foundObject.isKinematic = true;
        }
    }
}
