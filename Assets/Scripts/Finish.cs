using UnityEngine;

public class Finish : Base
{
    // Finish the game
    public override void OnTriggerHandler()
    {
        Debug.Log("You reach the finish!");
    }
}
