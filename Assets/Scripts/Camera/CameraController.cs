using UnityEngine;
using System;

namespace Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private PlayerCharacter _player;
        [SerializeField]
        private Vector3 _followCameraOffset = Vector3.zero;
        [SerializeField]
        private Vector3 _rotationOffset = Vector3.zero;

        protected void Awake()
        {
            if (_player == null)
                throw new NullReferenceException($"Follow camera can't follow null player - {nameof(_player)}");
        }

        void LateUpdate()
        {
            Vector3 targetRotation = _rotationOffset - _followCameraOffset;
            if (_player != null)
            {
                transform.position = _player.transform.position + _followCameraOffset;
                transform.rotation = Quaternion.LookRotation(targetRotation, Vector3.up);
            }
        }
    }
}