using UnityEngine;

namespace UserInterface
{
	public class InventoryPanel : ToggleablePanel
	{
		private KeyCode _toggleKey;

		private void Awake()
		{
			_toggleKey = KeyCode.I;
			ToggleCanvas(false);
		}

		private void Update()
		{
			if (Input.GetKeyDown(_toggleKey))
				ToggleCanvas(!IsShowing);
		}
	}
}