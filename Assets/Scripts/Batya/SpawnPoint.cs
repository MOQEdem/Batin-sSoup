using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private bool _isEmpty;

    public bool IsEmpty => _isEmpty;

    private void Start()
    {
        _isEmpty = true;
    }

    public void AcceptFood()
    {
        _isEmpty = false;
    }

    public void RejectFood()
    {
        _isEmpty = true;
    }
}
