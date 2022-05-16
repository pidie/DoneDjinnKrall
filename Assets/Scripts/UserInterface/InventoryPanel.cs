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

		// todo : rework the Bind method to be called for each EquipmentCategory
		// does this method need to cycle through each equipment type to ensure that everything's been
		// covered, or does it not matter?
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