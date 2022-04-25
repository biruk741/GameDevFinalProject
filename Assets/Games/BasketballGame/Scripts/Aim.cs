using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Aim : MonoBehaviour
{
    Vector2 Direction;
    public float force;
    public GameObject PointPrefab;
    public GameObject[] Points;
    public int numberOfPoints;
    private float currentbarValue;
    public Image mask;
    int makePointCount = 1;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Shoot.ShootBall.startGame == true && Shoot.ShootBall.endGame == false)
        {

            if (makePointCount == 1)
            {
                Points = new GameObject[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                {
                    Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
                    if (i == 0)
                    {
                        Points[0].SetActive(false);
                    }
                }
                makePointCount = 2;
            }

            if (Shoot.ShootBall.endGame == false && Shoot.ShootBall.DisableMovement == false)
            {
                currentbarValue = 1-mask.fillAmount;
                Vector2 MousePos = Input.mousePosition;
                Vector2 controllerPos = transform.position;
                Direction = MousePos - controllerPos;
                faceMouse();
                for (int i = 0; i < Points.Length; i++)
                {
                    Points[i].transform.position = PointPosition(i * 0.1f);
                }
            }
        }
     if (makePointCount == 2 && Shoot.ShootBall.endGame == true)
     {
            foreach (var clone in Points)
            {
                Destroy(clone);
            }
            makePointCount = 0;
     }

    }

    void faceMouse()
    {
        
        transform.right = Direction;
    }

    Vector2 PointPosition(float t)
    {
        var newForce = force * currentbarValue;
        Vector2 currentPointPos = (Vector2)transform.position + (Direction.normalized * newForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return currentPointPos;
    }
}
