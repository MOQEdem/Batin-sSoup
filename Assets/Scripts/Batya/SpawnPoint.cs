using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool IsEmpty { get; private set; }

    private void Start()
    {
        IsEmpty = true;
    }

    public void Take()
    {
        IsEmpty = false;
    }

    public void Free()
    {
        IsEmpty = true;
    }
}
