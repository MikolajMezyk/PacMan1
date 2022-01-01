using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_movement : MonoBehaviour
{
    int pacX;
    int pacY;
    public int speed = 1;
    public int positionX = 7;
    public int positionY = 1;
    public int Xgoal = 1;
    public int Ygoal = 1;
    float nrframe = 0f;
    int kierunek = 2; //w górę = 1; w prawo = 2; w dół = 3; w lewo = 4;
    int[,] macierz = {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 2, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2, 1 },
        { 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1 },
        { 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1 },
        { 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1 },
        { 1, 2, 0, 0, 0, 0, 0, 0, 2, 1, 1, 1, 1, 1, 0, 1, 1, 2, 0, 2, 1, 1, 2, 1, 1, 1, 2, 0, 2, 1, 1, 0, 1, 1, 1, 1, 1, 2, 0, 0, 0, 0, 0, 0, 2, 1 },
        { 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1 },
        { 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 2, 0, 0, 2, 1, 1, 1, 1, 2, 0, 0, 2, 0, 0, 0, 2, 1, 1, 1, 1, 2, 0, 0, 2, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1 },
        { 1, 2, 0, 0, 0, 0, 0, 0, 2, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 2, 0, 0, 0, 0, 0, 0, 2, 1 },
        { 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1 },
        { 1, 0, 1, 1, 1, 1, 1, 1, 2, 0, 0, 2, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 2, 0, 0, 2, 1, 1, 1, 1, 1, 1, 0, 1 },
        { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 2, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
        { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
        { 1, 0, 1, 1, 2, 0, 0, 2, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 2, 0, 0, 2, 1, 1, 0, 1 },
        { 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1 },
        { 1, 2, 0, 0, 2, 1, 1, 2, 0, 0, 2, 2, 0, 0, 2, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 2, 0, 0, 2, 2, 0, 0, 2, 1, 1, 2, 0, 0, 2, 1 },
        { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
        { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
        { 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } };
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void normal()
    {
        nrframe+= Time.deltaTime;
        if(nrframe>.25f)
        {
            nrframe = 0;
            if (macierz[positionY, positionX] == 2)
            {
                double dist1 = 1000, dist2 = 1000, dist3 = 1000, dist4 = 1000, mindist = 1000;
                if (macierz[positionY-1, positionX] != 1 && kierunek != 3) //góra
                {
                    dist1 = Mathf.Sqrt((positionY - 1 - Ygoal) * (positionY - 1 - Ygoal) + (positionX - Xgoal) * (positionX - Xgoal));
                    
                }
                if (macierz[positionY, positionX+1] != 1 && kierunek != 4) //prawo
                {
                    dist2 = Mathf.Sqrt((positionY - Ygoal) * (positionY - Ygoal) + (positionX + 1 - Xgoal) * (positionX + 1 - Xgoal));
                }
                if (macierz[positionY + 1, positionX] != 1 && kierunek != 1) //dół
                {
                    dist3 = Mathf.Sqrt((positionY + 1 - Ygoal) * (positionY + 1 - Ygoal) + (positionX - Xgoal) * (positionX - Xgoal));
                }
                if (macierz[positionY, positionX - 1] != 1 && kierunek != 2) //lewo
                {
                    dist4 = Mathf.Sqrt((positionY - Ygoal) * (positionY - Ygoal) + (positionX - 1 - Xgoal) * (positionX - 1 - Xgoal));
                }

                if (dist1 < mindist)
                {
                    kierunek = 1;
                    mindist = dist1;
                }
                if (dist2 < mindist)
                {
                    kierunek = 2;
                    mindist = dist2;
                }
                if (dist3 < mindist)
                {
                    kierunek = 3;
                    mindist = dist3;
                }
                if (dist4 < mindist)
                {
                    kierunek = 4;
                    mindist = dist4;
                }



            }
            if (kierunek == 1)
            {
                if (macierz[positionY - 1, positionX] != 1)
                {
                    transform.Translate(Vector2.up * speed);
                    positionY -= 1;
                }
            }
            if (kierunek == 2)
            {
                if (macierz[positionY, positionX + 1] != 1)
                {
                    transform.Translate(Vector2.right * speed);
                    positionX += 1;
                }
            }
            if (kierunek == 3)
            {
                if (macierz[positionY + 1, positionX] != 1)
                {
                    transform.Translate(-Vector2.up * speed);
                    positionY += 1;
                }
            }
            if (kierunek == 4)
            {
                if (macierz[positionY, positionX - 1] != 1)
                {
                    transform.Translate(-Vector2.right * speed);
                    positionX -= 1;
                }
            }

        }

    }
    void chase()
    {
        pacX = GameObject.Find("pac-man").GetComponent<Movement>().positionX;
        pacY = GameObject.Find("pac-man").GetComponent<Movement>().positionY;
        nrframe += Time.deltaTime;
        if (nrframe > .25f)
        {
            nrframe = 0;
            if (macierz[positionY, positionX] == 2)
            {
                double dist1 = 1000, dist2 = 1000, dist3 = 1000, dist4 = 1000, mindist = 1000;
                if (macierz[positionY - 1, positionX] != 1 && kierunek != 3) //góra
                {
                    dist1 = Mathf.Sqrt((positionY - 1 - pacY) * (positionY - 1 - pacY) + (positionX - pacX) * (positionX - pacX));

                }
                if (macierz[positionY, positionX + 1] != 1 && kierunek != 4) //prawo
                {
                    dist2 = Mathf.Sqrt((positionY - pacY) * (positionY - pacY) + (positionX + 1 - pacX) * (positionX + 1 - pacX));
                }
                if (macierz[positionY + 1, positionX] != 1 && kierunek != 1) //dół
                {
                    dist3 = Mathf.Sqrt((positionY + 1 - pacY) * (positionY + 1 - pacY) + (positionX - pacX) * (positionX - pacX));
                }
                if (macierz[positionY, positionX - 1] != 1 && kierunek != 2) //lewo
                {
                    dist4 = Mathf.Sqrt((positionY - pacY) * (positionY - pacY) + (positionX - 1 - pacX) * (positionX - 1 - pacX));
                }

                if (dist1 < mindist)
                {
                    kierunek = 1;
                    mindist = dist1;
                }
                if (dist2 < mindist)
                {
                    kierunek = 2;
                    mindist = dist2;
                }
                if (dist3 < mindist)
                {
                    kierunek = 3;
                    mindist = dist3;
                }
                if (dist4 < mindist)
                {
                    kierunek = 4;
                    mindist = dist4;
                }



            }
            if (kierunek == 1)
            {
                if (macierz[positionY - 1, positionX] != 1)
                {
                    transform.Translate(Vector2.up * speed);
                    positionY -= 1;
                }
            }
            if (kierunek == 2)
            {
                if (macierz[positionY, positionX + 1] != 1)
                {
                    transform.Translate(Vector2.right * speed);
                    positionX += 1;
                }
            }
            if (kierunek == 3)
            {
                if (macierz[positionY + 1, positionX] != 1)
                {
                    transform.Translate(-Vector2.up * speed);
                    positionY += 1;
                }
            }
            if (kierunek == 4)
            {
                if (macierz[positionY, positionX - 1] != 1)
                {
                    transform.Translate(-Vector2.right * speed);
                    positionX -= 1;
                }
            }

        }
    }

    void avoid()
    {
        pacX = GameObject.Find("pac-man").GetComponent<Movement>().positionX;
        pacY = GameObject.Find("pac-man").GetComponent<Movement>().positionY;
        nrframe += Time.deltaTime;
        if (nrframe > .25f)
        {
            nrframe = 0;
            if (macierz[positionY, positionX] == 2)
            {
                double dist1 = 0, dist2 = 0, dist3 = 0, dist4 = 0, maxdist = 0;
                if (macierz[positionY - 1, positionX] != 1 && kierunek != 3) //góra
                {
                    dist1 = Mathf.Sqrt((positionY - 1 - pacY) * (positionY - 1 - pacY) + (positionX - pacX) * (positionX - pacX));

                }
                if (macierz[positionY, positionX + 1] != 1 && kierunek != 4) //prawo
                {
                    dist2 = Mathf.Sqrt((positionY - pacY) * (positionY - pacY) + (positionX + 1 - pacX) * (positionX + 1 - pacX));
                }
                if (macierz[positionY + 1, positionX] != 1 && kierunek != 1) //dół
                {
                    dist3 = Mathf.Sqrt((positionY + 1 - pacY) * (positionY + 1 - pacY) + (positionX - pacX) * (positionX - pacX));
                }
                if (macierz[positionY, positionX - 1] != 1 && kierunek != 2) //lewo
                {
                    dist4 = Mathf.Sqrt((positionY - pacY) * (positionY - pacY) + (positionX - 1 - pacX) * (positionX - 1 - pacX));
                }

                if (dist1 > maxdist)
                {
                    kierunek = 1;
                    maxdist = dist1;
                }
                if (dist2 > maxdist)
                {
                    kierunek = 2;
                    maxdist = dist2;
                }
                if (dist3 > maxdist)
                {
                    kierunek = 3;
                    maxdist = dist3;
                }
                if (dist4 > maxdist)
                {
                    kierunek = 4;
                    maxdist = dist4;
                }
            }
            if (kierunek == 1)
            {
                if (macierz[positionY - 1, positionX] != 1)
                {
                    transform.Translate(Vector2.up * speed);
                    positionY -= 1;
                }
            }
            if (kierunek == 2)
            {
                if (macierz[positionY, positionX + 1] != 1)
                {
                    transform.Translate(Vector2.right * speed);
                    positionX += 1;
                }
            }
            if (kierunek == 3)
            {
                if (macierz[positionY + 1, positionX] != 1)
                {
                    transform.Translate(-Vector2.up * speed);
                    positionY += 1;
                }
            }
            if (kierunek == 4)
            {
                if (macierz[positionY, positionX - 1] != 1)
                {
                    transform.Translate(-Vector2.right * speed);
                    positionX -= 1;
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        chase();
    }
}

