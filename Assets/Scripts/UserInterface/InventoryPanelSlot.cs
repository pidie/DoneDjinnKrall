using Inventory;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UserInterface
{
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