using UnityEngine;
using System.Collections;

/*	SkyController
	Scrolls Sky Background
*/
public class SkyController : MonoBehaviour {
	// PRIVATE VARIABLES
	private int _speed;
    private Transform _transform;

	// PUBLIC PROPERTIES
	public int Speed {
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
	void Start () 
	{
        this._transform = this.GetComponent<Transform>(); // Transform Component in _transform Variable
		this._speed = 2;
	}
	
	// Update is called once per frame
	void Update () 
	{
        this._move();
        this._checkBoundary();
	}

    // Move method moves background game object sideway towards left by _speed
    private void _move()
    {
        // Take current position and put into new position
        Vector2 newPosition = this._transform.position;
        newPosition.x -= this._speed;
        // Assigning newPosition to this (SKyBackground's) position
        this._transform.position = newPosition;
    }

    // Checks boundary of game object
    private void _checkBoundary()
    {
        if(this._transform.position.x == -640)
        {
            this._reset();            
        }
    }

    // Resets sky background game object's position
    private void _reset()
    {
        this._transform.position = new Vector2(640f, 0f);
    }
}
