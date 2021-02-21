using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : Align
{
    // TODO: override Align's getTargetAngle to face the target instead of matching it's orientation
    public override float getTargetAngle()
    {
        Vector3 vel = target.transform.position - character.transform.position;

        if(vel.magnitude == 0)
        {
            return character.transform.eulerAngles.y;
        }
        float targetAngle = Mathf.Atan2(vel.x, vel.z);
        targetAngle *= Mathf.Rad2Deg;
        return targetAngle;
    }
}
