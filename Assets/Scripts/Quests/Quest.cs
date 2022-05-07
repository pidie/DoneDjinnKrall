using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quests
{
    /// <summary>
    /// A Quest is a set of tasks broken into Steps, and further broken into Objectives.
    /// </summary>
    [CreateAssetMenu(menuName = "Quest", fileName = "New Quest")]
    public class Quest : ScriptableObject
    {
        [SerializeField] private string questName;
        [TextArea(5, 10)] [SerializeField] private string description;
        [Tooltip("Internal notes for designers/programmers")]
        [TextArea(5, 10)] [SerializeField] private string notes;

        private int _currentStepIndex;
        
        public List<Step> steps;
        public event Action DataChanged;

        public string QuestName => questName;
        public string Description => description;
        public Step CurrentStep => steps[_currentStepIndex];

        private void OnEnable()
        {
            _currentStepIndex = 0;
            
            foreach (var step in steps)
                foreach (var objective in step.objectives)
                    if (objective.GameFlag != null)
                        objective.GameFlag.FlagDataChanged += HandleFlagChanged;
        }

        private void HandleFlagChanged()
        {
            TryProgress();
            DataChanged?.Invoke();
        }

        public void TryProgress()
        {
            var currentStep = GetCurrentStep();
            if (currentStep.AllObjectivesCompleted())
            {
                _currentStepIndex++;
                DataChanged?.Invoke();
                // do the things (update ui, play sound, etc)
            }
        }

        private Step GetCurrentStep()
        {
            return steps[_currentStepIndex];
        }
    }

    /// <summary>
    /// A Step is a collection of Objectives. Steps must be completed in a sequence, but may have branching paths.
    /// </summary>
    [Serializable]
    public class Step
    {
        [SerializeField] private string instructions;
        public string Instructions => instructions;
        public List<Objective> objectives;

        public bool AllObjectivesCompleted()
        {
            return objectives.TrueForAll(t => t.IsCompleted);
        }
    }
}