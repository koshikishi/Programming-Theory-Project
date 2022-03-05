using UnityEngine;

public class ColorButton : Base
{
    [SerializeField] Renderer tintRenderer;

    // Change the player color to triggered button color
    public override void OnTriggerHandler()
    {
        PlayerController.Instance.ChangeColor(tintRenderer.material.color);
    }
}
