using UnityEngine;

// INHERITANCE
public class Finish : Base
{
    [SerializeField] MainManager mainManager;

    // POLYMORPHISM
    // Finish the game
    public override void OnTriggerHandler()
    {
        mainManager.GameOver();
    }
}
