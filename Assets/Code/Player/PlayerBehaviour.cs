using UnityEngine;
using BehaviourTreeTests.Projectiles;
using BehaviourTreeTests.Utility;

namespace BehaviourTreeTests.Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        // Configurations
        [SerializeField]
        private float _speed; 
        [SerializeField]
        private GameObject _projectile;
        [SerializeField]
        private float _attackCooldown;
        
        // Data
        private Vector2 _velocity;

        // Input
        private bool _fireInput;
        private float _horizontalInput;
        private float _verticalInput;
        private Vector2 _directionPlayerMouse;

        //Assitance
        private CooldownTimer _timer = new(0f);

        void Update() {
            _timer.Tick(Time.deltaTime);

            GetInput();
            
            Accelerate();
            Move(_velocity * Time.deltaTime);

            if(_fireInput && _timer.TimerEnded()) {
                Fire(_directionPlayerMouse);
            }
        }

        private void GetInput() {
            _horizontalInput = Input.GetAxisRaw("Horizontal");
            _verticalInput = Input.GetAxisRaw("Vertical");
            _fireInput = Input.GetMouseButtonDown(0) || Input.GetMouseButton(0);

            _directionPlayerMouse = GetPlayerMouseDirection();
        }

        private Vector2 GetPlayerMouseDirection() {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            return (mouseWorldPosition - (Vector2) transform.position).normalized;
        }

        private void Accelerate() {
            Vector2 directionMovement = 
                new Vector2(
                    _horizontalInput, 
                    _verticalInput);
            
            _velocity = directionMovement * _speed;
        }

        private void Move(Vector2 move) {
            transform.Translate(move);
        }

        private void Fire(Vector2 direction) {
            GameObject projectileGO = Instantiate(_projectile, transform.position, Quaternion.identity);

            LinearProjectile projectile = projectileGO.GetComponent<LinearProjectile>();
            projectile.Direction = direction;
            projectile.OwnerId = transform.root.GetInstanceID();

            _timer.SetTimer(_attackCooldown);
        }
    }
}

