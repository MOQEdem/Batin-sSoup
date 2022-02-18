using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(Food))]
public class FoodInfoExplorer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _fats;
    [SerializeField] private TMP_Text _carbohydrates;
    [SerializeField] private TMP_Text _proteins;

    private InfoWindow _infoWindow;
    private Food _food;

    private void Start()
    {
        _food = GetComponent<Food>();
        _infoWindow = GetComponentInChildren<InfoWindow>();
        _infoWindow.gameObject.SetActive(false);

        _name.text = _food.NameValue;
        _fats.text = $"F: {_food.FatsValue.ToString()}";
        _carbohydrates.text = $"C: {_food.CarbohydratesValue.ToString()}";
        _proteins.text = $"P: {_food.ProteinsValue.ToString()}";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _infoWindow.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _infoWindow.gameObject.SetActive(false);
    }
}
