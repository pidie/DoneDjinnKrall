using System.Linq;
using UnityEngine;

namespace Interaction
{
	public class InteractionManager : MonoBehaviour
	{
		private Interactable _currentInteractable;
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.E))
				_currentInteractable = Interactable.InteractablesInRange.FirstOrDefault();

			if (Input.GetKey(KeyCode.E) && _currentInteractable != null)
				_currentInteractable.Interact();
		}
	}
}