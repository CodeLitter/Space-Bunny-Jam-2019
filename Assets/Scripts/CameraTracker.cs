using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")]
public class CameraTracker : CinemachineExtension
{
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var position = state.RawPosition;
            position.x = 0.0f;
            state.RawPosition = position;
        }

        if (stage == CinemachineCore.Stage.Noise)
        {
            var noise = (vcam as CinemachineVirtualCamera).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            noise.m_AmplitudeGain = vcam.Follow.GetComponent<Rigidbody2D>().velocity.magnitude * Time.deltaTime;
        }
    }
}
