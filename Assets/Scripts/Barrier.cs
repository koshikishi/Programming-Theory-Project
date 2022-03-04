using UnityEngine;

public class Barrier : MonoBehaviour
{
    Collider barrierCollider;
    Color barrierColor;

    void Start()
    {
        barrierCollider = GetComponent<Collider>();
        Material barrierMat = GetComponent<Renderer>().material;
        barrierColor = new Color(barrierMat.color.r, barrierMat.color.g, barrierMat.color.b);
    }

    void Update()
    {
        // If the barrier and the player colors match, let the player pass through the barrier
        if (barrierColor == PlayerController.Instance.PlayerColor)
        {
            Vector3 closestPoint = barrierCollider.ClosestPointOnBounds(PlayerController.Instance.transform.position);
            float distance = Vector3.Distance(closestPoint, PlayerController.Instance.transform.position);

            barrierCollider.enabled = distance > 1f;
        }
        else if (!barrierCollider.enabled)
        {
            barrierCollider.enabled = true;
        }
    }
}
