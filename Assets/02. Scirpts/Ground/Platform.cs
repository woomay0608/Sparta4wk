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
    [Range(0f,10f)] public float speed;
    [Range(0, 100)] public int MaxDistance;
    [Range(0, 100)] public int MinDistance;
    [Range(0, 10)] public float HowLongWating;
    public MovingType type;
    Rigidbody rigidbody;
    Transform curTransform;
    Vector3 StartPosition;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        curTransform = transform;
        StartPosition = transform.position;
    }
    private void Update()
    {
        StartCoroutine(Moving());


    }

    private IEnumerator Moving()
    {
        while (true)
        {
            switch (type)
            {
                case MovingType.X:
                    
                   
                    if (curTransform.position.x ==  StartPosition.x + MaxDistance)
                    {
                        curTransform.position = new Vector3(curTransform.position.x + speed, curTransform.position.y, curTransform.position.z);
                        yield return new WaitForSeconds(HowLongWating);
                    }
                    else if(curTransform.position.x == StartPosition.x - MinDistance)
                    {
                        curTransform.position = new Vector3(curTransform.position.x - speed, curTransform.position.y, curTransform.position.z);
                        yield return new WaitForSeconds(HowLongWating);
                    }


                    break;
                case MovingType.Z:
                    break;
                case MovingType.Y:
                    break;

            }
        }


    }




}
