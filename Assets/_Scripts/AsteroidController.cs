using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {

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
        if (this._transform.position.x < -360f)
        {
            this._reset();
        }
        // Changes direction of vertical movement when reaches near y = 200 or y = -175
        if (this._transform.position.y > 200 || this._transform.position.y < -175)
        {
            this._drift *= -1;
        }
    }

    // Resets money game object's position
    private void _reset()
    {
        this._speed = Random.Range(2, 4);
        this._drift = Random.Range(-3, 3);
        this._transform.position = new Vector2(Random.Range(600f, 800f), Random.Range(-175, 200));
    }
}
