using UnityEngine;
using Cinemachine;

[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")]
public class CameraBounder : CinemachineExtension
{
    public Collider2D boundingShape;

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Aim)
        {
            var bounds = boundingShape.bounds;
            var target_position = vcam.Follow.position;
            target_position.x = Mathf.Clamp(target_position.x, bounds.min.x, bounds.max.x);
            vcam.Follow.position = target_position;
        }
    }
}
