using Player;
using TMPro;
using UnityEngine;

namespace UserInterface
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private TMP_Text playerHealthDisplay;

        private void Update()
        {
            playerHealthDisplay.text = $"{playerData.GetHealth()} /  {playerData.GetMaxHealth()}"; 
        }
    }
}