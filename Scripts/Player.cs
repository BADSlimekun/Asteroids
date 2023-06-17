using UnityEngine;

public class Player : MonoBehaviour
{
    public Projectile projectilePrefab;
    private bool _thrust;
    public float _thrustvelo = 1.0f ;
    private Rigidbody2D _rb;
    public float sensitivity = 1.0f;
    public AudioSource shootsound;
    public AudioSource emptyshootsound;
    private bool canshoot = true;
    public float _shootdelay = 0.3f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        _thrust = (Input.GetKey(KeyCode.Space));
        if (Input.GetMouseButtonDown(0)){
            if (canshoot == true) {
            shoot();
            canshoot=false;
            Invoke("shootdelay", _shootdelay);}
            else {emptyshootsound.Play();}
        }
    }

    private void shootdelay()
    {
        canshoot = true;
    }

    private void FixedUpdate()
    {
        if (_thrust) {
            _rb.AddForce(this.transform.up * _thrustvelo);
        }
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y-transform.position.y);
        transform.up = direction;
        
    }

    private void shoot()
    {
        Projectile projectile = Instantiate(this.projectilePrefab, this.transform.position, this.transform.rotation);
        projectile.Project(this.transform.up);
        shootsound.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.tag == "Enemy") {
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);

            FindObjectOfType<GameManager>().PlayerDied();
        }
    }

}
