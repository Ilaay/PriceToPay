using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        private Vector3 _moveDelta;

        #region Cached Properties

        private int _currentState;

        private static readonly int IdleSide = Animator.StringToHash("Idle Side Main Character Animation");
        private static readonly int IdleUp = Animator.StringToHash("Idle Up Main Character Animation");
        private static readonly int IdleDown = Animator.StringToHash("Idle Down Main Character Animation");

        private static readonly int WalkSide = Animator.StringToHash("Walk Side Main Character Animation");
        private static readonly int WalkUp = Animator.StringToHash("Walk Up Main Character Animation");
        private static readonly int WalkDown = Animator.StringToHash("Walk Down Main Character Animation");

        #endregion

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

            if (_moveDelta.x != 0) _spriteRenderer.flipX = _moveDelta.x < 0;
            transform.Translate(_moveDelta * (moveSpeed * Time.deltaTime));

            var state = GetState();

            if (state == _currentState) return;
            _animator.CrossFade(state, 0, 0);
            _currentState = state;
        }

        private int GetState()
        {
            if (_moveDelta.x == 0 && _moveDelta.y == 0)
            {
                return ReturnLastPlayerDirection();
            }

            if (_moveDelta.x != 0)
            {
                return WalkSide;
            }

            if (_moveDelta.y != 0 && _moveDelta.x == 0)
            {
                switch (_moveDelta.y)
                {
                    case > 0:
                        return WalkUp;
                    case < 0:
                        return WalkDown;
                }
            }

            return IdleSide;
        }

        private int ReturnLastPlayerDirection()
        {
            if (_currentState == WalkSide) return IdleDown;
            if (_currentState == WalkDown) return IdleDown;
            if (_currentState == WalkUp) return IdleUp;
            if (_currentState == IdleUp) return IdleUp;
            if (_currentState == IdleDown) return IdleDown;

            return IdleSide;
        }
    }
}