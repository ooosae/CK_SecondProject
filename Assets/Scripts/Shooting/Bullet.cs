using UnityEngine;

namespace Shooting
{
    public class Bullet : MonoBehaviour
    {
        public float Damage { get; private set; }

        private Vector3 _direcion;
        private float _flySpeed;
        private float _maxFlyDistance;
        private float _currentFlyDistance;
        

        public void Initialize(Vector3 direction, float flySpeed, float maxFlyDistance, float damage)
        {
            _direcion = direction;
            _flySpeed = flySpeed;
            _maxFlyDistance = maxFlyDistance;

            Damage = damage;
        }


        void Update()
        {
            var delta = _flySpeed * Time.deltaTime;
            _currentFlyDistance += delta;
            transform.Translate(_direcion * delta);

            if (_currentFlyDistance > _maxFlyDistance)
                Destroy(gameObject);
        }
    }
}