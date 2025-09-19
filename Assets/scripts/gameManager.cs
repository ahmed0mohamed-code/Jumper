using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public Player player;
    private int score;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject ground;



    private void Awake()
    {
        Application.targetFrameRate = 60;
        puase();
    }

    public void puase()
    {
        Time.timeScale = 0;
        player.enabled = false;
    }

    public void play()
    {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        player.enabled = true;

        Time.timeScale = 1;
        lands[] lands = Object.FindObjectsOfType<lands>();
        for (int i = 0; i < lands.Length; i++)
        {
            Destroy(lands[i].gameObject);
        }
        
        player.transform.position = new Vector2(0, -3);
        ground.transform.position= new Vector2(0, -6);
    }

    public void Gameover()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        puase();
    }

    public void Increascore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}
