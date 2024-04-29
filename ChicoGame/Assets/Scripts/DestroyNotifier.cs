using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNotifier : MonoBehaviour
{
    private SpawnPrefabRandomly spawner;

    
    void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.InstanceDestroyed();
        }
    }

    
    public void SetSpawner(SpawnPrefabRandomly spawner)
    {
        this.spawner = spawner;
    }
}