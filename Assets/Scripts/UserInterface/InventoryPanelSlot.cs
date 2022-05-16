using Inventory;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// todo : rename to InventoryPanelEquipmentSlot

namespace UserInterface
{
	/// Controls the Equipment selection section of the Inventory Panel ///
	public class InventoryPanelSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField] private Image itemIcon;
		[SerializeField] private Outline outline;
		
		private ItemSlot _itemSlot;

		public void Bind(ItemSlot itemSlot)
		{
			_itemSlot = itemSlot;
			_itemSlot.ItemChanged += UpdateIcon;

			UpdateIcon();
			
			// inserted here to ensure deregistration - unsure if this is the correct place for this
			_itemSlot.ItemChanged -= UpdateIcon;
		}

		private void UpdateIcon()
		{
			if (_itemSlot.GetItem() != null)
			{
				itemIcon.sprite = _itemSlot.GetItem().icon;
				itemIcon.enabled = true;
			}
			else
			{
				itemIcon.sprite = null;
				itemIcon.enabled = false;
			}
		}

		public void OnPointerEnter(PointerEventData eventData) => outline.enabled = true;

		public void OnPointerExit(PointerEventData eventData) => outline.enabled = false;
	}
}