using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        
        private SpriteRenderer _spriteRenderer;
        private Vector3 _moveDelta;
        private Transform _transform;

        private void Awake()
        {
            _spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            _moveDelta = new Vector3(x, y, 0);

            _spriteRenderer.flipX = _moveDelta.x switch
            {
                > 0 => true,
                < 0 => false,
                _ => _spriteRenderer.flipX
            };

            transform.Translate(_moveDelta * (moveSpeed * Time.deltaTime));
        }
    }
}