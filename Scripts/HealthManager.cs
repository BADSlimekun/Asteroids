using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    // public GameManager GameManager;
    public GameManager GameManager;
    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyheart;

    private void Update()
    {
        for (int i=0; i< hearts.Length; i++)
        {
            hearts[i].sprite = emptyheart;
        }
        for (int i=0; i<GameManager.lives; i++)
        {
            hearts[i].sprite = fullheart;
        }
    }
}
