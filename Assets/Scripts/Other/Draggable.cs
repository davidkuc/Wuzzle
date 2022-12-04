using UnityEngine;
using Zenject;


public class Draggable : Debuggable
{
    private Camera camera;
    private Vector3 mousePositionOffset;

    [Inject]
    public void Setup(Camera camera) => this.camera = camera;

    private void OnMouseDown()
    {
        PrintDebugLog("MouseDown!");
        mousePositionOffset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        PrintDebugLog("MouseDrag!");
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }

    private Vector3 GetMouseWorldPosition() => camera.ScreenToWorldPoint(Input.mousePosition);
}

