using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
[RequireComponent(typeof(AudioSource))]

public class SaberSounds : MonoBehaviour
{
    XRGrabInteractable grabInteractable;
    ControllerData controllerData = null;
    AudioSource audioSource = null;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float swingThreshold;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 1;
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(GetControllerData);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(GetControllerData);    
    }

    private void GetControllerData(SelectEnterEventArgs arg0)
    {
        Transform parent = arg0.interactorObject.transform.parent;

        if (parent != null)
        {
            controllerData = parent.GetComponent<ControllerData>();
        }
    }
    
    void PlaySwingSound()
    {
        audioSource.PlayOneShot(audioClip);
    }

    void Update()
    {
        if (IsLaserMoving() && !audioSource.isPlaying)
        {
            PlaySwingSound();
        }
    }

    bool IsLaserMoving()
    {
        if (controllerData == null) return false;

        return controllerData.AngularVelocity.magnitude > swingThreshold;
    }
}
