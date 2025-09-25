using UnityEngine;

public class BoundaryManager : MonoBehaviour
{
    public float minX = -15f;
    public float maxX = 15f;
    public float minZ = -15f;
    public float maxZ = 15f;

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 playerPos = player.transform.position;
            playerPos.x = Mathf.Clamp(playerPos.x, minX, maxX);
            playerPos.z = Mathf.Clamp(playerPos.z, minZ, maxZ);
            player.transform.position = playerPos;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Vector3 enemyPos = enemy.transform.position;
            enemyPos.x = Mathf.Clamp(enemyPos.x, minX, maxX);
            enemyPos.z = Mathf.Clamp(enemyPos.z, minZ, maxZ);
            enemy.transform.position = enemyPos;
        }
    }
}