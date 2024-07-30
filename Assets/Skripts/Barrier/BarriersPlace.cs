using Unity.VisualScripting;
using UnityEngine;

public class BarriersPlace : MonoBehaviour
{
    private Transform _transform;
    private Barriers _barriersChild;
    private bool _isFilled;
    private int _nextBarriar = 1; 

    public bool IsFilled => _isFilled;

    private void Awake()
    {
        _transform = transform;

        FindBarriers(); 

        _barriersChild.gameObject.SetActive(false);
        _isFilled = false;
    }

    /*  private void OnCollisionEnter(Collision trigger)
      {
          if (trigger.gameObject.TryGetComponent(out Barriers barriers))
          {
              if (_isFilled == false)
              {
                  FillPlace();
              }
              else if (_isFilled == false && barriers.BarrierNumber == _barriersChild.BarrierNumber)
              {
                  FillPlace();
                  _barriersChild.ActiveNetxBarrier();
              }
          }
      }*/

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.TryGetComponent(out Barriers barriers) && barriers !=_barriersChild)
        {
            if (_isFilled)  
            {
                if (barriers.BarrierIndex == _barriersChild.BarrierIndex 
                && _barriersChild.BarrierIndex <= _barriersChild.MaxCountBarriers)
                {
                    _barriersChild.ActiveToIndex(barriers.BarrierIndex + _nextBarriar);
                }
            }
            else
            {
                FillPlace(barriers.BarrierIndex);
            }
        }
    }

    public void FreeUpPlace()
    {
        _isFilled = false;
    }

    public void FillPlace(int index)
    {
        _barriersChild.gameObject.SetActive(true);
        _barriersChild.ActiveToIndex(_barriersChild.BarrierIndex);
        _isFilled = true;
    }

    private void InspectPlace()
    {
        if (transform.childCount > 0)
        { 
            _isFilled = false;
        }
        else
        {
            _isFilled = true;
        }
    }

    private void FindBarriers()
    {
        if (_transform.childCount > 0 && _transform.GetChild(0).TryGetComponent(out Barriers barriers))
        {
            _barriersChild = barriers;
        }
    }
}

