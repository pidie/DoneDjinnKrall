using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UserInterface;

namespace Quests
{
    public class QuestManager : MonoBehaviour
    {
        [SerializeField] private QuestPanel questPanel;
        [SerializeField] private List<Quest> allQuests;

        private HashSet<Quest> _activeQuests = new HashSet<Quest>();

        public static QuestManager Instance { get; private set; }

        private void Awake() => Instance = this;

        public void AddQuest(Quest quest)
        {
            _activeQuests.Add(quest);
            questPanel.SelectQuest(quest);
        }

        public void AddQuestByName(string questName)
        {
            var quest = allQuests.FirstOrDefault(t => t.name == questName);
            if (quest != null)
                AddQuest(quest);
            else
                Debug.LogError($"Missing quest {questName} attempted to add from dialogue");
        }
    }
}