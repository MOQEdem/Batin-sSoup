using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLost : MonoBehaviour
{
    [SerializeField] private Regrets _regrets;

    public void RegretLoser()
    {
        _regrets.gameObject.SetActive(true);
    }
}
