using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutrients : MonoBehaviour
{
    [SerializeField] protected string Name;
    [SerializeField] protected int Fats;
    [SerializeField] protected int Carbohydrates;
    [SerializeField] protected int Proteins;

    public string NameValue => Name;
    public int FatsValue => Fats;
    public int CarbohydratesValue => Carbohydrates;
    public int ProteinsValue => Proteins;
}
