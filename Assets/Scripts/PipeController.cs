using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private bool canMoveYAxis = false;
    [SerializeField] private bool isDoublePipe = false;
   
    Vector2 startRotation = Vector2.zero;
    bool leftRotate = true;
    bool rightRotate = false;
    int flag = 1;

    void Update()
    {
        PipesMovement();
        PipesGoUpAndDown();
        DoublePipeRotation();
        DestroyPipes();
    }

    private void PipesMovement()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);
    }
    public void PipesGoUpAndDown()
    {
        if (canMoveYAxis)
        {
            transform.Translate(transform.up * speed / 2 * flag * Time.deltaTime);
            if (transform.position.y > 1)
            {
                flag = -1;
            }
            else if (transform.position.y < -5)
            {
                flag = 1;
            }
        }
    }

    public void DoublePipeRotation()
    {
        if (isDoublePipe)
        {
            if (leftRotate && !rightRotate)
            {
                transform.eulerAngles = startRotation;
                leftRotate = false;
                rightRotate = true;
            }
            else
            {
                transform.eulerAngles = -startRotation;
                leftRotate = true;
                rightRotate = false;
            }
        }
    }

    private void DestroyPipes()
    {
        if (transform.position.x <= -12)
        {
            Destroy(gameObject);
        }
    }
}
