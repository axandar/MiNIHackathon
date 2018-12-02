using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

	[SerializeField] private float _life;

	public void HitByEnemy()
	{
		Debug.Log(--_life);
	}
}
