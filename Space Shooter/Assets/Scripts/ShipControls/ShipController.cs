using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] ShipMovementInput _movementInput;

    [SerializeField] [Range(10f, 10000f)]
    float _thrustForce = 7500f, _pitchForce = 50f, _yawForce = 50f, _rollForce = 50f;

    Rigidbody _rigidbody;
    [SerializeField] [Range(-1f, 1f)]
    float _thrustAmount, _pitchAmount, _yawAmount, _rollAmount = 0f;

    IMovementControls ControlInput => _movementInput.MovementControls;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _pitchAmount = ControlInput.PitchAmount;
        _yawAmount = ControlInput.YawAmount;
        _rollAmount = ControlInput.RollAmount;
        _thrustAmount = ControlInput.ThrustAmount;
    }

    void FixedUpdate()
    {
        if (!Mathf.Approximately(0f, _pitchAmount))
        {
            _rigidbody.AddTorque(transform.right * (_pitchForce * _pitchAmount * Time.fixedDeltaTime));
        }

        if (!Mathf.Approximately(0f, _rollAmount))
        {
            _rigidbody.AddTorque(transform.forward * (_rollForce * _rollAmount * Time.fixedDeltaTime));
        }

        if (!Mathf.Approximately(0f, _yawAmount))
        {
            _rigidbody.AddTorque(transform.up * (_yawForce * _yawAmount * Time.fixedDeltaTime));
        }

        if (!Mathf.Approximately(0f, _thrustAmount))
        {
            _rigidbody.AddForce(transform.forward * (_thrustForce * _thrustAmount * Time.fixedDeltaTime));
        }
    }
}
