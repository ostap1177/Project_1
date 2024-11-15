using UnityEngine;

namespace Ui
{
    public class BoardButton : ParentButtons
    {
        [Space(10)]
        [SerializeField] private UiBoard _uiBoard;

        override protected void Click()
        {
            if (_uiBoard.gameObject.activeSelf == false)
            {
                _uiBoard.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                _uiBoard.gameObject.SetActive(false);
            }
        }
    }
}