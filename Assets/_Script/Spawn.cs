using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn : Singleton<Spawn>
{
    public Transform Hoder;

    public List<GameObject> Prefabs = new List<GameObject>();
    public List<GameObject> Prefabs_Disabled = new List<GameObject>();
    public GameObject SpawnOBJ(GameObject Prefab = null)
    {
        if(Prefab == null)
        {
            Debug.LogWarning("No see Prefab");
            return null;    
        }

        GameObject OBJ = CheckPrefabInPrefabs_Disabled(Prefab);

        if (OBJ == null)
            return null;

        if (OBJ.activeInHierarchy == false)
        {
            OBJ.SetActive(true);
        }

        OBJ.transform.SetParent(Hoder);
        return OBJ; 
    }
    public GameObject SpawnOBJ(GameObject Prefab, Vector3 PositionSpawner)
    {
        if (Prefab == null)
        {
            Debug.LogWarning("No see Prefab");
            return null;
        }

        GameObject OBJ = CheckPrefabInPrefabs_Disabled(Prefab);

        if (OBJ == null)
            return null;
        OBJ.transform.position = PositionSpawner;
        if (OBJ.activeInHierarchy == false)
        {
            OBJ.SetActive(true);
        }

        OBJ.transform.SetParent(Hoder);
        return OBJ;
    }

    public GameObject CheckPrefabInPrefabs(GameObject Prefab)
    {
        foreach(GameObject i in Prefabs)
        {
            if(i == Prefab)
            {
                return i;
            }
        }

        return null;
    }

    private GameObject CheckPrefabInPrefabs_Disabled(GameObject Prefab)
    {
        foreach (GameObject i in Prefabs_Disabled)
        {
            if (i == null)
            { 
                continue;
            }
            if (i.name == Prefab.name)
            {
                Prefabs_Disabled.Remove(i);
                return i;
            }
        }

        GameObject OBJ = CheckPrefabInPrefabs(Prefab);
        
        if(OBJ == null) 
            return null;

        GameObject newOBJ = Instantiate(OBJ);
        newOBJ.name = Prefab.name;
        return newOBJ;
    }

    public void Despawn(GameObject OBJ)
    {
        OBJ.SetActive(false);
        Prefabs_Disabled.Add(OBJ);
    }
}

