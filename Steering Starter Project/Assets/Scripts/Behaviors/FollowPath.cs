using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : Seek
{
    public Kinematic[] wayPts;

    float closeEnoughRadius = 0.5f;

    int currWayPtNdx = 0;

    public override SteeringOutput getSteering()
    {
        if(target == null)
        {
            int closestWayPtNdx = 0;
            float closestDistance = float.PositiveInfinity;
            
            for(int i= 0; i < wayPts.Length; i++)
            {
                Kinematic wayPt = wayPts[i];

                float wayPtDistance = (character.transform.position - wayPt.transform.position).magnitude;

                if(wayPtDistance < closestDistance)
                {
                    closestDistance = wayPtDistance;
                    closestWayPtNdx = i;
                }
            }

            target = wayPts[closestWayPtNdx].gameObject;
        }

        float targetDistance = (character.transform.position - target.transform.position).magnitude;

        if(targetDistance < closeEnoughRadius)
        {
            currWayPtNdx = (currWayPtNdx + 1) % wayPts.Length;
            target = wayPts[currWayPtNdx].gameObject;
        }

        return base.getSteering();
    }

}
