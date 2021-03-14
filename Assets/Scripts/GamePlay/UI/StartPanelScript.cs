using System;
using GameController;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay.UI
{
    public class StartPanelScript : MonoBehaviour,IPointerDownHandler
    {
        private static StartPanelScript _instance;

        public static StartPanelScript Instance => _instance;

        private void Awake()
        {
            _instance = this;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            GameManager.Instance.StartLevel();
            gameObject.SetActive(false);
        }
    }
}