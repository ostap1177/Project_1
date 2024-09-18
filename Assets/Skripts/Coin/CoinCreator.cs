using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Barriers))]
public class CoinCreator : Spawner<Coin>
{
    [SerializeField] Vector3 _offset;

    private Barriers _barriers;
    private Transform _transform;
    private List<Barrier> _barrier;

    private Coroutine _coroutine;
    private WaitForSeconds _sleep;
    private int _sleepDuration = 2;

    public event UnityAction PlayedSound;

    private void OnEnable()
    {
        foreach (var barrierCollision in _barrier)
        {
            barrierCollision.CreateCoin += On�hargeCoin;
        }
    }

    private void OnDisable()
    {
        foreach (var barrierCollision in _barrier)
        {
            barrierCollision.CreateCoin -= On�hargeCoin;
        }
    }

    private void Awake()
    {
        _transform = transform;
        _barriers = GetComponent<Barriers>();
        _barrier = CollectBarrier();

        _sleep = new WaitForSeconds(_sleepDuration);
    }

    private void On�hargeCoin(int point, Vector3 position)
    {
        Coin coin = Spawn(position+_offset, Quaternion.identity);
        coin.SetText(point.ToString());
        coin.StartAnimation();
        _barriers.AddPoints(point);

        PlayedSound?.Invoke();

        StartCoroutine(Sleep(coin));
    }

    private List<BarrierCollision> CollectBarriersCollision()
    {
        List<BarrierCollision> temp = new List<BarrierCollision>();

        foreach (Transform child in _transform)
        {
            if (child.TryGetComponent(out BarrierCollision barriersPlace))
            {
                temp.Add(barriersPlace);
            }
        }

        return temp;
    }

    private List<Barrier> CollectBarrier()
    { 
        List<Barrier> temp = new List<Barrier>();

        foreach (Transform child in _transform)
        {
            if (child.TryGetComponent(out Barrier barrier))
            {
                temp.Add(barrier);
            }
        }

        return temp;
    }

    /* private void CollectComponentsInChildren(Transform parent)
     {
         if (parent.TryGetComponent(out ManikinPart component))
         {
             component.SetHealth(_healtPart);
             _manikinParts.Add(component);
         }

         foreach (Transform child in parent)
         {
             CollectComponentsInChildren(child);
         }
     }*/

    private IEnumerator<WaitForSeconds> Sleep(Coin coin)
    { 
        yield return _sleep;

        ReturnToPool(coin);
        coin.ResetFade();
    }
}