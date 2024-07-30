using UnityEngine;

[RequireComponent(typeof(Barrier))]
public class BarrierCollision : MonoBehaviour
{
    private Barrier _barrier;

    private void Awake()
    {
        _barrier = GetComponent<Barrier>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out ManikinPart manikinPart))
        {
            manikinPart.TakeDamage(_barrier.Damage);
            Debug.Log(_barrier.Damage);
        }
    }
}
