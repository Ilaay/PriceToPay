using UnityEngine;

namespace NPC
{
    public class DogBehaviour : CollidableObject
    {
        protected override void OnCollide(Collider2D hit)
        {
            print("I am your dear Dog");
        }
    }
}
