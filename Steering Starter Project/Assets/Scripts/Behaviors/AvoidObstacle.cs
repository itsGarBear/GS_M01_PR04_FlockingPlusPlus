using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidObstacle : Seek
{
    public float minAvoidDistance = 3f;

    public float rayLength = 7f;

    protected override Vector3 getTargetPosition()
    {
        RaycastHit hit;
        if(Physics.Raycast(character.transform.position, character.linearVelocity, out hit, rayLength))
        {
            Debug.DrawRay(character.transform.position, character.linearVelocity.normalized * hit.distance, Color.red, 0.5f);
            Debug.Log("Collided with: " + hit.collider);
            return hit.point + (hit.normal * minAvoidDistance);
        }
        else
        {
            Debug.DrawRay(character.transform.position, character.linearVelocity.normalized * hit.distance, Color.green, 0.5f);
            Debug.Log("No Collision");
            return base.getTargetPosition();
        }
    }
}
