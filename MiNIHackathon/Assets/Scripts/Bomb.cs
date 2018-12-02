using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Bomb : MonoBehaviour{

	public float RocketSpeed;
	private Vector3 _targetPosition;
	private AudioSource _enemyScreamSource;
	
	[SerializeField] private AudioClip _enemyScream;

	private void Start()
	{
		_enemyScreamSource.playOnAwake = false;
		_enemyScreamSource.clip = _enemyScream;
	}

	public void AttachTarget(GameObject target){
		_targetPosition = target.transform.position;
	}

	private void FixedUpdate(){
		RotateToTarget();
		
		var distance = Vector3.Distance(_targetPosition, transform.position);
		if(distance < 0.01f){
			Boom();
		}
		transform.position += transform.forward * Time.deltaTime * RocketSpeed;
	}

	private void RotateToTarget(){
		var targetDir = _targetPosition - transform.position;
		var step = RocketSpeed * Time.deltaTime;
		var newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
		Debug.DrawRay(transform.position, newDir, Color.red);
		
		transform.rotation = Quaternion.LookRotation(newDir);
	}

	private void Boom(){
		Debug.Log("Boom");
		var objects = Physics.OverlapSphere(transform.position, 2);
		foreach(var obj in objects){
			if(obj.CompareTag(Tags.ENEMY)){
				_enemyScreamSource.Play();
				Destroy(obj.gameObject);
			}
		}

		Destroy(gameObject);
	}
}
