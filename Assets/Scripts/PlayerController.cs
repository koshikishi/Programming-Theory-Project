using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    const float speed = 2f;

    Color _PlayerColor;
    public Color PlayerColor {
        get { return _PlayerColor; }
        set
        {
            if (value.a < 1f)
            {
                Debug.LogError("Color must be opaque!");
            }
            else
            {
                _PlayerColor = value;
            }
        }
    }

    public Rigidbody playerRb { get; private set; }
    [SerializeField] Transform focalPoint;
    Material playerMat;

    void Awake()
    {
        Instance = this;
        _PlayerColor = Color.white;
    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerMat = GetComponent<Renderer>().material;
    }

    void FixedUpdate()
    {
        if (!GameManager.Instance.isGameOver && !GameManager.Instance.isGamePaused)
        {
            // Move the player forward and backward
            float forwardInput = Input.GetAxis("Vertical");
            playerRb.AddForce(speed * forwardInput * focalPoint.forward);
        }
    }

    void LateUpdate()
    {
        // Move the camera focal point with the player
        focalPoint.position = gameObject.transform.position;
    }

    // Change the player color
    public void ChangeColor(Color c)
    {
        playerMat.color = c;
        _PlayerColor = c;
    }
}
