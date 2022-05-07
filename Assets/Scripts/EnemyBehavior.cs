using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
	[SerializeField] private float movementSpeed;
	
	private Transform _player;
	private Coroutine _seekPlayer;
	private Rigidbody _rigidbody;
	
	private void Awake()
	{
		_player = GameObject.FindWithTag("Player").transform;
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
			_seekPlayer = StartCoroutine(SeekPlayer());
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
			StopCoroutine(_seekPlayer);
	}

	private void Move()
	{
		var direction = -(_player.position - transform.position).normalized;
		_rigidbody.AddForce(direction * movementSpeed * Time.deltaTime);
	}
	
	private IEnumerator SeekPlayer()
	{
		Move();
		yield return new WaitForSeconds(.1f);
	}
}
