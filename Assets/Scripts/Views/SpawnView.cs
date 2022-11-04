using System.Collections;
using UnityEngine;

public class SpawnView : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject;

    public void EnableSpawn(float timeBetweenWaves)
    {
        StartCoroutine(SpawnEnemyWaves(timeBetweenWaves));
    }

    public void DisableSpawn()
    {
        StopAllCoroutines();
    }

    IEnumerator SpawnEnemyWaves(float timeBetweenWaves)
    {
        if (timeBetweenWaves > 0)
        {
            do
            {
                var spawnObject = Instantiate(_spawnObject,
                        gameObject.transform.position,
                        Quaternion.Euler(0, 0, 180),
                        transform);
                spawnObject.SetActive(true);
                yield return new WaitForSeconds(timeBetweenWaves);
            }
            while (timeBetweenWaves > 0);
        }
    }
}
