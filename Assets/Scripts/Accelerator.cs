using UnityEngine;

public class Accelerator : Base
{
    const float accelerationForce = 15f;

    // Give impulse to the player in the trigger direction
    public override void OnTriggerHandler()
    {
        PlayerController.Instance.playerRb.AddForce(transform.forward * accelerationForce, ForceMode.Impulse);
    }
}
