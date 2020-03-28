using System;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public static Draggable   Current;
    private       bool       _mouseState;
    private       GameObject target;
    public        Vector3    screenSpace;
    public        Vector3    offset;
    public        LayerMask  TargetLayer;

    public event Action OnDragEnabled;
    public event Action OnDragEnd;

    public Vector3 CurrentDragPosition => this.target.transform.position;

    private void Start()
    {
        Current = this;
    }

    public void Update()
    {
        // Debug.Log(_mouseState);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            target = GetClickedObject(out hitInfo);
            if (target != null && this.target.GetComponent<DraggableRecevoir>() != null)
            {
                var recevoir = this.target.GetComponent<DraggableRecevoir>();
                
                _mouseState = true;

                screenSpace = Camera.main.WorldToScreenPoint(target.transform.position);
                offset = target.transform.position -
                         Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
                this.offset += recevoir.Offset;
                
                recevoir.OnDragStarting();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _mouseState = false;
            if (this.target == null) return;

            var recevoir = this.target.GetComponent<DraggableRecevoir>();
            if (recevoir != null)
                recevoir.OnDragEnding();
        }

        if (_mouseState)
        {
            //keep track of the mouse position
            var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

            //convert the screen mouse position to world point and adjust with offset
            var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

            //update the position of the object in the world
            target.transform.position = curPosition;
        }
    }

    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray        ray    = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red, 1000, false);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }
}