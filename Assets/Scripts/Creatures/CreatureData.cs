using UnityEngine;

namespace Creatures
{
    public class CreatureData : MonoBehaviour
    {
        private float Height { get; set; }

        private void Awake()
        {
            Height = 1.5f;
        }
    }
}
