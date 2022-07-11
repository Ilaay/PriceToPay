using System.Collections.Generic;
using GameFlow;
using UnityEngine;

namespace Application
{
    public class CardScript : MonoBehaviour
    {
        [SerializeField] private GameObject cardOnTable;
        [SerializeField] private List<GameObject> sameSessionCards;
        private Transform _thisCardTransform, _thisCardImageTransform, _tableCardTransform, _tableCardImageTransform;
        private Animator _animator;
        private bool _isSelectedCard;

        private void Awake()
        {
            _tableCardTransform = cardOnTable.transform.GetChild(0).GetComponent<Transform>();
            _tableCardImageTransform = cardOnTable.transform.GetChild(1).GetComponent<Transform>();
            _thisCardTransform = this.gameObject.transform.GetChild(0).GetComponent<Transform>();
            _thisCardImageTransform = this.gameObject.transform.GetChild(1).GetComponent<Transform>();
            _animator = this.gameObject.GetComponent<Animator>();
        }

        private void OnMouseOver()
        {
            //_animator.CrossFade("CardHovered", 0, 0);
        }

        private void OnMouseDown()
        {
            var thisCard = gameObject;
            _isSelectedCard = true;
            
            foreach (var card in sameSessionCards)
            {
                card.SetActive(false);
            }

            thisCard.transform.rotation = cardOnTable.transform.rotation;
            _thisCardTransform.rotation = _tableCardTransform.rotation;
            _thisCardImageTransform.rotation = _tableCardImageTransform.rotation;
            GameProgressTracker.AddToChosenCards(thisCard);
        }

        private void LateUpdate()
        {
            if (!_isSelectedCard) return;


            this.gameObject.transform.position =
                Vector3.Lerp(this.gameObject.transform.position, cardOnTable.transform.position, 0.02f);

            _thisCardTransform.position = 
                Vector3.Lerp(_thisCardTransform.position, _tableCardTransform.position, 0.02f);
            
            _thisCardImageTransform.position =
                Vector3.Lerp(_thisCardImageTransform.position, _tableCardImageTransform.position, 0.02f);
        }
    }
}