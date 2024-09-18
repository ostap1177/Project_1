using System.Collections.Generic;
using UnityEngine;

public class Manikin : MonoBehaviour
{
    [SerializeField] private int _healtPart = 10;
    [SerializeField] private int _waiteDestroy = 5;

    private List<ManikinPart> _manikinParts = new List<ManikinPart>();
    private Transform _transform;
    private WaitForSecondsRealtime _waitTime;

    private void Awake()
    {
        _transform = transform;

        CollectComponentsInChildren(_transform);
        
        _waitTime = new WaitForSecondsRealtime(_waiteDestroy);
        StartCoroutine(DelayDestroy());
    }

    private void CollectComponentsInChildren(Transform parent)
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
    }

    private IEnumerator<WaitForSecondsRealtime> DelayDestroy()
    {
        while (true)
        {
            yield return _waitTime;
            Destroy(gameObject);
        }
    }
}
