using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float height = 10f;
    public float distance = 10f;

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 playerPos = player.transform.position;
            transform.position = new Vector3(playerPos.x, height, playerPos.z - distance);
        }
    }
}