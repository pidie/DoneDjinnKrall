using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// todo : modify the interaction system to reflect a top-down conducive system
namespace Interaction
{
	public class Interactable : MonoBehaviour
	{
		private static HashSet<Interactable> _interactablesInRange = new HashSet<Interactable>();
		public static IReadOnlyCollection<Interactable> InteractablesInRange => _interactablesInRange;
		public static event Action<bool> InteractablesInRangeChanged;

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				_interactablesInRange.Add(this);
				Interact();
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				_interactablesInRange.Remove(this);
				Interact(_interactablesInRange.Any());
			}
		}

		public void Interact(bool shouldInvoke = true) => InteractablesInRangeChanged?.Invoke(shouldInvoke);
	}
}

/*
 * each interactable will register events to InteractablesInRangeChanged that, when invoked, will
 * execute.
 */