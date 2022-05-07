using UnityEngine;

namespace Quests
{
	public class QuestGiver : MonoBehaviour
	{
		[SerializeField] private Quest quest;
    
		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
				QuestManager.Instance.AddQuest(quest);
		}
	}
}