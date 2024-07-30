using UnityEngine;

public class BarrierTurn : MonoBehaviour
{
    private float _speedRotate = -1;

    private Vector3 _rotation;    
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _rotation = new Vector3(0, 0, _speedRotate);
    }

    private void Update()
    {
        RotateBarrier();
    }

    public void SetSpeed(int speedRotate)
    {
        _speedRotate = speedRotate;
    }

    private void RotateBarrier()
    {
        _transform.Rotate(_rotation);
    }
}
