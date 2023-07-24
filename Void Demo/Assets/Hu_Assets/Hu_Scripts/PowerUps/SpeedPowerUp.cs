using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    
    [SerializeField] private float speedMultiplier;
    private int timesActiated = 0;

    public override void TriggerPowerUp()
    {
        timesActiated++;
        playerScript.moveSpeed += 0.2f * timesActiated;
        //playerScript.moveSpeed *= speedMultiplier;
        base.TriggerPowerUp();
    }
}
