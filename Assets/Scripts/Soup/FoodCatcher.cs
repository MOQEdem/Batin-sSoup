using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class FoodCatcher : MonoBehaviour
{
    private Food _caughtFood;
    private SpawnPoint _choosenSpawnPoint;
    private AudioSource _audioSource;

    public Food Caught => _caughtFood;
    public SpawnPoint Choosen => _choosenSpawnPoint;

    public event UnityAction FoodCaught;
    public event UnityAction FoodReleased;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_caughtFood != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                ReleaseFood();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Food>(out Food food))
        {
            CatchFood(food);
        }
    }

    public bool IsFoodCaught()
    {
        return _caughtFood != null;
    }

    private void CatchFood(Food food)
    {
        _caughtFood = food;
        _choosenSpawnPoint = food.SpawnPoint;
        _audioSource.Play();
        FoodCaught?.Invoke();
    }

    private void ReleaseFood()
    {
        _caughtFood = null;
        _choosenSpawnPoint = null;
        FoodReleased?.Invoke();
    }
}
