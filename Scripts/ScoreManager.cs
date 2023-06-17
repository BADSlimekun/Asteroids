using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameManager GameManager;
    public Text _highscoretext;
    public Text _scoretext;
    private int highscore;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("_HighScore");
        _scoretext.text = "Score : " + GameManager.score.ToString();
        _highscoretext.text = "Highscore : " + highscore.ToString();

    }

    void Update()
    {
        if (GameManager.lives<=0) {
            if (GameManager.score > highscore) {
                    highscore = GameManager.score;
                    PlayerPrefs.SetInt("_HighScore",highscore);
                    PlayerPrefs.Save();
                    _highscoretext.text = "Highscore : " + highscore.ToString();
            }
        }
        _scoretext.text = "Score : " + GameManager.score.ToString();
    }
}
