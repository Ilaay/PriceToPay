using Application;
using UnityEngine;


namespace NPC
{
    public class DogBehaviourScript : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private bool _firstContactMade;
        
        private void Start()
        {
            _spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            CameraManager.UnfocusCamera();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if(!_firstContactMade) FirstDogContact();
        }

        private void FirstDogContact()
        {
            DogNoticesPlayer();
            
            CameraManager.FocusCameraOnObject(gameObject);
        }

        private void DogNoticesPlayer()
        {
            _firstContactMade = true;
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
    }
}
