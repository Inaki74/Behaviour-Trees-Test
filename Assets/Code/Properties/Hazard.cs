using UnityEngine;

namespace BehaviourTreeTests.Properties {
    public class Hazard : MonoBehaviour
    {
        [SerializeField]
        private int _damage;

        [SerializeField]
        private bool _oneTime;

        private int _ownerId = -1;
        public int OwnerId { get => _ownerId; set => _ownerId = value; }

        private void OnTriggerEnter2D(Collider2D collision) {
            Damageable damageable = collision.GetComponent<Damageable>();

            if(damageable != null && collision.transform.root.GetInstanceID() != _ownerId){
                damageable.Damage(_damage);

                if(_oneTime) {
                    Destroy(gameObject);
                }
            }
        }
    }
}
