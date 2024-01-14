using UnityEngine;

public class ShipEngine : MonoBehaviour
{
    [SerializeField] GameObject _thruster;

    IMovementControls _shipMovementControls;
    
    bool ThrustesEnabled => !Mathf.Approximately(0f, _shipMovementControls.ThrustAmount);

    void Update()
    {
        ActivateThrusters();
    }

    void ActivateThrusters()
    {
        _thruster.SetActive(ThrustesEnabled);
    }

    public void Init(IMovementControls movementControls)
    {
        _shipMovementControls = movementControls;
    }
}
