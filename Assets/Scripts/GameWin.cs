using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour
{
    [SerializeField] private Congratulation _congratulation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<FoodCatcher>(out FoodCatcher foodCatcher))
        {
            CongratulateWinner();
        }
    }

    private void CongratulateWinner()
    {
        _congratulation.gameObject.SetActive(true);
    }
}
