using UnityEngine;
using UnityEngine.Events;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private bool _isClick = true;
    private int _clickCount = 0;

    public event UnityAction<bool> Clicked;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (TryGetHitTransform(out Transform transformHit, out Vector3 hitPoint))
            {
                if (transformHit.TryGetComponent(out Barriers barriers))
                {
                    _isClick = true;
                    barriers.SetPosition(hitPoint);
                    Clicked?.Invoke(_isClick);
                }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
            }
        }
        else
        {
            _isClick = false;
            Clicked?.Invoke(_isClick);
        }
    }

    private bool TryGetHitTransform(out Transform transform, out Vector3 hitPoint)
    {
        transform = null;
        hitPoint = Vector3.zero;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit) == true)
        {
            transform = hit.transform;
            hitPoint = hit.point;
        }

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

        return transform != null;
    }
}
