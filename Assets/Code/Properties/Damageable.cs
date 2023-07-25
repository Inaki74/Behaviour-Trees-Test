using UnityEngine;

namespace BehaviourTreeTests.Properties {
    public class Damageable : MonoBehaviour
    {
        [SerializeField]
        private int _maxHealth;

        private int _currentHealth;

        // Start is called before the first frame update
        void Start()
        {
            _currentHealth = _maxHealth;
        }

        // Update is called once per frame
        void Update()
        {
            if(_currentHealth <= 0f) {
                Destroy(gameObject);
            }
        }

        public void Damage(int damage) {
            _currentHealth -= damage;
        }
    }
}
