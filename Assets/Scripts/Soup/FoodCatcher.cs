using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class FoodCatcher : MonoBehaviour
{
    private Food _caughtFood;
    private AudioSource _audioSource;

    public Food CaughtFood => _caughtFood;

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
        if (_caughtFood == null)
            return false;
        else
            return true;
    }

    private void CatchFood(Food food)
    {
        _caughtFood = food;
        _audioSource.Play();
        FoodCaught?.Invoke();
    }

    private void ReleaseFood()
    {
        _caughtFood = null;
        FoodReleased?.Invoke();
    }
}
