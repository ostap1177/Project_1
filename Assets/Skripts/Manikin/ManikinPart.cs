using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManikinPart : MonoBehaviour
{
    [SerializeField] private int _health = 10;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform; 
    }

    public void TakeDamage(int damade)
    {
        if (_health > 0)
        {
            _health -= damade;
        }
        else
        {
            DisconnectPatr();
        }
    }

    private void DisconnectPatr()
    { 
        if(_transform.parent != null)
        {
            _transform.parent = null;   
        }
    }
}
