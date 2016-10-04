/* 
 * FILE: MoneyController.cs
 * AUTHOR: TAERA KWON
 * LAST MODIFIED BY: TAERA kWON
 * LAST MODIFIED DATE: OCT 3, 2016
 * PROGRAM DESCRIPTION: MONEY BEHAVIOUR CONTROLLER
 * REVISION HISTORY
 * 20161002: 	CREATED LOGICS THAT TRIGGER FOR MOVEMENT AND COLLISION WITH MONEY
 * 20161003:	UPDATED MONEY VALUE UPDATES
*/


using UnityEngine;
using System.Collections;

public class MoneyController : MonoBehaviour {

    // PRIVATE VARIABLES
    private int _speed;
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
        this._speed = 5;
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
        // Assigning newPosition to this (SKyBackground's) position
        this._transform.position = newPosition;
    }

    // Checks boundary of game object
    private void _checkBoundary()
    {
        if (this._transform.position.x < -345f)
        {
            this._reset();
        }
    }

    // Resets money game object's position
    public void _reset()
    {
        this._transform.position = new Vector2(Random.Range(800f, 1200f), Random.Range(-161, 182));
    }

	// Public Reset Method
	public void Destroy()
	{
		this._reset ();
	}
}
