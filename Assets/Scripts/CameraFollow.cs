
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y + offset.y, transform.position.z);
    }
    
}
