using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnEvil : MonoBehaviour{
	[SerializeField][Range(0.1f,10f)] private float _spawnRate;
	[SerializeField] private Transform _targetTransform;
	[SerializeField] private GameObject _evilSnowman;
	[SerializeField] private float _radius;
	[SerializeField] private float _minSpawnDist = 5f;

	private Vector3 _enemyPosition;
	private bool _needNewSpawnPoint;

	private void Start(){
		StartCoroutine(SpawnEvilSnowmen());
	}

	private void FixedUpdate(){
		
			var tempEnemyPosition = Random.insideUnitSphere * _radius;
			tempEnemyPosition.y = 0;
		
			var distance = Vector3.Distance(_targetTransform.position, tempEnemyPosition);
	
			if (distance > _minSpawnDist){
				_enemyPosition = tempEnemyPosition;
			}
		
	}

	private IEnumerator SpawnEvilSnowmen(){
		while (true){
			yield return new WaitForSeconds(_spawnRate);
			Instantiate(_evilSnowman, _enemyPosition, Quaternion.identity);
		}
	}

	private void OnDrawGizmos(){
		Gizmos.DrawWireSphere(_targetTransform.position,_radius);
	}
}
