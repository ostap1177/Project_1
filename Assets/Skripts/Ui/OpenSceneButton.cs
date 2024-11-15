using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui
{
    public class OpenSceneButton : ParentButtons
    {
        [Space(10)]
        [SerializeField] private int _sceneNumber;

        override protected void Click()
        {
            SceneManager.LoadScene(_sceneNumber);
            Time.timeScale = 1.0f;  
        }
    }
}
