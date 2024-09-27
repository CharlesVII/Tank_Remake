using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletDespawnByTime : MonoBehaviour
{
    [SerializeField] private BulletCtrl bulletCtrl;
    [SerializeField] private float TimeByDespawn;

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(DespawnByTime());
    }

    IEnumerator DespawnByTime()
    {
        yield return new WaitForSeconds(TimeByDespawn);
        Spawn.Instance.Despawn(bulletCtrl.gameObject);

    }



}
