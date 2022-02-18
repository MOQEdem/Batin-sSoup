using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoupInfoExplorer : MonoBehaviour
{
    [SerializeField] private TMP_Text _fats;
    [SerializeField] private TMP_Text _carbohydrates;
    [SerializeField] private TMP_Text _proteins;
    [SerializeField] private Soup _soup;

    private void OnEnable()
    {
        _soup.FoodEaten += OnNutrientsValueChanged;
        _soup.SkillBought += OnNutrientsValueChanged;
    }

    private void OnDisable()
    {
        _soup.FoodEaten -= OnNutrientsValueChanged;
        _soup.SkillBought -= OnNutrientsValueChanged;
    }

    private void Start()
    {
        OnNutrientsValueChanged();
    }

    private void OnNutrientsValueChanged()
    {
        _fats.text = $"F: {_soup.FatsValue.ToString()}";
        _carbohydrates.text = $"C: {_soup.CarbohydratesValue.ToString()}";
        _proteins.text = $"P: {_soup.ProteinsValue.ToString()}";
    }
}
