using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class getFrequency : MonoBehaviour
{
    public AudioMixerGroup _mixerGroupMicrophone, _migetGroupMaster;
    public float sensitivity = 250;
    public float loudness = 0;
    private AudioSource _audio;
    GameObject dialog = null;
    public Dropdown lista;
    string microphone;
    public float frequency;
    private List<string> options = new List<string>();
    private float[] _audioSpectrum;
    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }


    void Start()
    {


        //*  GetNameMic mic = lista.GetComponent<GetNameMic>();
        _audioSpectrum = new float[128];
        foreach (string device in Microphone.devices)
        {
            if (device == null)
            {
                //set default mic to first mic found.
                microphone = device;
            }
            options.Add(device);
        }

        lista.AddOptions(options);


        int minFreq = 0;
        int maxFreq = 0;

        foreach (string s in Microphone.devices)
        {
            
            Microphone.GetDeviceCaps(s, out minFreq, out maxFreq);
           //* Debug.Log("Device Name: " + s + " [" + minFreq.ToString() + "-" + maxFreq.ToString() + "]");

            if (Microphone.IsRecording(null))
            {
                Debug.Log("NU MERE");
            }
        }
        
       

        _audio.clip = Microphone.Start(microphone, true, 10, 44100); ;
        _audio.outputAudioMixerGroup = _mixerGroupMicrophone;
        _audio.loop = true;
        _audio.mute = false;
        while (!(Microphone.GetPosition(null) > 0)) { }
        _audio.Play();

        lista.onValueChanged.AddListener(delegate { DropdownItemSelected(lista); });
    }


    void DropdownItemSelected(Dropdown dropdown)
    {
        microphone = lista.options[lista.value].text;
        updateMic();
    }

    void Update()
    {


        GetSpectrumAudioSource();

        loudness = GetAveragedVolume() * sensitivity;
        if (loudness > 1)
        {
            //DO SOMETHING
        }
    }

    void GetSpectrumAudioSource()
    {
        _audio.GetSpectrumData(_audioSpectrum, 0, FFTWindow.Blackman);
        if(_audioSpectrum!=null && _audioSpectrum.Length>0)
        {
            frequency = _audioSpectrum[0] * 100;
        }
       
    }
   public void updateMic()
    {
      
        _audio.Stop();
        //Start recording to audioclip from the mic
        _audio.clip = Microphone.Start(microphone, true, 10, 44100);
        _audio.loop = true;
        // Mute the sound with an Audio Mixer group becuase we don't want the player to hear it
        Debug.Log(Microphone.IsRecording(microphone));

        if (Microphone.IsRecording(microphone))
        { //check that the mic is recording, otherwise you'll get stuck in an infinite loop waiting for it to start
            while (!(Microphone.GetPosition(microphone) > 0))
            {
            } // Wait until the recording has started. 

            Debug.Log("recording started with " + microphone);

            // Start playing the audio source
            _audio.Play();
        }
        else
        {
            //microphone doesn't work for some reason

            Debug.Log(microphone + " doesn't work!");
        }
    }
    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        _audio.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }
    

}

