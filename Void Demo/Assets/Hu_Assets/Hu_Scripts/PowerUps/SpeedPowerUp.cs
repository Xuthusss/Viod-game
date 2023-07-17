using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    
    [SerializeField]
    private float speedMultiplier;

    public override void TriggerPowerUp()
    {
        playerScript.moveSpeed *= speedMultiplier;
        base.TriggerPowerUp();
    }
}
