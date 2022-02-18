using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Soup : Nutrients
{
    private FoodCatcher _foodCatcher;

    public event UnityAction FoodEaten;
    public event UnityAction SkillBought;

    private void Start()
    {
        _foodCatcher = GetComponentInChildren<FoodCatcher>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_foodCatcher.IsFoodCaught())
            {
                AbsorbFood();
            }
        }
    }

    private void AbsorbFood()
    {
        Fats += _foodCatcher.CaughtFood.FatsValue;
        Carbohydrates += _foodCatcher.CaughtFood.CarbohydratesValue;
        Proteins += _foodCatcher.CaughtFood.ProteinsValue;
        _foodCatcher.CaughtFood.BeAbsorbed();
        FoodEaten?.Invoke();
    }

    public bool IsAbleToBuy(int cost)
    {
        return Fats >= cost && Proteins >= cost && Carbohydrates >= cost;
    }

    public void BuyAbility(int cost)
    {
        Fats -= cost;
        Carbohydrates -= cost;
        Proteins -= cost;
        SkillBought?.Invoke();
    }
}
