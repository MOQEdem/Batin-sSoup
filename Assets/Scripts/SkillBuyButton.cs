using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SkillBuyButton : MonoBehaviour
{
    [SerializeField] private Soup _soup;
    [SerializeField] private int _skillCost;
    [SerializeField] private SkillShop _skillShop;

    private Button _button;
    private bool _isBought;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _isBought = false;
    }

    private void OnEnable()
    {
        if (_isBought)
        {
            _button.interactable = false;
        }
        else if (_soup.IsAbleToBuy(_skillCost))
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }

    }

    public void SetBoughtStatus()
    {
        _isBought = true;
    }

    public void SellSkill()
    {
        _soup.BuyAbility(_skillCost);
        _skillShop.Refresh();
    }
}
