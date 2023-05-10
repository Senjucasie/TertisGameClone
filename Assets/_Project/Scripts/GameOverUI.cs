using UnityEngine.UI;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]private GameObject _gameOverPanel;
    [SerializeField]private Button _restartButton;
     private void Start() 
     {
    
        GameController.Instance.OnGameOver+=ShowGameOverPanel;
        _restartButton.onClick.AddListener(() => { GameController.Instance.ReloadScene(); });
     } 
    
        
    private void OnDestroy() 
    {
        GameController.Instance.OnGameOver-=ShowGameOverPanel;    
    }
    private void ShowGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
    }
    
}
