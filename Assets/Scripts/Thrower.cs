using UnityEngine;

public class Thrower : Base
{
    const float throwForce = 7.5f;

    // Give impulse to the player in the upward direction
    public override void OnTriggerHandler()
    {
        PlayerController.Instance.playerRb.AddForce(transform.up * throwForce, ForceMode.Impulse);
    }
}
