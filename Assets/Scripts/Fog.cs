using UnityEngine;

namespace Hassle.Graphics.Ambience
{
    public class Fog : MonoBehaviour
    {
        public Color Color = new Color(0.76f, 0.87f, 0.88f);

        public float StartDistance = 100;
        public float EndDistance = Settings.DrawDistance;

        private void Start()
        {
            RenderSettings.fog = true;
        }

        private void Update()
        {
            if (EndDistance > Settings.DrawDistance) EndDistance = Settings.DrawDistance;

            RenderSettings.fogColor = Color;
            RenderSettings.fogStartDistance = StartDistance;
            RenderSettings.fogEndDistance = EndDistance;
        }
    }
}
