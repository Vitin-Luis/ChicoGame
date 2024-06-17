using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    public GameObject forestTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile(bool spawnItems)
    {
        GameObject groundTileInstance = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = groundTileInstance.transform.GetChild(1).transform.position;

        if (spawnItems)
        {
            groundTileInstance.GetComponent<GoundTile>().SpawnObstacle();
            groundTileInstance.GetComponent<GoundTile>().SpawnWine();
        }

        // Calculate positions for forestTile
        Vector3 forest1Position = groundTileInstance.transform.position + new Vector3(8, 0, 0);
        Vector3 forest2Position = groundTileInstance.transform.position + new Vector3(-9.8f, 0, 0);

        // Spawn ForestTile on each side and make them children of groundTileInstance
        GameObject forest1 = Instantiate(forestTile, forest1Position, Quaternion.identity, groundTileInstance.transform);
        GameObject forest2 = Instantiate(forestTile, forest2Position, Quaternion.identity, groundTileInstance.transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 2)
            {
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true);
            }
        }
    }
}
