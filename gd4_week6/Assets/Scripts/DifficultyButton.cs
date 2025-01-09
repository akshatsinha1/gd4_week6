using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    Button _difficultyButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _difficultyButton = GetComponent<Button>();
        _difficultyButton.onClick.AddListener(setDifficulty);
    }

  void setDifficulty()
    {
        FindFirstObjectByType<GameManager>().spawnRate = new Vector2(0, 1);
    }
}
