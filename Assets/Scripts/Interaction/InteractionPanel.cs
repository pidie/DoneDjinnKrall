using TMPro;
using UnityEngine;

namespace Interaction
{
	public class InteractionPanel : MonoBehaviour
	{
		[SerializeField] private TMP_Text hintText;
		
		private void OnEnable()
		{
			hintText.enabled = false;
			Interactable.InteractablesInRangeChanged += UpdateHintTextState;
		}

		private void OnDisable() => Interactable.InteractablesInRangeChanged -= UpdateHintTextState;

		private void UpdateHintTextState(bool enableHint) => hintText.enabled = enableHint;
	}
}