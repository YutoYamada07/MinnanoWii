using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private TriggerEvent onTriggerEnter = new TriggerEvent();

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke(other);
    }
    

    [Serializable]
    public class TriggerEvent : UnityEvent<Collider>
    { 
    }
    
}
