using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreatLevel : MonoBehaviour
{
    [SerializeField] private Soup _soup;
    [SerializeField] private Slider _slider;
    [SerializeField] private FoodSpawner _foodSpawner;
    [SerializeField] private Image _image;
    [SerializeField] private GameLost _gameLost;

    private float _minValue;
    private float _maxValue;

    private float _valueIncreaseRate;
    private float _valueDecreaseRate;

    private void OnEnable()
    {
        _soup.FoodEaten += OnFoodEaten;
        _foodSpawner.FoodSpawned += OnFoodSpawned;
    }

    private void OnDisable()
    {
        _soup.FoodEaten -= OnFoodEaten;
        _foodSpawner.FoodSpawned -= OnFoodSpawned;
    }

    private void Start()
    {
        _minValue = _slider.minValue;
        _maxValue = _slider.maxValue;
        SetChangeRateLevelOne();
    }

    private void OnFoodSpawned()
    {
        _slider.value = Mathf.Clamp(_slider.value - _valueDecreaseRate, _minValue, _maxValue);
        SetColor();
    }

    private void OnFoodEaten()
    {
        _slider.value = Mathf.Clamp(_slider.value + _valueIncreaseRate, _minValue, _maxValue);
        SetColor();
        CheckForEndGame();
    }

    private void SetColor()
    {
        if (_slider.value <= (_maxValue / 3))
            _image.color = new Color(1f, 1f, 1f);
        else if (_slider.value <= (_maxValue / 3 * 2))
            _image.color = new Color(1f, 0.65f, 1f);
        else
            _image.color = new Color(1f, 0.3f, 1f);
    }

    private void CheckForEndGame()
    {
        if (_slider.value == _maxValue)
        {
            _gameLost.RegretLoser();
        }
    }

    private void SetChangeRateLevelOne()
    {
        _valueDecreaseRate = 3;
        _valueIncreaseRate = 3;
    }

    public void SetChangeRateLevelTwo()
    {
        _valueDecreaseRate = 4;
        _valueIncreaseRate = 2;
    }

    public void SetChangeRateLevelThree()
    {
        _valueDecreaseRate = 5;
        _valueIncreaseRate = 1;
    }

    public void SetChangeRateLevelFour()
    {
        _valueDecreaseRate = 10;
        _valueIncreaseRate = 0;
    }
}
