using System;
using UnityEngine;

namespace GameFlow
{
    public class DeathGameScript : MonoBehaviour
    {
        [SerializeField] private GameObject firstGameCardGarden, firstGameCardDog, firstGameCardHouse;
        [SerializeField] private GameObject secondGameCardHealth, secondGameCardFamily, secondGameCardMoney;
        
        private void Start()
        {
            SelectGameToStart();
        }

        private void SelectGameToStart()
        {
            if (!GameProgressTracker.FirstGameFinished) StartFirstGame();
            else if(!GameProgressTracker.SecondGameFinished) StartSecondGame();
            else if(!GameProgressTracker.ThirdGameFinished) StartThirdGame();
        }

        private void StartFirstGame()
        {
            print("First game started");

            ShowCard(firstGameCardGarden);
            ShowCard(firstGameCardDog);
            ShowCard(firstGameCardHouse);

            GameProgressTracker.FirstGameFinished = true;
        }

        private void StartSecondGame()
        {
            print("Second game started");

            ShowCard(secondGameCardHealth);
            ShowCard(secondGameCardFamily);
            ShowCard(secondGameCardMoney);

            GameProgressTracker.SecondGameFinished = true;
        }

        private void StartThirdGame() //--
        {
            print("Third game started");

            ShowCard(secondGameCardHealth);
            ShowCard(secondGameCardFamily);
            ShowCard(secondGameCardMoney);

            GameProgressTracker.SecondGameFinished = true;
        }

        private void ShowCard(GameObject card)
        {
            var cardPosition = card.transform.position;
            card.transform.position = new Vector3(cardPosition.x, cardPosition.y + 1, cardPosition.z);
        }
    }
}
