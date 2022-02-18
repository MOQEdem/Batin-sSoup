using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _finish;

    public Transform Start => _start;
    public Transform Finish => _finish;
}
