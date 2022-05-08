using Inventory;
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

		private void Start() => Bind(InventoryCollection.Instance);

		private void Update()
		{
			if (Input.GetKeyDown(_toggleKey))
				ToggleCanvas(!IsShowing);
		}

		public void Bind(InventoryCollection inventory)
		{
			var panelSlots = GetComponentsInChildren<InventoryPanelSlot>();

			for (int i = 0; i < panelSlots.Length; i++)
			{
				panelSlots[i].Bind(inventory.GetItemSlotByIndex(i));
			}
		}
	}
}