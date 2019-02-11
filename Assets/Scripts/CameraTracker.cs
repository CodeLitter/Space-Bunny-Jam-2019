using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")]
public class CameraTracker : CinemachineExtension
{
    private Vector2 m_velocity;

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
            var rigidbody = vcam.Follow.GetComponent<Rigidbody2D>();

            noise.m_AmplitudeGain = ((rigidbody.velocity - m_velocity).y / Time.fixedDeltaTime) * Time.deltaTime;
            m_velocity = rigidbody.velocity;
        }
    }
}
