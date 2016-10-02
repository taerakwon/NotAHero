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
    private void _reset()
    {
        this._transform.position = new Vector2(Random.Range(800f, 1200f), Random.Range(-161, 182));
    }
}
