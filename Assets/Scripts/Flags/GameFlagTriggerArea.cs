using UnityEngine;

namespace Flags
{
    /// <summary>
    /// Place this on GameObjects that will set a boolean GameFlag to true upon collision
    /// </summary>
    public class GameFlagTriggerArea : MonoBehaviour
    {
        [SerializeField] private GameFlagBool gameFlagBool;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                gameFlagBool.Set(true);
        }
    }
}