using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPowerUp : PowerUp
{
    [SerializeField]
    private float scaleAmount = 1.1f;
   
    public override void TriggerPowerUp()
    {
        base.TriggerPowerUp();
        player.transform.localScale = new Vector3(player.transform.localScale.x * scaleAmount,
                                                  player.transform.localScale.y * scaleAmount,
                                                  1);
    }
}
