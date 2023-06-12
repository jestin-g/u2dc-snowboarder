using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _torqueAmount = 10f;
    [SerializeField] private float _baseSpeed = 20f;
    [SerializeField] private float _boostSpeed = 35f;
    [SerializeField] private ParticleSystem _slidingEffect;
    private bool _controlsDisabled = false;


    private Rigidbody2D _rigidBody2D;
    private SurfaceEffector2D _surfaceEffector2D;

    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (_controlsDisabled) return;
        this.PlayerRotation();
        this.RespondToBoost();
    }

    public void DisableControls()
    {
        _controlsDisabled = true;
    }

    private void PlayerRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rigidBody2D.AddTorque(_torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rigidBody2D.AddTorque(-_torqueAmount);
        }
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _surfaceEffector2D.speed = _boostSpeed;
        }
        else
        {
            _surfaceEffector2D.speed = _baseSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Level")
            _slidingEffect.Play();

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Level")
            _slidingEffect.Stop();
    }
}
