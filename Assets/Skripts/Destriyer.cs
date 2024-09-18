using UnityEngine;
using UnityEngine.Events;

public class Destriyer : MonoBehaviour
{
    public event UnityAction Destroed;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroed?.Invoke();
    }
}
