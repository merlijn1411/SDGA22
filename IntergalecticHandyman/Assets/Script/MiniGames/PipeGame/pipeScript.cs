using UnityEngine;

public class pipeScript : MonoBehaviour
{
    float[] rotations = { 0, 90, 180, 270 };

    public float[] correctRotation;
    [SerializeField]
    bool inPlace = false;

    int PossibleRots = 1;

    private PipeGameController _pipeGameController;
    

    private void Start()
    {
        _pipeGameController = GetComponentInParent<PipeGameController>();
        
        
        PossibleRots = correctRotation.Length;
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        if (PossibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1])
            {
                inPlace = true;
                _pipeGameController.CorrectMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0] )
            { 
                inPlace = true;
                _pipeGameController.CorrectMove();
            }
        }
        
        
    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        if (PossibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1] && inPlace == false)
            {
                inPlace = true;
                _pipeGameController.CorrectMove();
            }
            else if (inPlace == true)
            {
                inPlace = false;
                _pipeGameController.wrongMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0]  && inPlace == false)
            {
                inPlace = true;
                _pipeGameController.CorrectMove();
            }
            else if (inPlace == true)
            {
                inPlace = false;
                _pipeGameController.wrongMove();
            }
        }
       
    }
}
