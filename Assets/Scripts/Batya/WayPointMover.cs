using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WayPointMover : MonoBehaviour
{
    [SerializeField] private WayPoints _wayPoints;
    [SerializeField] private float _speed;

    private Transform _start;
    private Transform _finish;
    private Animator _animator;

    private void Start()
    {
        _start = _wayPoints.Start;
        _finish = _wayPoints.Finish;
        _animator = GetComponent<Animator>();
    }
    public void RunMovement()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        _animator.SetBool(AnimatorBatya.Params.IsRunning, true);

        transform.position = _start.position;

        while (transform.position != _finish.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _finish.position, _speed * Time.deltaTime);
            yield return null;
        }

        _animator.SetBool(AnimatorBatya.Params.IsRunning, false);
    }
}

public static class AnimatorBatya
{
    public static class Params
    {
        public const string IsRunning = nameof(IsRunning);
    }
}
