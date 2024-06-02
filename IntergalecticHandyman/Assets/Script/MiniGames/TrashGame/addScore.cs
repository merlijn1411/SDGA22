using UnityEngine;
using UnityEngine.Events;

public class addScore : MonoBehaviour
{
    public int score = 0;
    
    public UnityEvent onCompleteTask;
    
    private void Update()
    {
        if (score != 5) return;
        onCompleteTask.Invoke();
    }
    private void OnTriggerEnter(Collider other)
    {
        score++;
        
        if (other.CompareTag("trash"))
            Destroy(other.gameObject);  
    }
}
