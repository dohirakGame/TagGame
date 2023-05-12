using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PositionRandomization : MonoBehaviour
{
    private GameObject[] _spawnPositions;
    
    private GameObject[] _greenPositions;
    private GameObject[] _redPositions;
    private GameObject[] _yellowPositions;

    private GameObject _createdCube;
    
    private int _numberGreenCubes;
    private int _numberRedCubes;
    private int _numberYellowCubes;
    private float _pointZ;

    [SerializeField] private EndToTheGame endToTheGame;
    [SerializeField] private GameObject greenCubePrefab;
    [SerializeField] private GameObject redCubePrefab;
    [SerializeField] private GameObject yellowCubePrefab;
    [SerializeField] private Transform parentForCubes;

    private void Start()
    {
        _pointZ = -1f;
        _numberGreenCubes = 0;
        _numberRedCubes = 0;
        _numberYellowCubes = 0;
        SetNumberPositions();
        SpawnCubes();
        endToTheGame.SetNumberCubes();
    }

    private void SetNumberPositions()
    {
        _greenPositions = GameObject.FindGameObjectsWithTag("Green Positions");
        _redPositions = GameObject.FindGameObjectsWithTag("Red Positions");
        _yellowPositions = GameObject.FindGameObjectsWithTag("Yellow Positions");
        _spawnPositions = _greenPositions.Concat(_redPositions).ToArray();
        _spawnPositions = _spawnPositions.Concat(_yellowPositions).ToArray();
    }

    private void SpawnCubes()
    {
        for (int i = 0; i < _spawnPositions.Length; i++)
        {
            int colorNumber = Random.Range(0, 3);
            Vector3 spawnPosition = new Vector3(_spawnPositions[i].transform.position.x,
                _spawnPositions[i].transform.position.y, _pointZ);
            switch (colorNumber)
            {
                case 0:
                    if (_numberGreenCubes < _greenPositions.Length)
                    {
                        _createdCube = Instantiate(greenCubePrefab, spawnPosition, Quaternion.identity);
                        _numberGreenCubes++;
                        _createdCube.transform.SetParent(parentForCubes);
                        _createdCube.GetComponent<CheckingPositionCube>().CheckingTheColorUnderTheCube();
                    } else i--;
                    break;
                case 1:
                    if (_numberRedCubes < _redPositions.Length)
                    {
                        _createdCube = Instantiate(redCubePrefab, spawnPosition, Quaternion.identity);
                        _numberRedCubes++;
                        _createdCube.transform.SetParent(parentForCubes);
                        _createdCube.GetComponent<CheckingPositionCube>().CheckingTheColorUnderTheCube();
                    } else i--;
                    break;
                case 2:
                    if (_numberYellowCubes < _yellowPositions.Length)
                    {
                        _createdCube = Instantiate(yellowCubePrefab, spawnPosition, Quaternion.identity);
                        _numberYellowCubes++;
                        _createdCube.transform.SetParent(parentForCubes);
                        _createdCube.GetComponent<CheckingPositionCube>().CheckingTheColorUnderTheCube();
                    } else i--;
                    break;
                default:
                    break;
            }
        }
    }
}
