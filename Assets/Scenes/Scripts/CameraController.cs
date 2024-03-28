using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float smoothSpeed = 0.125f;
    private float startFollowXPosition = 0;
    public Vector3 offset;

    private bool _isFollowing = false;
    private bool _freezeYPosition = false;

    // Start is called before the first frame update
    void Start()
    {
        // Reset the camera position to the initial location
        transform.position = new Vector3(9.2f, -1.3f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isFollowing && player != null)
        {
            if (player.position.x >= startFollowXPosition)
            {
                _isFollowing = true;
            }
        }

        if (_isFollowing && player != null)
        {
            var desiredPosition = player.position + offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Debug log for player's X position
            //Debug.Log("Player X position: " + player.position.x);

            // Debug log for freezeYPosition
            //Debug.Log("_freezeYPosition: " + _freezeYPosition);

            // Check if player's x position is greater than or equal to 115.86f
            if (player.position.x >= 115.86f && !_freezeYPosition)
            {
                //Debug.Log("Unfreezing Y position");
                // Allow camera's position to follow player freely
                transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
            }
            else
            {
                //Debug.Log("Freezing Y position");
                // Fix camera's y position
                transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);
            }

           // Check if player's position is x = 145.01
            if (player.position.x >= 141f && player.position.x < 180.36f)
            {
               // Freeze the camera's Y position again
              _freezeYPosition = true;
            }
            else if ((player.position.x >= 170f && player.position.x < 181f) || player.position.x >= 247f)
            {
              _freezeYPosition = true;
            }
            else
            {
                _freezeYPosition = false;
            }

            if (player.position.x >= 460f && player.position.x < 482f || (player.position.x >= 495.8f && player.position.x < 503f))
            {
                // Allow camera's Y position to follow player freely
                _freezeYPosition = false;
            }
            else if (player.position.x >= 581.9f)
            {
                _freezeYPosition = false;
            }
            else
            {
            // Freeze camera's Y position
            _freezeYPosition = true;
            }
        }      
}

    public void OnPlayerRespawn()
    {
        Debug.Log("Player respawned"); // Debug log to check if the method is being called

        // Reset camera's y position to -1.3f
        transform.position = new Vector3(transform.position.x, -1.3f, transform.position.z);
    }


}
