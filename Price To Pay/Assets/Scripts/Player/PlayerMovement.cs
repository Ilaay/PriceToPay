using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        
        private SpriteRenderer _spriteRenderer;
        private Vector3 _moveDelta;
        private Transform _transform;
        private Animator _animator;

        private void Awake()
        {
            _spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
            _animator = this.gameObject.GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            _moveDelta = new Vector3(x, y, 0);

            /*_spriteRenderer.flipX = _moveDelta.x switch
            {
                > 0 => true,
                < 0 => false,
                _ => _spriteRenderer.flipX
            };*/
            if(_moveDelta.x > 0)
            {
                _animator.SetInteger("MoveDirection", 2);
                _spriteRenderer.flipX = false;

            }
            else if (_moveDelta.x < 0)
            {   
                _animator.SetInteger("MoveDirection", 2);
                _spriteRenderer.flipX = true;
            }
            else
            {
                _animator.SetInteger("MoveDirection", 0);
            }

            if (_moveDelta.y > 0)
            {
                _animator.SetInteger("MoveDirection", 3);

            }
            else if (_moveDelta.y < 0)
            {
                _animator.SetInteger("MoveDirection", 1);
            }
            else
            {
                _animator.SetInteger("MoveDirection", 0);
            }

            transform.Translate(_moveDelta * (moveSpeed * Time.deltaTime));
        }
    }
}