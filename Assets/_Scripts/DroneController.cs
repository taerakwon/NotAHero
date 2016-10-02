using UnityEngine;
using System.Collections;

public class DroneController : MonoBehaviour {

 // PRIVATE VARIABLES
    private int _speed;
	private int _drift;
    private Transform _transform;

    // PUBLIC PROPERTIES
    public int Speed
    {
        get
        {
            return this._speed;
        }
        set
        {
            this._speed = value;
        }
    }


    // Use this for initialization
    void Start()
    {
        this._transform = this.GetComponent<Transform>(); // Transform Component in _transform Variable
        this._reset();
    }

    // Update is called once per frame
    void Update()
    {
        this._move();
        this._checkBoundary();
    }

    // Move method moves money game object sideway towards left by _speed
    private void _move()
    {
        // Take current position and put into new position
        Vector2 newPosition = this._transform.position;
        newPosition.x -= this._speed;
		newPosition.y += this._drift;
        // Assigning newPosition to this (SKyBackground's) position
        this._transform.position = newPosition;
    }

    // Checks boundary of game object
    private void _checkBoundary()
    {
        if (this._transform.position.x < -385f)
        {
            this._reset();
        }

        // If drone hits border, bounce them back to screen
		if (this._transform.position.y > 182f || this._transform.position.y < -161f)
		{
			this._drift *= -1;
		}
    }

    // Resets money game object's position
    private void _reset()
    {
        // Changes the speed of drone moving left
		this._speed = Random.Range(2, 4);
        // Changes the speed of drone moving up or down
		this._drift = Random.Range(1, 3);
        this._transform.position = new Vector2(Random.Range(600f, 800f), Random.Range(-161, 182));
    }
}
