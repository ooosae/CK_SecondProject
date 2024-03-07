using UnityEngine;

namespace Shooting
{

    public class ShootingController : MonoBehaviour
    {
        public bool HasTarget => _target != null;
        public Vector3 TargetPosition => _target.transform.position;

        private Weapon _weapon;
        private float _nextShotTimeSec;
        private GameObject _target;
        private Collider[] _colliders = new Collider[2];

        protected void Update()
        {
            _target = GetTarget();
            _nextShotTimeSec -= Time.deltaTime;

            if (_nextShotTimeSec < 0 )
            {        
                if (HasTarget)
                    _weapon.Shoot(TargetPosition);

                _nextShotTimeSec = _weapon.ShootFrequencySec;
            }
        }

        public void SetWeapon(Weapon weaponPrefab, Transform hand)
        {
            _weapon = Instantiate(weaponPrefab, hand);
            _weapon.transform.localPosition = Vector3.zero;
            _weapon.transform.localRotation = Quaternion.identity;
        }

        private GameObject GetTarget()
        {
            GameObject target = null;
            var position = _weapon.transform.position;
            var radius = _weapon.ShootRadius;

            int objectLayer = gameObject.layer;
            LayerMask targetMask;

            if (objectLayer == LayerUtils.EnemyLayer)
            {
                targetMask = LayerUtils.PlayerMask;
            }
            else if (objectLayer == LayerUtils.PlayerLayer)
            {
                targetMask = LayerUtils.EnemyMask;
            }
            else
            {
                return null;
            }

            var targetSize = Physics.OverlapSphereNonAlloc(position, radius, _colliders, targetMask);

            for (int i = 0; i < targetSize; ++i)
            {
                if (_colliders[i].gameObject != gameObject)
                {
                    target = _colliders[i].gameObject;
                    break;
                }
            }

            return target;
        }
    }
}