using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static bool useFolder1 = true;

    private static int shaderType = 1;

    public static void CheckAndSwitchMaterials(int input)
    {
        if (input != shaderType)
        {
            shaderType = input;
            SwitchMaterials();
        }
    }
    public static void SwitchMaterials()
    {
        //useFolder1 = !useFolder1;
        Debug.Log("ShaderType " + shaderType);
        Renderer[] renderers = FindObjectsOfType<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            if (renderer == null || renderer.sharedMaterial == null)
            {
                continue; 
            }

            if (!(renderer.gameObject.name == "Element3D") || renderer.sharedMaterial.name == "White")
            {
                continue; 
            }
            
            if (shaderType == 1)
            {
                Debug.Log("Assets/Materials/Standard/" + renderer.sharedMaterial.name + ".mat");
                renderer.material = Resources.Load<Material>("Materials/Standard/" + renderer.sharedMaterial.name);
            }
            else if(shaderType == 2)
            {
                Debug.Log("Materials switched");
                Debug.Log("Assets/Materials/Cartoon/" + renderer.sharedMaterial.name + ".mat");
                renderer.material = Resources.Load<Material>("Materials/Cartoon/" + renderer.sharedMaterial.name);
            }
        }
    }

    public static void ChangeVolume()
    {
        GameObject musicObject = GameObject.FindGameObjectWithTag("music");
        GameObject sliderObject = GameObject.FindGameObjectWithTag("changeVolumeSlider");
        Debug.Log(sliderObject);
        Debug.Log("change volume");
        if (musicObject != null && sliderObject != null)
        {
            Debug.Log("neither null 1");
            Slider musicVolumeSlider = sliderObject.GetComponent<Slider>();
            AudioSource audioSource = musicObject.GetComponent<AudioSource>();
            Debug.Log(musicVolumeSlider);
            Debug.Log(audioSource);

            if (audioSource != null && musicVolumeSlider != null)
            {
                Debug.Log("neither null 2");
                float newVolume = musicVolumeSlider.value; // The slider value is typically between 0 and 1.
                audioSource.volume = newVolume;
                Debug.Log(newVolume);
            }
        }
    }
}
