using UnityEngine;

public abstract class Base : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // If collided with the player, call OnTriggerHandler
        if (other.CompareTag("Player") && !GameManager.Instance.isGameOver && !GameManager.Instance.isGamePaused)
        {
            OnTriggerHandler();
        }
    }

    public abstract void OnTriggerHandler();
}
