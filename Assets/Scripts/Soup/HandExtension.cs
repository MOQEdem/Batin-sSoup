using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandExtension : MonoBehaviour
{
    [SerializeField] private float _increaseRateOX;
    [SerializeField] private float _increaseRateOY;
    [SerializeField] private float _returnSpeed;
    [SerializeField] private FoodCatcher _foodCatcher;

    private Vector3 _normalScale;
    private float _maxIncreaseOX;
    private bool _isFoodCaght;

    private void OnEnable()
    {
        _foodCatcher.FoodCaught += OnFoodCaught;
        _foodCatcher.FoodReleased += OnFoodReleased;
    }

    private void OnDisable()
    {
        _foodCatcher.FoodCaught -= OnFoodCaught;
        _foodCatcher.FoodReleased -= OnFoodReleased;
    }


    private void Start()
    {
        SetMaxIncreaseScaleLevelOne();
        _normalScale = transform.localScale;
        _isFoodCaght = false;
    }

    private void Update()
    {
        if (!_isFoodCaght)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (transform.localScale.x <= _maxIncreaseOX)
                {
                    transform.localScale += new Vector3(_increaseRateOX * Time.deltaTime, _increaseRateOY * Time.deltaTime, 0);
                }
            }
            else
            {
                if (transform.localScale != _normalScale)
                    transform.localScale = Vector3.MoveTowards(transform.localScale, _normalScale, _returnSpeed * Time.deltaTime);
            }
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

    private void SetMaxIncreaseScaleLevelOne()
    {
        _maxIncreaseOX = 0.5f;
    }

    public void SetMaxIncreaseScaleLevelTwo()
    {
        _maxIncreaseOX = 0.8f;
    }

    public void SetMaxIncreaseScaleLevelThree()
    {
        _maxIncreaseOX = 1.5f;
    }

    public void SetMaxIncreaseScaleLevelFour()
    {
        _maxIncreaseOX = 2f;
    }
}
