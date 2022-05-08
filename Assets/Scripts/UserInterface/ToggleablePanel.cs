using UnityEngine;

namespace UserInterface
{
	public class ToggleablePanel : MonoBehaviour
	{
		[SerializeField] private CanvasGroup canvasGroup;
		[SerializeField] [Range(0,1)] private float menuTransparency = 0.96f;
		
		public bool IsShowing { get; set; }

		private void Awake()
		{
			canvasGroup = GetComponent<CanvasGroup>();
			ToggleCanvas(false);
		}

		public void ToggleCanvas(bool value = true)
		{
			if (value)
				ToggleOtherCanvases();
			
			canvasGroup.alpha = value ? menuTransparency : 0;
			canvasGroup.interactable = value;
			canvasGroup.blocksRaycasts = value;
			IsShowing = value;
		}

		private void ToggleOtherCanvases()
		{
			foreach (var panel in ToggleablePanelCollection.AllPanels)
			{
				if (panel == this)
					continue;
				
				panel.ToggleCanvas(false);
			}
		}
	}
}