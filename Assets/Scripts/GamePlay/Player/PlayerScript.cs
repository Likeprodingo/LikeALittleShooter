using System;
using UnityEngine;

namespace GamePlay.Player
{
    public class PlayerScript : MonoBehaviour
    {
        [SerializeField] private float _speed = default;
        [SerializeField] private Rigidbody _rigidbody = default;

        private static PlayerScript _instance;
        
        private Vector3 _direction = new Vector3(0,0,0);

        public static PlayerScript Instance => _instance;

        private void Awake()
        {
            _instance = this;
        }
        
        private void Update()
        {
            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _direction * _speed;
        }
    }
}