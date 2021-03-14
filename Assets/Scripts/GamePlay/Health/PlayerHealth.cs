using System;
using System.Collections;
using GameController;
using UnityEngine;

namespace GamePlay.Health
{
    public class PlayerHealth : HealthScript
    {
        public static event Action PlayerDeath = delegate {};
        
        private void OnEnable()
        {
            GameManager.GameStarted += GameManager_GameStarted;
        }

        private void OnDisable()
        {
            GameManager.GameStarted -= GameManager_GameStarted;
        }

        private void GameManager_GameStarted()
        {
            UpdateHealth();
        }
        
        protected override IEnumerator Death()
        {
            PlayerDeath.Invoke();
            yield return null;
        }
    }
}