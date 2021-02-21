using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : Flee
{
    float maxTimeToPredict = 5f;

    protected override Vector3 getTargetPosition()
    {
        float targetDistance = (character.transform.position - target.transform.position).magnitude;
        float currSpeed = character.linearVelocity.magnitude;

        float currPredictionTime;

        if (currSpeed <= targetDistance / maxTimeToPredict)
            currPredictionTime = maxTimeToPredict;
        else
            currPredictionTime = targetDistance / currSpeed;

        Kinematic movingTarget = target.GetComponent<Kinematic>();

        if (movingTarget == null)
            return base.getTargetPosition();

        return (movingTarget.linearVelocity * currPredictionTime) - target.transform.position;
    }
}
