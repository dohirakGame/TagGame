using UnityEngine;

public class ChooseDirection : MonoBehaviour
{
    public GameObject positionSelectedCube;
    
    private EndToTheGame _endToTheGame;
    
    [SerializeField] private GameObject cubeToChoose;
    private GameObject _selectedCube;
    private void OnMouseDown()
    {
        if (gameObject.tag == "Chosen Cube")
        {
            _selectedCube = gameObject;
            MovingCubeToSelectedPosition();
        }
    }
    public void SetSelectedCubeInPrefab(GameObject selectedCube)
    {
        cubeToChoose.GetComponent<ChooseDirection>().positionSelectedCube = selectedCube;
    }
    public void CreateSelectionCube(Vector3 positionForSelectedCube)
    {
        Instantiate(cubeToChoose, positionForSelectedCube, Quaternion.identity);
    }
    
    private void MovingCubeToSelectedPosition()
    { 
        _endToTheGame = GameObject.FindGameObjectWithTag("WinManager").GetComponent<EndToTheGame>();
        
       positionSelectedCube.transform.position = _selectedCube.transform.position;
       positionSelectedCube.GetComponent<Cube>().RemovingCubesForSelection();
       positionSelectedCube.GetComponent<CheckingPositionCube>().CheckingTheColorUnderTheCube();
       
       _endToTheGame.ColorMatchingCheck();
    }
}
