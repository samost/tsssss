using System;
using Data;
using UnityEngine;
using Zenject;

public class RocketMovement : MonoBehaviour
{
    private const float MaxVelocityToFxCalculate = 20f;
    [SerializeField]
    private RocketParam _rocketParam;
    [SerializeField]
    private ParticleSystem _engineFX;

    private Rigidbody _rigidbody;

    [Inject]
    private VariableJoystick _variableJoystick;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButton(0))
        {
            float zAxis = _variableJoystick.Direction.x * -90f;
            transform.rotation =
                Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, zAxis), _rocketParam.turnForce);
            _rigidbody.AddForce(transform.up * _rocketParam.engineForce, ForceMode.Force);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f),
                _rocketParam.turnForce * Time.deltaTime);
        }
        
        ProceedEngineFx(_rigidbody.velocity.y);
    }

    private void ProceedEngineFx(float velocity)
    {
        if (velocity > 0)
        {
            float scale = velocity / MaxVelocityToFxCalculate;
            _engineFX.transform.localScale = Vector3.one * scale;
        }
    }
}