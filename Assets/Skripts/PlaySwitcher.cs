using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class PlaySwitcher : MonoBehaviour
{
    protected bool _isPlayin;

    abstract protected void Swithc();
}
