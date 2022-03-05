using UnityEngine;

public class Finish : Base
{
    [SerializeField] MainManager mainManager;

    // Finish the game
    public override void OnTriggerHandler()
    {
        mainManager.GameOver();
    }
}
