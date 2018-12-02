using Readonly_Data;
using UnityEngine;

namespace EnemyLogic {
	public class GoblinAI : MonoBehaviour
	{

		
		[SerializeField] private Transform _targetTransform;
		[SerializeField] private float _moveSpeed;
		[SerializeField] private float _wiggliness;
		private Transform _transform;
		private Rigidbody _rigidbody;
		private float _groundLevel;
		private bool _touchedPlayer;
		private AudioSource _scream;
		

		private void Start() {
			_transform = transform;
			_targetTransform = GameObject.FindGameObjectWithTag(Tags.MAIN_CAMERA).transform;
			_rigidbody = _transform.GetComponent<Rigidbody>();
			_scream = GetComponent<AudioSource>();
		}

		private void Update() {
			if (!_touchedPlayer) {
				AttackTarget();
			}
		}

		private void OnTriggerEnter(Collider other) {
			if (other.CompareTag(Tags.MAIN_CAMERA)) {
				_touchedPlayer = true;
			}
		}

		private void AttackTarget() {
			var targetPosition = _targetTransform.position;
			var direction = (_transform.position - targetPosition).normalized;
			direction.y = 0;
			_transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
			_transform.Translate(direction * -_moveSpeed);
		}

		public void Kill(){
			_scream.Play();	
			GetComponent<CapsuleCollider>().enabled = false;
			GetComponent<MeshRenderer>().enabled = false;
			Destroy(gameObject,_scream.clip.length);
		}
		
	}
}
