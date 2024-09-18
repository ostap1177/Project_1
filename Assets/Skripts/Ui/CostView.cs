using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CostView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void SetText(int cost)
    { 
        _text.text = cost.ToString();
    }

    public void EnableText(bool enable)
    {
        _text.enabled = enable;
    }
}
