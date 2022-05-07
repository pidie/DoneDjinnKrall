using System;
using UnityEngine;

namespace Player
{
    [Serializable]
    internal struct PlayerBasicInfo
    {
        public int health;
        public int maxHealth;
        public bool isDead;
    }
    public class PlayerData : MonoBehaviour
    {
        [SerializeField] private PlayerBasicInfo data;

        private void Update()
        {
            if (data.health <= 0)
                data.isDead = true;
        }

        public int GetHealth()
        {
            return data.health;
        }

        public int GetMaxHealth()
        {
            return data.maxHealth;
        }

        public void SetHealth(int value)
        {
            data.health = value < 0 ? 0 : value;
        }

        public void SetHealthToMax()
        {
            if (data.health <= data.maxHealth) 
                data.health = data.maxHealth;
        }

        public void ModifyHealth(int value)
        {
            if (data.health + value < data.maxHealth)
                data.health += value;
            else
                data.health = data.maxHealth;
        }

        public int TakeDamage(int value)
        {
            if (data.health - value < 0)
            {
                var n = data.health;
                data.health = 0;
                return n;
            }
            else
            {
                data.health -= value;
                return value;
            }
        }
    }
}