using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private GameObject gameOverMenu;

    private void Start()
    {
        if (ball != null)
        {
            ball.BallEnteredDeadZone += OnBallEnteredDeadZone;
        }
    }

    private void OnBallEnteredDeadZone()
    {
        Debug.Log("The ball has entered the dead zone");
        gameOverMenu.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
