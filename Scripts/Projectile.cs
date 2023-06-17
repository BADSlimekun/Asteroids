using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float _speed = 100.0f;
    public float _maxlifetime = 10.0f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        _rb.AddForce(direction * this._speed);
        Destroy(this.gameObject,this._maxlifetime);
    }

    private void OnCollisionEnter2D(Collision2D collisiom)
    {
        Destroy(this.gameObject);
    }
}
