using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceFromCamera;
    [SerializeField] private FoodCatcher _foodCatcher;
    [SerializeField] private Soup _soup;
    private Vector3 _mousePosition;
    private bool _isFoodCaght;

    private void OnEnable()
    {
        _foodCatcher.FoodCaught += OnFoodCaught;
        _foodCatcher.FoodReleased += OnFoodReleased;
        _soup.FoodEaten += OnFoodReleased;
    }

    private void OnDisable()
    {
        _foodCatcher.FoodCaught -= OnFoodCaught;
        _foodCatcher.FoodReleased -= OnFoodReleased;
        _soup.FoodEaten -= OnFoodReleased;
    }

    private void Start()
    {
        _isFoodCaght = false;
    }

    private void Update()
    {
        if (!_isFoodCaght)
        {
            _mousePosition = Input.mousePosition;
            _mousePosition.z = _distanceFromCamera;

            Vector3 MouseScreenToWorld = Camera.main.ScreenToWorldPoint(_mousePosition);

            transform.position = Vector3.MoveTowards(transform.position, MouseScreenToWorld, _speed * Time.deltaTime);
        }
    }

    private void OnFoodCaught()
    {
        _isFoodCaght = true;
    }

    private void OnFoodReleased()
    {
        _isFoodCaght = false;
    }
}
