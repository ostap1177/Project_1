using UnityEngine;
using UnityEngine.Events;

public class ButtonClicker : MonoBehaviour
{
    public event UnityAction BuildedBarriers;
    public event UnityAction DropedManikin;
    public event UnityAction BoostedBarriers;

    public void DropManikin()
    {
        DropedManikin?.Invoke();
    }

    public void BuildBarriers()
    { 
        BuildedBarriers?.Invoke();
    }

    public void BoostBarriers()
    {
        BoostedBarriers?.Invoke();
    }
}
