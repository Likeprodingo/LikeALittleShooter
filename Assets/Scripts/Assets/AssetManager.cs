using UnityEngine;
using Util;

namespace Assets
{
    public partial class AssetManager : GameObjectSingleton<AssetManager>
    {
        [SerializeField] private PooledBullet[] _bullets = default;
        [SerializeField] private PooledGun[] _guns = default;
        [SerializeField] private PooledEnemy[] _enemies = default;

        public PooledEnemy[] Enemies => _enemies;

        public PooledBullet[] Bullets => _bullets;

        public PooledGun[] Guns => _guns;

        public PooledGun GetRandomGun()
        {
            return _guns[Random.Range(0, _guns.Length)];
        }
    }
}