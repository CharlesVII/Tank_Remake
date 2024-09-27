using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnOBJ : MonoBehaviour
{
    public GameObject Hoder;

    public List<GameObject> Prefabs = new List<GameObject>();

    public ObjectSpawn ListSpawnPrefabs = new ObjectSpawn();

 
    public void Spawner(GameObject PrefabSpawn)
    {

    }

    public void Spawner(GameObject PrefabSpawn, Vector3 PositionSpawn)
    {

    }


}
[Serializable]
public class ObjectSpawn
{
    public Dictionary<bool, GameObject> SpawnPrefabs = new Dictionary<bool, GameObject>();
}
