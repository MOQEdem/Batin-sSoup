using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Soup : Nutrients
{
    private FoodCatcher _foodCatcher;
    private AudioSource _audioSource;

    public event UnityAction FoodEaten;
    public event UnityAction SkillBought;

    private void Start()
    {
        _foodCatcher = GetComponentInChildren<FoodCatcher>();
        _audioSource = GetComponent<AudioSource>();
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
        _audioSource.Play();
        Fats += _foodCatcher.Caught.FatsValue;
        Carbohydrates += _foodCatcher.Caught.CarbohydratesValue;
        Proteins += _foodCatcher.Caught.ProteinsValue;
        _foodCatcher.Choosen.Free();
        _foodCatcher.Caught.BeAbsorbed();

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
