using System.Collections.Generic;
using UnityEngine;  


public class InteractionRadius : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float radius;
    
    [SerializeField] private List<GameObject> interactionText;
    
    private void Update()
    {
        InRadius();
    }

    private void InRadius()
    {
        foreach (var text in interactionText)
        {
            var distanceToTarget = Vector3.Distance(text.transform.position, player.position);

            var inRange = distanceToTarget < radius ? true : false;
            
            text.SetActive(inRange);
        }
    }

    public void RemoveFromList(string objectName)
    {
        GameObject objectToRemove = interactionText.Find(obj => obj.name == objectName);
        
        interactionText.Remove(objectToRemove);
    }
}
