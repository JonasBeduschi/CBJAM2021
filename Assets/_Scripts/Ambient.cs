using UnityEngine;

public class Ambient : MonoBehaviour
{
    [SerializeField] private Material skybox;
    [SerializeField] private Light sun;
    [SerializeField] private float darkExposure;
    [SerializeField] private float darkThickness;
    private float originalExposure;
    private float originalThickness;

    [SerializeField] private float periodInSeconds = 4;
    private float currentTime;
    private bool darkening = false;

    private void Awake()
    {
        originalExposure = skybox.GetFloat("_Exposure");
        originalThickness = skybox.GetFloat("_AtmosphereThickness");
    }

    private void Update()
    {
        if (darkening) {
            currentTime += Time.deltaTime;
            if (currentTime >= periodInSeconds) {
                skybox.SetFloat("_Exposure", darkExposure);
                skybox.SetFloat("_AtmosphereThickness", darkThickness);
                darkening = false;
            }
            else {
                skybox.SetFloat("_Exposure", originalExposure - (originalExposure - darkExposure) * (currentTime / periodInSeconds));
                skybox.SetFloat("_AtmosphereThickness", originalThickness - (originalExposure - darkThickness) * (currentTime / periodInSeconds));
            }
        }
    }

    public void Darken()
    {
        currentTime = 0;
        darkening = true;
    }

    private void OnDisable()
    {
        skybox.SetFloat("_Exposure", originalExposure);
        skybox.SetFloat("_AtmosphereThickness", originalThickness);
    }
}