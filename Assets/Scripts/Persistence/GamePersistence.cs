using Inventory;
using UnityEngine;
using UserInterface;

namespace Persistence
{
    public class GamePersistence : MonoBehaviour
    {
        private GameData _gameData = new GameData();
    
        // void Start() => LoadGame();

        private void OnDisable() => SaveGame();

        private void SaveGame()
        {
            var json = JsonUtility.ToJson(_gameData);
            PlayerPrefs.SetString("GameData", json);
        }

        private void LoadGame()
        {
            var json = PlayerPrefs.GetString("GameData");
            _gameData = JsonUtility.FromJson<GameData>(json) ?? new GameData();
            
            GameFlagManager.Instance.Bind(_gameData.gameFlagDatas);
            InventoryCollection.Instance.Bind(_gameData.slotDatas);
        }
    }
}