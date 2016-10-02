using UnityEngine;
using System.Collections;

public class JetPlaneController : MonoBehaviour {
    // Private Instant Variables
    private Transform _transform;
    private Vector2 _currentPosition;
    private float _playerInput;
    private float _speed;
    private AudioSource[] Sounds;
    private AudioSource _ouchSound;
    private AudioSource _moneySound;

    // Public Instance Variables
    
    

    // Use this for initialization
    void Start () {
        this._speed = 6;
        this._transform = this.GetComponent<Transform>();	
        this.Sounds = this.GetComponents<AudioSource>();
        this._moneySound = this.Sounds[1];
        this._ouchSound = this.Sounds[2];
	}
	
	// Update is called once per frame
	void Update () {
        this._move();
	}

    // Move method
    private void _move()
    {
        // Set current position to current game object's position
        this._currentPosition = this._transform.position;

        // Gets Vertical Input Movement
        this._playerInput = Input.GetAxis("Vertical");

        if (this._playerInput > 0)
        {
            this._currentPosition += new Vector2(0, this._speed);
        }

        if (this._playerInput < -0)
        {
            this._currentPosition -= new Vector2(0, this._speed);
        }

        if (this._playerInput == 0)
        {
            this._currentPosition += new Vector2(0, 0);
        }

        this._transform.position = new Vector2(-240f, Mathf.Clamp(this._currentPosition.y, -190f, 190f));
    }

    // On Collide Method
    // Collider = For On Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Money"))
        {
            this._moneySound.Play();
        }
        if(other.gameObject.CompareTag("Drone"))
        {
            this._ouchSound.Play();
        }
    }

}
