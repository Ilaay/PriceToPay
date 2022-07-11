using System.Collections.Generic;
using UnityEngine;

namespace GameFlow
{
    public static class GameProgressTracker
    {
        private static List<GameObject> _chosenCards;
        public static bool FirstGameFinished, SecondGameFinished, ThirdGameFinished;

        public static void AddToChosenCards(GameObject selectedCard)
        {
            _chosenCards.Add(selectedCard);
        }
    }
}
