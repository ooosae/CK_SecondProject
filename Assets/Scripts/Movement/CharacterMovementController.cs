using UnityEngine;
using UnityEngine.UIElements;

namespace Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovementController : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 1f;
        [SerializeField]
        private float _maxRadiansDelta = 10f;
        
        public Vector3 MovementDirection { get; set; }
        public Vector3 LookDirection { get; set; }

        private CharacterController _characterController;
        private static readonly float SqrEpsilon = Mathf.Epsilon * Mathf.Epsilon;
        private float _speedMultiplier = 1f;

        protected void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        protected void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _speedMultiplier = 2f;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                _speedMultiplier = 1f;
            }
            Translate();
            if (_maxRadiansDelta > 0f && LookDirection != Vector3.zero)
                Rotate();
        }

        private void Translate()
        {
            var delta = MovementDirection * _speed * _speedMultiplier * Time.deltaTime;
            _characterController.Move(delta);
        }

        private void Rotate()
        {
            var currentLookDirection = transform.rotation * Vector3.forward;
            float sqrMagnitude = (currentLookDirection - LookDirection).sqrMagnitude;
            if (sqrMagnitude > SqrEpsilon)
            {
                var newRotation = Quaternion.Slerp(transform.rotation,
                                                    Quaternion.LookRotation(LookDirection, Vector3.up),
                                                    _maxRadiansDelta * Time.deltaTime);
                transform.rotation = newRotation;
            }
        }
    }
}
