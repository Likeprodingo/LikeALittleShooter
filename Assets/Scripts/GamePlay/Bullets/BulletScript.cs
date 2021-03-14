using System;
using System.Collections;
using GamePlay.Enemy;
using GamePlay.Health;
using Pool;
using UnityEngine;

namespace GamePlay.Bullets
{
    public class BulletScript : PooledObject
    {
        [SerializeField] protected float _speed = default;
        [SerializeField] protected int _damage = default;
        [SerializeField] protected float _liveTime = default;
        [SerializeField] protected Rigidbody _rigidbody = default;
        
        private float _timeDelta = 0.1f;

        private Vector3 _direction;

        protected void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HealthScript health))
            {
                health.GetDamage(_damage);
                ObjectPool.Instance.FreeObject(this);
            }
        }

        protected override void BeforeReturnToPool()
        {
            base.BeforeReturnToPool();
            StopCoroutine(Move());
            StopCoroutine(Timer());
        }


        public void Shoot(Vector3 dir)
        {
            _direction = dir;
            StartCoroutine(Move());
            StartCoroutine(Timer());
        }

        private IEnumerator Move()
        {
            var waiter = new WaitForFixedUpdate();
            while (true)
            {
                _rigidbody.velocity = _speed * _direction;
                yield return waiter;
            }
        }

        private IEnumerator Timer()
        {
            var time = _liveTime;
            var waiter = new WaitForSeconds(_timeDelta);
            while (time > 0)
            {
                time -= _timeDelta;
                yield return waiter;
            }

            ObjectPool.Instance.FreeObject(this);
        }
    }
}