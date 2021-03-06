﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkTowerBehavior : BaseTowerBehavior {
	
    public float stunnTime = 1f;

    protected override void fire() 
    {
        base.fire();

        if (target != null)
        {
            Vector2 currPos = new Vector2(this.gameObject.transform.position.x,
                this.gameObject.transform.position.y  + 0.5f);

            Vector2 tarPos = target.position;
            GameObject cannonBall = CannonBallFactory.getInstance().generateCannonBall(currPos, tarPos, BallType.DrinkBall);
            cannonBall.GetComponent<DrinkBallBehavior>().target = target.gameObject;
            cannonBall.GetComponent<DrinkBallBehavior>().damage = damage; 
            cannonBall.GetComponent<DrinkBallBehavior>().stunnTime = stunnTime; 
        }

    }

    protected override void loadTowerProperties()
    {
        stunnTime = d.DrinkTowerStunTime[lv];

        interval = d.DrinkTowerFireInterval[lv];
        damage = d.DrinkTowerDamage[lv];
        value = (int)Mathf.Floor(d.DrinkTowerPrice[lv] * 0.5f);
    }

}
