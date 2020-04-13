using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{   
    //References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    [SerializeField Range(0, 24)] private float TimeOfDay;

    private void Update()
    {
        if (Preset == null)
            return;

        if(Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= 24; //Clamp between 0-24
            UpdateLighting(TimeOfDay /24f)
        }
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.Ambientcolor.Evaluate(timePercent);
        RenderSettings.fogColor = Present.FogColor.Evaluate(timePercent);

        if(DirectionalLight!=null)
        {
            DirectionalLight.color = Present.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }

    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }

        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(LightingManager light in lights)
            {

            }
        }
    }
}
