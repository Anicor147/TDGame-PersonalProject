using System;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public event Action<Quaternion> OnCameraChanged;
    public event Action<Quaternion> OnCameraChangedRotation;
    public static EventManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnCameraChangedEvent(Quaternion position)
    {
        OnCameraChanged?.Invoke(position);
    }

    public void OnCameraChangedRotationEvent(Quaternion rotation)
    {
        OnCameraChangedRotation?.Invoke(rotation);
    }
}
