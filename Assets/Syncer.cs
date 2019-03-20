using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syncer : MonoBehaviour
{
    public Spectrum AudioSpectrum;

    public float Bias;
    public float TimeStep;
    public float TimeToBeat;
    public float RestSmoothTime;

    private float PrevAudioValue;
    private float AudioValue;
    private float Timer;

    protected bool IsBeat;

    public virtual void StartBeat()
    {
        //Debug.Log("beat");
        Timer = 0;
        IsBeat = true;
    }

    public virtual void EndBeat()
    {
        Debug.Log("end");
        IsBeat = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioSpectrum = GameObject.FindGameObjectWithTag("Music").GetComponent<Spectrum>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        PrevAudioValue = AudioValue;
        AudioValue = AudioSpectrum.SpectrumValue;

        // if audio value went below the bias during this frame
        if (PrevAudioValue > Bias &&
            AudioValue <= Bias)
        {
            // if minimum beat interval is reached
            if (Timer > TimeStep)
                StartBeat();
        }

        // if audio value went above the bias during this frame
        if (PrevAudioValue <= Bias &&
            AudioValue > Bias)
        {
            // if minimum beat interval is reached
            if (Timer > TimeStep)
                StartBeat();
        }

        Timer += Time.deltaTime;
    }
}
