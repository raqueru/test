using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCharacter : MonoBehaviour
{
    private float speed = 40;
    private int currentPathIndex;
    private List<Vector3> pathVectorList;
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            SetTargetPosition(Utils.GetMouseWorldPosition());
            
        }
        
        HandleMovement();
    }

    public void setSpeed(float Speed)
    {
        speed = Speed;
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetPosition(int x, int y)
    {
        transform.position = new Vector3(x, y).normalized;

    }
    private void StopMoving()
    {
        pathVectorList = null;
    }

    public void HandleMovement()
    {
 
        if (pathVectorList != null)
        {
            Vector3 targetposition = pathVectorList[currentPathIndex];
            if (Vector3.Distance(transform.position, targetposition) > 1f)
            {
                Vector3 MoveDir = (targetposition - transform.position).normalized;
                float distancebefore = Vector3.Distance(transform.position, targetposition);
                transform.position = transform.position + MoveDir * speed * Time.deltaTime;    
            }
            else
            {
                currentPathIndex++; 
                if (currentPathIndex >= pathVectorList.Count)
                {
                    StopMoving();
                }
            }
        }
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        currentPathIndex = 0;
        pathVectorList = PathFinder.Instance.FindPath(GetPosition(), targetPosition);
        if (pathVectorList!=null&& pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
            pathVectorList = PathFinder.Instance.FindPath(GetPosition(),targetPosition);
        }
        
    }

}

