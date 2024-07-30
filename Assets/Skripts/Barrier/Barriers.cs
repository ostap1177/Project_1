using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Barriers : MonoBehaviour
{
    [SerializeField] private int _damage = 3;
    [SerializeField] private int _speedRotate = -1;
    [SerializeField] private ClickHandler _clickHandler;
    [SerializeField] private List<Barrier> _barriers = new List<Barrier>();
    [SerializeField] private float _zPosition = 3f;

    private BarriersPlace _parentPlace;
    private Transform _transform;
    private int _barrierIndex = 0;
    private bool _isMoving = false;

    public bool IsMoving => _isMoving;
    public int MaxCountBarriers => _barriers.Count;
    public int BarrierIndex => _barrierIndex;

    private void OnEnable()
    {
        _clickHandler.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _clickHandler.Clicked -= OnClicked;
    }

    private void Awake()
    {
        _transform = transform;
        _parentPlace = _transform.parent.GetComponent<BarriersPlace>();
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.TryGetComponent(out BarriersPlace barriersPlace) && barriersPlace != _parentPlace)
        {
            ResetPosition();
            Disable();

            gameObject.SetActive(false); 
            _parentPlace.FreeUpPlace();
        }

       /* if (trigger.TryGetComponent(out Barriers barriers) && barriers.BarrierNumber == _barrierIndex && IsMoving == true)
        {
            barriers.ActiveNetxBarrier();
            Disable();
            ResetPosition();

            _collider.enabled = false;

            Destroy(gameObject);
        }*/
    }

/*    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out BarriersPlace barriersPlace))
        {
            Disable();
            ResetPosition();
        }
    }*/

/*    public void ActiveNetxBarrier()
    {
        _barrierIndex++;
        ActiveToIndex(_barrierIndex);
    }*/

    public void SetPosition(Vector3 position)
    {
        _transform.position = new Vector3(position.x, position.y, _zPosition);
    }

    public void ActiveToIndex(int index)
    {
        if (index < _barriers.Count)
        {
            Disable();
            Debug.Log($"index {index}");
            _barrierIndex = index;
            _barriers[index].gameObject.SetActive(true);
        }
    }

    private void Disable()
    {
        foreach (var barrier in _barriers)
        { 
            barrier.gameObject?.SetActive(false);
        }
    }

    private void ResetPosition()
    {
        _transform.position = _parentPlace.transform.position;
    }

    private void OnClicked(bool isClick)
    {
        _isMoving = isClick;

        if (isClick == false)
        {
            ResetPosition();
        }
    }

    private void SetValues()
    {
        foreach (var barrier in _barriers) 
        {
            if (barrier.TryGetComponent(out BarrierTurn barrierTurn))
            {
                barrierTurn.SetSpeed(_speedRotate);
            }

            barrier.SetDamaga(_damage);
        }
    }
}