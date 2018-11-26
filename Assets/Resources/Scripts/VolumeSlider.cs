using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = AudioListener.volume;
    }

    void Update()
    {
        AudioListener.volume = slider.value; 
    }
}
