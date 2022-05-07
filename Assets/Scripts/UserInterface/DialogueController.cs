using System.Text;
using GameEvents;
using Ink.Runtime;
using Quests;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class DialogueController : ToggleablePanel
    {
        [SerializeField] private TMP_Text storyText;
        [SerializeField] private Button[] choiceButtons;

        private Story _story;
        
        private const string InvokeLabel = "Event.";
        private const string QuestLabel = "Quest.";
        private const string FlagLabel = "Flag.";

        public void StartDialogue(TextAsset dialogue)
        {
            _story = new Story(dialogue.text);
            RefreshView();
            ToggleCanvas();
        }

        private void RefreshView()
        {
            var storyTextBuilder = new StringBuilder();

            while (_story.canContinue)
            {
                storyTextBuilder.AppendLine(_story.Continue());
                HandleTags();
            }
        
            storyText.SetText(storyTextBuilder);

            if (_story.currentChoices.Count == 0)
                ToggleCanvas(false);
            else ShowChoiceButtons();
        }

        private void ShowChoiceButtons()
        {
            for (var i = 0; i < choiceButtons.Length; i++)
            {
                var button = choiceButtons[i];
                var choiceExists = i < _story.currentChoices.Count;

                button.gameObject.SetActive(choiceExists);
                button.onClick.RemoveAllListeners();

                if (choiceExists)
                {
                    var choice = _story.currentChoices[i];
                    button.GetComponentInChildren<TMP_Text>().SetText(choice.text);
                    button.onClick.AddListener(() =>
                    {
                        _story.ChooseChoiceIndex(choice.index);
                        RefreshView();
                    });
                }
            }
        }

        private void HandleTags()
        {
            foreach (var inkyTag in _story.currentTags)
            {
                if (inkyTag.StartsWith(InvokeLabel))
                {
                    var eventName = inkyTag.Remove(0, InvokeLabel.Length);
                    GameEvent.RaiseEvent(eventName);
                }
                else if (inkyTag.StartsWith(QuestLabel))
                {
                    var questName = inkyTag.Remove(0, QuestLabel.Length);
                    QuestManager.Instance.AddQuestByName(questName);
                }
                else if (inkyTag.StartsWith(FlagLabel))
                {
                    var values = inkyTag.Split('.');
                    FlagManager.Instance.Set(values[1], values[2]);
                }
            }
        }

        public void ToggleVisibility(bool toggle) => ToggleCanvas(toggle);
    }
}