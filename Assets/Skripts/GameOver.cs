using UnityEngine;

namespace Ui
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private UiBoard _boardFinal;

        private void OnEnable()
        {
            _scoreCounter.OveredGame += OnOverGame;
        }

        private void OnDisable()
        {
            _scoreCounter.OveredGame -= OnOverGame;
        }

        private void OnOverGame()
        {
            _boardFinal.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}