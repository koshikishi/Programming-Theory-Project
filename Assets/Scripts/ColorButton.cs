using UnityEngine;

// INHERITANCE
public class ColorButton : Base
{
    [SerializeField] Renderer tintRenderer;

    // POLYMORPHISM
    // Change the player color to triggered button color
    public override void OnTriggerHandler()
    {
        PlayerController.Instance.ChangeColor(tintRenderer.material.color);
    }
}
