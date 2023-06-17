using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public Sprite[] sprites;
    private Rigidbody2D _rb;
    public float asteroidsize = 1.0f;
    public float minsize = 0.75f;
    public float maxsize = 2.0f;
    public float _speed = 150.0f;
    public float maxlifetime = 15.0f;
    
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.asteroidsize;
        _rb.mass = this.asteroidsize * 10.0f;
    }

    public void settrajectory(Vector2 direction)
    {
        _rb.AddForce(direction * _speed);
        Destroy(this.gameObject,this.maxlifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile"){
            Destroy(this.gameObject);
            FindObjectOfType<GameManager>().AsteroidDestroyed(this);
            
        }
    }


}
