using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;
        private Rigidbody2D _rigidBody;
        private void Awake()
        {
            _rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        }

        private Vector2 _movement;

        private void Update()
        {
            _movement.x = Input.GetAxis("Horizontal");
            _movement.y = Input.GetAxis("Vertical");
        }

        private void FixedUpdate()
        {
            _rigidBody.MovePosition(_rigidBody.position + _movement * (moveSpeed * Time.deltaTime));
        }
    }
}
