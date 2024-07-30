using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BarrierCollision))]
[RequireComponent(typeof(BarrierTurn))]

public class Barrier : MonoBehaviour
{
    private int _damage = 5;
    private List<Barrier> _barriersView = new List<Barrier>();

    public int Damage => _damage;

    public void SetDamaga(int damage)
    { 
        _damage = damage;
    }
}
