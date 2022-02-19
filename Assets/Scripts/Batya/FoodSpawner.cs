using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private List<Food> _food;
    [SerializeField] private Transform _spawnSystem;
    [SerializeField] private float _movementToPointSpeed;

    private SpawnPoint[] _spawnPoints;
    private AudioSource _audioSource;

    public event UnityAction FoodSpawned;

    private void Start()
    {
        _spawnPoints = _spawnSystem.GetComponentsInChildren<SpawnPoint>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartSpawn()
    {
        StartCoroutine(Spawn());
        FoodSpawned?.Invoke();
    }

    private IEnumerator Spawn()
    {
        var spawnDelay = new WaitForSeconds(0.7f);

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            yield return spawnDelay;

            _audioSource.Play();

            if (_spawnPoints[i].IsEmpty)
            {
                var food = _food[Random.Range(0, _food.Count)];

                food.SetSpawnPoint(_spawnPoints[i]);

                var spawnedFood = Instantiate(food, transform.position, food.transform.rotation);

                spawnedFood.TakeSpawnPointPlace(_movementToPointSpeed);

                _spawnPoints[i].IsEmpty = false;
            }
        }
    }
}
