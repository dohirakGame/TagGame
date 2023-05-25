using UnityEngine;

public class EndToTheGame : MonoBehaviour
{
    [SerializeField] private ButtonHandingInGame buttonHandingInGame;
    [SerializeField] private int _numberOfTrueCubes;
    private int _numberOfCubes;

    private GameObject[] _greenCubes;
    private GameObject[] _redCubes;
    private GameObject[] _yellowCubes;

    public void SetNumberCubes()
    {
        _greenCubes = GameObject.FindGameObjectsWithTag("Green Cubes");
        _redCubes = GameObject.FindGameObjectsWithTag("Red Cubes");
        _yellowCubes = GameObject.FindGameObjectsWithTag("Yellow Cubes");
        _numberOfCubes = AssignTheNumberOfCubes();
        ColorMatchingCheck();
    }
    public void ColorMatchingCheck()
    {
        int count = 0;
        _numberOfTrueCubes = 0;
        for (int i = 0; i < _greenCubes.Length; i++)
        {
            count += _greenCubes[i].GetComponent<CheckingPositionCube>().correctPosition;
        }
        _numberOfTrueCubes += count;
        count = 0;
        for (int i = 0; i < _redCubes.Length; i++)
        {
            count += _redCubes[i].GetComponent<CheckingPositionCube>().correctPosition;
        }
        _numberOfTrueCubes += count;
        count = 0;
        for (int i = 0; i < _yellowCubes.Length; i++)
        {
            count += _yellowCubes[i].GetComponent<CheckingPositionCube>().correctPosition;
        }
        _numberOfTrueCubes += count;
        
        TestForVictory();
    }
        
    private int AssignTheNumberOfCubes()
    {
        int count = 0;
        count += GameObject.FindGameObjectsWithTag("Green Cubes").Length;
        count += GameObject.FindGameObjectsWithTag("Red Cubes").Length;
        count += GameObject.FindGameObjectsWithTag("Yellow Cubes").Length;
        return count;
    }

    private void TestForVictory()
    {
        if (_numberOfTrueCubes == _numberOfCubes)
        {
            buttonHandingInGame.GameOver();
            FindObjectOfType<StarInVictoryPanel>().ShowResult();
        }
    }
}
