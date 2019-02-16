using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public Sprite sprite;
    public Camera camera;
    public Rigidbody2D targetRigidbody2D;
    public List<ParticleSystem> particleSystems;
    private ParticleSystem.Particle[] m_particles;
    private List<GameObject> m_icons = new List<GameObject>();

    private void LateUpdate()
    {
        var particle_system = particleSystems.First(item =>
        {
            return (item.transform.parent.position.y + item.transform.localPosition.y * 2) > targetRigidbody2D.position.y;
        });

        if (m_particles == null)
        {
            m_particles = new ParticleSystem.Particle[particle_system.main.maxParticles];
        }

        int count = particle_system.GetParticles(m_particles);
        for (int index = 0; index < count; index++)
        {
            if (m_icons.Count <= index)
            {
                var game_object = new GameObject();
                game_object.AddComponent<Image>().sprite = sprite;
                game_object.transform.SetParent(transform);
                m_icons.Add(game_object);
            }

            var particle = m_particles[index];
            var particle_position = particle_system.transform.TransformPoint(particle.position);
            if (particle_position.y > targetRigidbody2D.position.y)
            {
                m_icons[index].SetActive(true);
                var icon = m_icons[index];

                var distance = particle_position.y - camera.ViewportToWorldPoint(Vector3.up).y;

                var alpha = Mathf.Clamp01(targetRigidbody2D.velocity.y / distance);
                icon.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, alpha);

                var position = camera.WorldToScreenPoint(particle_position);
                position.y = Screen.height - icon.GetComponent<Image>().rectTransform.rect.height / 2.0f;
                icon.transform.position = position;
            }
            else
            {
                m_icons[index].SetActive(false);
            }
        }
    }
}
