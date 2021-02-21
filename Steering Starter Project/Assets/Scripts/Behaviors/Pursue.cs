using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : Seek
{
    float maxTimeToPredict = 5f;

    protected override Vector3 getTargetPosition()
    {
        float targetDistance = (target.transform.position - character.transform.position).magnitude;
        float currSpeed = character.linearVelocity.magnitude;

        float currPredictionTime;

        if (currSpeed <= targetDistance / maxTimeToPredict)
            currPredictionTime = maxTimeToPredict;
        else
            currPredictionTime = targetDistance / currSpeed;

        Kinematic movingTarget = target.GetComponent<Kinematic>();

        if(movingTarget == null)
            return base.getTargetPosition();

        return target.transform.position + (movingTarget.linearVelocity * currPredictionTime);
    }
}
