using UnityEngine;

public enum MovingType
{
    X,
    Z,
    Y
}

public class Platform : MonoBehaviour
{
    [Range(0f, 10f)] public float Speed;
    [Range(0, 100)] public int MaxDistance;
    [Range(0, 100)] public int MinDistance;
    public MovingType type;
    Transform curTransform;
    Vector3 startPosition;

    bool isForont = true;


    private void Start()
    {

        curTransform = transform;
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Moving();
    }

    ///////////////이동 함수/////////////////////
    private void Moving()
    {

        switch (type)
        {
            case MovingType.X:

                if (isForont)
                {
                    curTransform.position = new Vector3(curTransform.position.x + Speed * Time.deltaTime, curTransform.position.y, curTransform.position.z);

                    if (curTransform.position.x > startPosition.x + MaxDistance)
                    {
                        curTransform.position = new Vector3(startPosition.x + MaxDistance, curTransform.position.y, curTransform.position.z);
                        isForont = false;

                    }
                }
                else
                {
                    curTransform.position = new Vector3(curTransform.position.x - Speed * Time.deltaTime, curTransform.position.y, curTransform.position.z);

                    if (curTransform.position.x < startPosition.x - MinDistance)
                    {
                        curTransform.position = new Vector3(startPosition.x - MinDistance, curTransform.position.y, curTransform.position.z);
                        isForont = true;

                    }
                }


                break;
            case MovingType.Z:
                if (isForont)
                {
                    curTransform.position = new Vector3(curTransform.position.x , curTransform.position.y, curTransform.position.z + Speed * Time.deltaTime);

                    if (curTransform.position.z > startPosition.z + MaxDistance)
                    {
                        curTransform.position = new Vector3(curTransform.position.x , curTransform.position.y, startPosition.z + MaxDistance);
                        isForont = false;

                    }
                }
                else
                {
                    curTransform.position = new Vector3(curTransform.position.x , curTransform.position.y, curTransform.position.z - Speed * Time.deltaTime );

                    if (curTransform.position.z < startPosition.z - MinDistance)
                    {
                        curTransform.position = new Vector3(curTransform.position.x, curTransform.position.y, startPosition.z- MinDistance);
                        isForont = true;

                    }
                }
                break;
            case MovingType.Y:
                if (isForont)
                {
                    curTransform.position = new Vector3(curTransform.position.x , curTransform.position.y + Speed * Time.deltaTime, curTransform.position.z);

                    if (curTransform.position.y > startPosition.y + MaxDistance)
                    {
                        curTransform.position = new Vector3(curTransform.position.x , startPosition.y + MaxDistance, curTransform.position.z);
                        isForont = false;

                    }
                }
                else
                {
                    curTransform.position = new Vector3(curTransform.position.x , curTransform.position.y - Speed * Time.deltaTime, curTransform.position.z);

                    if (curTransform.position.y < startPosition.y - MinDistance)
                    {
                        curTransform.position = new Vector3(curTransform.position.x, startPosition.y - MinDistance, curTransform.position.z);
                        isForont = true;

                    }
                }
                break;

        }



    }




}
