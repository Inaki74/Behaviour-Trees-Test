using UnityEngine;
using BehaviourTreeTests.Properties;

namespace BehaviourTreeTests.Projectiles {
    public class LinearProjectile : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        private Vector2 _direction;
        public Vector2 Direction { get => _direction; set => _direction = value.normalized; }

        private int _ownerId = -1;
        public int OwnerId { get => _ownerId; set => _ownerId = value; }

        // Start is called before the first frame update
        void Start()
        {
            GetComponent<Hazard>().OwnerId = _ownerId;
        }

        // Update is called once per frame
        void Update()
        {
            float zRotation = Vector2.SignedAngle(Vector2.up, _direction);

            transform.rotation = Quaternion.Euler(0f, 0f, zRotation);

            Move(Vector2.up * _speed * Time.deltaTime);
        }

        private void Move(Vector2 move) {
            transform.Translate(move);
        }

        private void OnTriggerEnter2D(Collider2D collider) {
            Debug.Log("Collision: " + collider.tag);

            if (collider.tag == "Terrain") {
                Destroy(gameObject);
            }
        }
    }
}
