using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_Designer : MonoBehaviour
{

    private int pathLength = 20;
    private GameObject[] path;
    private GameObject startingCube;
    private GameObject sphere;
    private GameObject fakeCube;

    private float cubeX;
    private float cubeZ;

    private float updatedX;
    private float updatedZ;

    private int stackIndex = 0;
    private int randIndex;

    private float distMove = 1.0f;

    private SphereMove sphereScript;

    // Use this for initialization
    void Start()
    {
        sphere = GameObject.Find("Sphere");
        sphereScript = sphere.GetComponent<SphereMove>();
        startingCube = GameObject.Find("StartCube");
        fakeCube = GameObject.Find("FakeCube");
        randIndex = Random.Range(0, pathLength);

        path = new GameObject[pathLength];
        path[0] = startingCube;

        for (int i = 1; i < pathLength; i++)
        {
            float random = Random.value;
            path[i] = Instantiate(startingCube, this.transform);
            if (random <= 0.5f)
            {
                path[i].transform.position = new Vector3(path[i - 1].transform.position.x + distMove, path[i - 1].transform.position.y, path[i - 1].transform.position.z);
                if (i == 1)
                {
                    sphereScript.l_or_r = true;
                }
            }
            else
            {
                path[i].transform.position = new Vector3(path[i - 1].transform.position.x, path[i - 1].transform.position.y, path[i - 1].transform.position.z + distMove);
                if (i == 1)
                {
                    sphereScript.l_or_r = false;
                }
            }
        }
        cubeX = path[pathLength - 1].transform.position.x;
        cubeZ = path[pathLength - 1].transform.position.z;
        updatedX = cubeX;
        updatedZ = cubeZ;
    }

    // Update is called once per frame
    void Update()
    {
        //Updates path to move cubes by seeing if (position of the first cube) < ((position of the sphere) - however long the trail of cubes should be)
        if ((Mathf.Abs(path[stackIndex].transform.position.x) + path[stackIndex].transform.position.z) < ((Mathf.Abs(sphere.transform.position.x) + (sphere.transform.position.z)) - 10.0f))
        {
            SpawnCube();
        }
    }

    private void SpawnCube()
    {
        float random = Random.value;
        bool isGenerated = true;
        int prevIndex = 0;
        while (isGenerated == false || ((isGenerated == true) ? randIndex <= (prevIndex + 2) && randIndex >= (prevIndex - 2) : false))
        {
            Debug.Log("Random number generated");
            prevIndex = randIndex;
            randIndex = Random.Range(0, pathLength); ;
            isGenerated = true;
        }
        if (stackIndex == 0)
        {
            if (random <= 0.5f)
            {
                if (fakeCube.transform.position.x + 1 < sphere.transform.position.x || fakeCube.transform.position.z  + 1 < sphere.transform.position.z)
                {
                    isGenerated = false;
                    fakeCube.transform.position = new Vector3(updatedX, path[pathLength - 1].transform.position.y, updatedZ + distMove);
                }
                updatedX = updatedX + distMove;
                path[stackIndex].transform.position = new Vector3(updatedX, path[pathLength - 1].transform.position.y, updatedZ);
            }
            else
            {
                if (fakeCube.transform.position.x + 1 < sphere.transform.position.x || fakeCube.transform.position.z + 1 < sphere.transform.position.z)
                {
                    isGenerated = false;
                    fakeCube.transform.position = new Vector3(updatedX + distMove, transform.position.y, updatedZ );
                }
                updatedZ = updatedZ + distMove;
                path[stackIndex].transform.position = new Vector3(updatedX, path[pathLength - 1].transform.position.y, updatedZ);
            }
        }
        else
        {
            if (random <= 0.5f)
            {
                if (fakeCube.transform.position.x + 1 < sphere.transform.position.x || fakeCube.transform.position.z + 1 < sphere.transform.position.z)
                {
                    isGenerated = false;
                    fakeCube.transform.position = new Vector3(updatedX, path[stackIndex - 1].transform.position.y, updatedZ + distMove);
                }
                updatedX = updatedX + distMove;
                path[stackIndex].transform.position = new Vector3(updatedX, path[stackIndex - 1].transform.position.y, updatedZ);
            }
            else
            {
                if (fakeCube.transform.position.x + 1 < sphere.transform.position.x || fakeCube.transform.position.z + 1 < sphere.transform.position.z)
                {
                    isGenerated = false;
                    fakeCube.transform.position = new Vector3(updatedX + distMove, path[stackIndex - 1].transform.position.y, updatedZ);
                }
                updatedZ = updatedZ + distMove;
                path[stackIndex].transform.position = new Vector3(updatedX, path[stackIndex - 1].transform.position.y, updatedZ);
            }
        }
        stackIndex++;
        if (stackIndex > (pathLength - 1))
        {
            stackIndex = 0;
        }
    }

    /*void FakePath()
    {
        float random1 = Random.value;
        float random2 = Random.value;
        int randomIndex = (int)(random1 + random2) * 20;

        float indexPosition = Mathf.Abs(path[randomIndex].transform.position.x) + path[randomIndex].transform.position.z;
        float spherePosition = Mathf.Abs(sphere.transform.position.x) + sphere.transform.position.z;

        if (indexPosition > spherePosition)
        {
            if ()
            {

            }
            else if ()
            {

            }
        }
    }*/
}
