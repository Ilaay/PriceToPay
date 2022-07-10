using Unity.VisualScripting;
using UnityEngine;

namespace NPC
{
    public class CollidableObject : MonoBehaviour
    {
        public ContactFilter2D filter;
        private CapsuleCollider2D _collider;
        private readonly Collider2D[] _hits = new Collider2D[10];
    
        private void Awake()
        {
            _collider = gameObject.GetComponent<CapsuleCollider2D>();
        }

        private void Update()
        {
            _collider.OverlapCollider(filter, _hits);

            for (var i = 0; i < _hits.Length; i++)
            {
                if (_hits[i].IsUnityNull()) continue;

                _hits[i] = null;
            }
        }
    }
}
