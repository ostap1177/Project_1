using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    public void OpenSceneNumber(int gameSceneNumber)
    {
        SceneManager.LoadScene(gameSceneNumber);
    }
}
