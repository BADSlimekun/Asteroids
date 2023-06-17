
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    
    public Player player;
    public int lives = 3;
    public float _respawntime = 4.0f;
    public float Invulnerabilitytime = 4.0f;
    public ParticleSystem explosion;
    public GameObject GameOverUI;
    public int score = 0;
    public AudioSource asteroidsound;
    

    public void PlayerDied()
    {
        this.lives--; 
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();
        asteroidsound.Play();
        if (this.lives <= 0) {

            GameOver();

        }
        else {
            Invoke(nameof(Respawn),this._respawntime);
        }
    }

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();
        asteroidsound.Play();
        if (this.lives > 0) {
        if (asteroid.asteroidsize <0.8f) {score = score + 100;}
        else if (asteroid.asteroidsize < 1.5f) {score = score + 40;}
        else if (asteroid.asteroidsize < 2.0f) {score = score + 10;} 
        }
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.SetActive(true);
        this.player.gameObject.layer = LayerMask.NameToLayer("Invincibility");
        Invoke(nameof(TurnOnCollisions),this.Invulnerabilitytime);
    }

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        Debug.Log("GAME OVER");
        GameOverUI.SetActive(true);
    }
}
