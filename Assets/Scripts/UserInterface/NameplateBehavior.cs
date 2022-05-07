using System;
using UnityEngine;

namespace UserInterface
{
    public class NameplateBehavior : MonoBehaviour
    {
        [SerializeField] private bool isConstant;

        private Canvas _canvas;
        
        private void Awake()
        {
            _canvas = GetComponentInChildren<Canvas>();
            
            if (!isConstant) 
                _canvas.gameObject.SetActive(false);
        }

        private void Update() => _canvas.transform.rotation = Quaternion.Euler(30, 45, 0);

        private void OnMouseOver()
        {
            _canvas.gameObject.SetActive(true);
        }

        private void OnMouseExit()
        {
            if (!isConstant)
                _canvas.gameObject.SetActive(false);
        }
    }
}