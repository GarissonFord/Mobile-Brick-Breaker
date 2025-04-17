using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject victoryMenu;

    [SerializeField] public int numberOfBricks;
    [SerializeField] private GameObject[] bricks;

    private void Start()
    {
        DetermineNumberOfBricks();

        if (ball != null)
        {
            ball.BallEnteredDeadZone += OnBallEnteredDeadZone;
        }

        if (bricks != null)
        {
            foreach (GameObject brick in bricks)
            {
                Brick brickScript = brick.GetComponent<Brick>();
                brickScript.BrickDestroyed += OnBrickDestroyed;
            }
        }     
    }

    private void OnBallEnteredDeadZone()
    {
        TriggerGameOver();
    }

    private void OnBrickDestroyed()
    {
        numberOfBricks--;
        // DetermineNumberOfBricks();
        if (numberOfBricks <= 0)
        {
            ShowVictoryMenu();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void TriggerGameOver()
    {
        gameOverMenu.SetActive(true);
    }

    private void ShowVictoryMenu()
    {
        victoryMenu.SetActive(true);
        // temporary messy solution
        Destroy(ball.gameObject);
    }

    private void DetermineNumberOfBricks()
    {
        bricks = GameObject.FindGameObjectsWithTag("Brick");
        numberOfBricks = bricks.Length;
    }

    private void OnDestroy()
    {
        if (ball != null)
        {
            ball.BallEnteredDeadZone -= OnBallEnteredDeadZone;
        }

        /* if (brick != null)
        {
            brick.BrickDestroyed -= OnBrickDestroyed;
        } */
    }
}
