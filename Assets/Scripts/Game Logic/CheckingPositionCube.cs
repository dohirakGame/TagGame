using UnityEngine;

public class CheckingPositionCube : MonoBehaviour
{
    private RaycastHit _checkedCube;

    public int correctPosition;
    public void CheckingTheColorUnderTheCube()
    {
        if (Physics.Raycast(gameObject.transform.position,Vector3.forward*1f,out _checkedCube,1f))
        {
            if (_checkedCube.collider.tag == "Red Positions" && gameObject.tag == "Red Cubes")
            {
                correctPosition = 1;
            }
            else if (_checkedCube.collider.tag == "Green Positions" && gameObject.tag == "Green Cubes")
            {
                correctPosition = 1;
            }
            else if (_checkedCube.collider.tag == "Yellow Positions" && gameObject.tag == "Yellow Cubes")
            {
                correctPosition = 1;
            }
            else correctPosition = 0;
        }
    }
}
