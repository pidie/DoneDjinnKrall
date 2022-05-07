using UnityEngine;

namespace Flags
{
	public class GameFlagTriggerAreaInt : MonoBehaviour
	{
		[SerializeField] private int amount;
		[SerializeField] private GameFlagInt gameFlagInt;
    
		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
				gameFlagInt.Modify(amount);
		}
	}
}