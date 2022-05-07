using UnityEngine;
using UnityEngine.Events;

namespace GameEvents
{
	public class GameEventListener : MonoBehaviour
	{
		[SerializeField] private UnityEvent unityEvent;
		[SerializeField] private GameEvent gameEvent;

		private void Awake() => gameEvent.Register(this);

		private void OnDisable() => gameEvent.Deregister(this);

		public void RaiseEvent() => unityEvent.Invoke();
	}
}