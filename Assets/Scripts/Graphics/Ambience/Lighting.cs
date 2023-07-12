using Hassle.Configs;
using Hassle.World;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;

namespace Hassle.Graphics.Ambience
{
    public class Lighting : MonoBehaviour
    {
        private static Light m_MainLight;

        private LightingConfig m_Config;
        private WeatherConfig m_WeatherConfig;

        public static Light MainLight => m_MainLight;

        private void Awake()
        {
            LoadConfig();
            CreateMainLight();

            WorldTime.OnTimeUpdate += OnTimeUpdate;
        }

        private void LoadConfig()
        {
            m_Config = Addressables.LoadAssetAsync<LightingConfig>("Assets/Configs/Ambience/LightingConfig.asset").WaitForCompletion();
            m_WeatherConfig = Addressables.LoadAssetAsync<WeatherConfig>("Assets/Configs/Ambience/ClearSky.asset").WaitForCompletion();
        }

        private void CreateMainLight()
        {
            GameObject lightObject = new("Sun/Moon Directional Light");
            lightObject.transform.SetParent(transform);

            m_MainLight = lightObject.AddComponent<Light>();
            m_MainLight.type = LightType.Directional;
            m_MainLight.shadows = LightShadows.Soft;

            RenderSettings.ambientMode = AmbientMode.Flat;
        }

        private void OnTimeUpdate()
        {
            UpdateMainLight();
            UpdateAmbientLighting();
        }

        private void UpdateMainLight()
        {
            if (WorldTime.IsNight)
            {
                m_MainLight.transform.rotation = WorldTime.Moon.rotation;
                m_MainLight.intensity = m_Config.MoonIntesityCurve.Evaluate(WorldTime.LunarTime) * m_WeatherConfig.DirectLightIntensity;
                m_MainLight.color = m_Config.MoonColorGradient.Evaluate(WorldTime.LunarTime);
            }
            else
            {
                m_MainLight.transform.rotation = WorldTime.Sun.rotation;
                m_MainLight.intensity = m_Config.SunIntesityCurve.Evaluate(WorldTime.SolarTime) * m_WeatherConfig.DirectLightIntensity;
                m_MainLight.color = m_Config.SunColorGradient.Evaluate(WorldTime.SolarTime);
            }
        }

        private void UpdateAmbientLighting()
        {
            float intensity = m_Config.AmbientIntensityCurve.Evaluate(WorldTime.SolarTime) * m_WeatherConfig.AmbientIntensityModifier;
            RenderSettings.ambientSkyColor = m_Config.AmbientSkyColorGradient.Evaluate(WorldTime.SolarTime) * intensity;
        }
    }
}