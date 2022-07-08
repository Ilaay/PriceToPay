using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Vector3 _moveDelta;

        private void FixedUpdate()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            _moveDelta = new Vector3(x, y, 0);

            if (_moveDelta.x > 0)
            {
                transform.localScale = Vector3.one;
            } 
            else if (_moveDelta.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            
            transform.Translate(_moveDelta * Time.deltaTime);
        }
    }
}