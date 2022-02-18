using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShop : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void Refresh()
    {
        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
}
