using UnityEngine;

public class Cube : MonoBehaviour
{
    private ChooseDirection _chooseDirection;
    
    private int _layerMask;
    private void Start()
    {
        _chooseDirection = gameObject.GetComponent<ChooseDirection>();
        _layerMask = 1 << 6;
        _layerMask = ~_layerMask;
    }
    private void OnMouseDown()
    {
        if (gameObject.tag == "Green Cubes" || gameObject.tag == "Red Cubes" || gameObject.tag == "Yellow Cubes")
        {
            AudioManager.instance.Play("Choose Cube");

            RemovingCubesForSelection();
            CreateCubeToSelectMove();
        }
    }
    public void RemovingCubesForSelection()
    {
        GameObject[] cubesToChooseFrom = GameObject.FindGameObjectsWithTag("Chosen Cube");
        for (int i = 0; i < cubesToChooseFrom.Length; i++)
        {
            Destroy(cubesToChooseFrom[i]);
        }
    }

    private void CreateCubeToSelectMove()
    {
        Vector3 positionForChoose;
        if (!Physics.Raycast(transform.position, Vector3.up*1f, 5.0f,_layerMask))
        {
            positionForChoose = transform.position;
            positionForChoose.y += 4.75f;
            _chooseDirection.SetSelectedCubeInPrefab(gameObject);
            _chooseDirection.CreateSelectionCube(positionForChoose);
        }
        if (!Physics.Raycast(transform.position, Vector3.right*1f, 5.0f,_layerMask))
        {
            positionForChoose = transform.position;
            positionForChoose.x += 4.75f;
            _chooseDirection.SetSelectedCubeInPrefab(gameObject);
            _chooseDirection.CreateSelectionCube(positionForChoose);
        }
        if (!Physics.Raycast(transform.position, Vector3.down*1f, 5.0f,_layerMask))
        {
            positionForChoose = transform.position;
            positionForChoose.y -= 4.75f;
            _chooseDirection.SetSelectedCubeInPrefab(gameObject);
            _chooseDirection.CreateSelectionCube(positionForChoose);
        }
        if (!Physics.Raycast(transform.position, Vector3.left*1f, 5.0f,_layerMask))
        {
            positionForChoose = transform.position;
            positionForChoose.x -= 4.75f;
            _chooseDirection.SetSelectedCubeInPrefab(gameObject);
            _chooseDirection.CreateSelectionCube(positionForChoose);
        }
    }
}

