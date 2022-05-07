using System.Collections;
using UnityEngine;
using UserInterface;

public class DialogueGiver : MonoBehaviour
{
	[SerializeField] private TextAsset dialogue;

	private bool _dialogueRequested;
	private bool _registerWait;

	private void Update()
	{
		var distance = DistanceToPlayer();
		
		if (Input.GetMouseButtonDown(0) && !_registerWait)
			_dialogueRequested = false;
		
		var dialogueController = FindObjectOfType<DialogueController>();
		
		if (_dialogueRequested)
			if (distance < 1)
				dialogueController.StartDialogue(dialogue);
		
		if (dialogueController.enabled && distance > 2)
			dialogueController.ToggleVisibility(false);
	}

	private void OnMouseDown()
	{
		_dialogueRequested = true;
		StartCoroutine(Wait());
	}

	private float DistanceToPlayer()
	{
		var playerPos = GameObject.Find("Player").transform.position;
		var pos = transform.position;

		return Vector3.Distance(playerPos, pos);
	}

	private IEnumerator Wait()
	{
		_registerWait = true;
		yield return new WaitForSeconds(.1f);
		_registerWait = false;
	}
}