using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoodCatcher : MonoBehaviour
{
    private Food _caughtFood;

    public Food CaughtFood => _caughtFood;

    public event UnityAction FoodCaught;
    public event UnityAction FoodReleased;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Food>(out Food food))
        {
            _caughtFood = food;
            FoodCaught?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Food>(out Food food))
        {
            _caughtFood = null;
            FoodReleased?.Invoke();
        }
    }

    public bool IsFoodCaught()
    {
        if (_caughtFood == null)
            return false;
        else
            return true;
    }
}
