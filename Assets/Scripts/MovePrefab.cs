using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePrefab : MonoBehaviour
{
    private bool isMoving = false;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            SetObjectPosition();
        }
    }

    private void OnMouseDrag()
    {
        isMoving = true;
    }

    private void OnMouseUp()
    {
        isMoving = false;
    }

    void SetObjectPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plan = new Plane(Vector3.up, Vector3.zero);

        if (plan.Raycast(ray, out float distance))
        {
            Vector3 worldPosition = ray.GetPoint(distance);
            transform.position = worldPosition;
        }
    }

}
