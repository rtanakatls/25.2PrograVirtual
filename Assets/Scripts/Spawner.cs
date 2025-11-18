using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject packPrefab;
    [SerializeField] private float spawnInterval;
    [SerializeField] private float spawnRange;

    private void Awake()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            GameObject obj= Instantiate(packPrefab);
            obj.transform.position = new Vector3(
                transform.position.x,
                Random.Range(-spawnRange, spawnRange),
                transform.position.z
                );
            yield return new WaitForSeconds(spawnInterval);
        }
    }

}
