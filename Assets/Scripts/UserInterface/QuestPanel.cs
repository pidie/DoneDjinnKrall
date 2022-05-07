using System.Text;
using Quests;
using TMPro;
using UnityEngine;

namespace UserInterface
{
	public class QuestPanel : ToggleablePanel
	{
		[SerializeField] private Quest selectedQuest;
		[SerializeField] private TMP_Text nameText;
		[SerializeField] private TMP_Text descriptionText;
		[SerializeField] private TMP_Text currentObjectivesText;

		private Step SelectedStep => selectedQuest.CurrentStep;
		private KeyCode _toggleKey;

		private void Awake() => _toggleKey = KeyCode.Q;

		private void Update()
		{
			if (Input.GetKeyDown(_toggleKey))
				ToggleCanvas(!IsShowing);
		}

		[ContextMenu("Bind")]
		public void Bind()
		{
			nameText.SetText(selectedQuest.QuestName);
			descriptionText.SetText(selectedQuest.Description);

			DisplayObjectives();
		}

		private void DisplayObjectives()
		{
			var builder = new StringBuilder();
			if (SelectedStep != null)
			{
				builder.AppendLine(SelectedStep.Instructions);
				foreach (var obj in SelectedStep.objectives)
				{
					var rgb = obj.IsCompleted ? "green" : "grey";
					builder.AppendLine($"<color={rgb}>- {obj}</color>");
				}
			}

			currentObjectivesText.SetText(builder.ToString());
		}

		public void SelectQuest(Quest quest)
		{
			if (selectedQuest)
				selectedQuest.DataChanged -= DisplayObjectives;
			
			selectedQuest = quest;
			Bind();

			selectedQuest.DataChanged += DisplayObjectives;
		}
	}
}
