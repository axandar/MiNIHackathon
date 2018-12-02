using Readonly_Data;
using UnityEngine;

namespace EnemyLogic {
	public class GoblinAI : MonoBehaviour{
		[SerializeField] private Transform _targetTransform;
		[SerializeField] private float _moveSpeed;
		
		private Transform _transform;
		private float _groundLevel;
		private bool _touchedPlayer;
		private AudioSource _scream;
		private Rigidbody _rigid;
		private bool isKilled;

		private void Start() {
			_transform = transform;
			_targetTransform = GameObject.FindGameObjectWithTag(Tags.MAIN_CAMERA).transform;
			_scream = GetComponent<AudioSource>();
			_rigid = GetComponent<Rigidbody>();
		}

		private void FixedUpdate() {
			if (!_touchedPlayer) {
				AttackTarget();
			}
		}

		private void OnTriggerEnter(Collider other) {
			if (other.CompareTag(Tags.MAIN_CAMERA)) {
				_touchedPlayer = true;
				_rigid.freezeRotation = true;
			}
		}

		private void AttackTarget() {
			var direction = (_transform.position - _targetTransform.position).normalized;
			var targetDir = _targetTransform.position - transform.position;
			var step = Time.deltaTime;
			var newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
			Debug.DrawRay(transform.position, newDir, Color.red);
		
			transform.rotation = Quaternion.LookRotation(newDir);
			_transform.Translate(direction * -_moveSpeed);
		}

		public void Kill(){
			if(!isKilled){
				isKilled = true;
				_scream.Play();	
				GetComponent<CapsuleCollider>().enabled = false;
				GetComponent<MeshRenderer>().enabled = false;
				Destroy(gameObject,_scream.clip.length);
			}
		}
	}
}
