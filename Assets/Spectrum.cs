using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectrum : MonoBehaviour
{
    public float SpectrumValue;
    public FFTWindow WindowType;
    [SerializeField] private float[] AudioSpectrum;
    // Start is called before the first frame update
    void Start()
    {
        AudioSpectrum = new float[512];
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(AudioSpectrum, 0, WindowType);

        if(AudioSpectrum!= null && AudioSpectrum.Length > 0)
        {
            SpectrumValue = AudioSpectrum[0] * 100;
        }
    }
}
