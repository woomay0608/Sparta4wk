using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovingType
{
    X,
    Z,
    Y
}

public class Platform : MonoBehaviour
{
    [Range(0f, 10f)] public float speed;
    [Range(0, 100)] public int MaxDistance;
    [Range(0, 100)] public int MinDistance;
    public MovingType type;
    Transform curTransform;
    Vector3 StartPosition;

    bool IsFront = true;


    private void Start()
    {

        curTransform = transform;
        StartPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Moving();
    }

    private void Moving()
    {

        switch (type)
        {
            case MovingType.X:

                if (IsFront)
                {
                    curTransform.position = new Vector3(curTransform.position.x + speed * Time.deltaTime, curTransform.position.y, curTransform.position.z);

                    if (curTransform.position.x > StartPosition.x + MaxDistance)
                    {
                        curTransform.position = new Vector3(StartPosition.x + MaxDistance, curTransform.position.y, curTransform.position.z);
                        IsFront = false;

                    }
                }
                else
                {
                    curTransform.position = new Vector3(curTransform.position.x - speed * Time.deltaTime, curTransform.position.y, curTransform.position.z);

                    if (curTransform.position.x < StartPosition.x - MinDistance)
                    {
                        curTransform.position = new Vector3(StartPosition.x - MinDistance, curTransform.position.y, curTransform.position.z);
                        IsFront = true;

                    }
                }


                break;
            case MovingType.Z:
                if (IsFront)
                {
                    curTransform.position = new Vector3(curTransform.position.x , curTransform.position.y, curTransform.position.z + speed * Time.deltaTime);

                    if (curTransform.position.z > StartPosition.z + MaxDistance)
                    {
                        curTransform.position = new Vector3(curTransform.position.x , curTransform.position.y, StartPosition.z + MaxDistance);
                        IsFront = false;

                    }
                }
                else
                {
                    curTransform.position = new Vector3(curTransform.position.x , curTransform.position.y, curTransform.position.z - speed * Time.deltaTime );

                    if (curTransform.position.z < StartPosition.z - MinDistance)
                    {
                        curTransform.position = new Vector3(curTransform.position.x, curTransform.position.y, StartPosition.z- MinDistance);
                        IsFront = true;

                    }
                }
                break;
            case MovingType.Y:
                if (IsFront)
                {
                    curTransform.position = new Vector3(curTransform.position.x , curTransform.position.y + speed * Time.deltaTime, curTransform.position.z);

                    if (curTransform.position.y > StartPosition.y + MaxDistance)
                    {
                        curTransform.position = new Vector3(curTransform.position.x , StartPosition.y + MaxDistance, curTransform.position.z);
                        IsFront = false;

                    }
                }
                else
                {
                    curTransform.position = new Vector3(curTransform.position.x , curTransform.position.y - speed * Time.deltaTime, curTransform.position.z);

                    if (curTransform.position.y < StartPosition.y - MinDistance)
                    {
                        curTransform.position = new Vector3(curTransform.position.x, StartPosition.y - MinDistance, curTransform.position.z);
                        IsFront = true;

                    }
                }
                break;

        }



    }




}
