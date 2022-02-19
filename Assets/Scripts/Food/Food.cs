using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Nutrients
{
    [SerializeField] private SpawnPoint _spawnPoint;

    public SpawnPoint SpawnPoint => _spawnPoint;

    public void BeAbsorbed()
    {
        Destroy(gameObject);
    }

    public void TakeSpawnPointPlace(float speed)
    {
        StartCoroutine(MoveToPoint(speed));
    }

    private IEnumerator MoveToPoint(float speed)
    {
        while (transform.position != _spawnPoint.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _spawnPoint.transform.position, speed * Time.deltaTime);
            yield return null;
        }
    }

    public void SetSpawnPoint(SpawnPoint spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }
}
