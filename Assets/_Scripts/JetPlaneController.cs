using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic; // List

public class JetPlaneController : MonoBehaviour {
    // Private Instant Variables
    private Transform _transform;
    private Vector2 _currentPosition;
    private float _playerInput;
    private float _speed;


    // Public Instance Variables
	public GameController gameController;

	[Header("Sounds")]
    public AudioSource OuchSound;
    public AudioSource MoneySound;

	   
    // Use this for initialization
    void Start () {
        this._speed = 6;
		this._transform = this.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
        this._move();
		this._deductMoney();

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
			this._currentPosition -= new Vector2(0, this._speed);
        {
        }

        if (this._playerInput == 0)
        {
            this._currentPosition += new Vector2(0, 0);
        }

        this._transform.position = new Vector2(-230f, Mathf.Clamp(this._currentPosition.y, -190f, 190f));
    }

    // On Collide Method
    // Collider = For On Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Money"))
        {
            this.MoneySound.Play();
			this.gameController.MoneyValue += 500;
			MoneyController mc = (MoneyController)other.GetComponent (typeof(MoneyController));
			mc.Destroy ();
        }
        if(other.gameObject.CompareTag("Drone"))
		{
            this.OuchSound.Play();
			this.gameController.HealthValue -= 25;
			DroneController dc = (DroneController)other.GetComponent (typeof(DroneController));
			dc.Destroy ();
        }
    }

	// Private Method for Automatically Deducting Money
	private void _deductMoney()
	{
		this.gameController.MoneyValue -= 1;
	}


}
