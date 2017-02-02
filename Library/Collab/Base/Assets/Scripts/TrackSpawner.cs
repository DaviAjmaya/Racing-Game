using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;



public class TrackSpawner : MonoBehaviour
{

    public int length = 50;
    static int mapSize = 100;

    TrackPart[][] p;
    TrackPart p1 = new TrackPart();

    public GameObject leftUp, leftDown, rightUp, rightDown, straightX, straightZ, start, end;
    public Dictionary<string, GameObject> parts = new Dictionary<string, GameObject>();
    Vector3 spawnSpot = new Vector3(0, 0, 0);
    Vector3 spawnPoint = new Vector3(0, 0, 0);


    public static int totalspawn = 0;

    // Use this for initialization
    void Start()
    {
        parts["leftUp"] = leftUp;
        parts["leftDown"] = leftDown;
        parts["rightUp"] = rightUp;
        parts["rightDown"] = rightDown;
        parts["straightZ"] = straightZ;
        parts["straightX"] = straightX;
        parts["start"] = start;
        parts["end"] = end;
        parts["empty"] = null;

        int mat = UnityEngine.Random.Range(1, 8);

        foreach (KeyValuePair<string, GameObject> entry in parts)
        {
            if (entry.Value != null)
            {
                entry.Value.GetComponent<Renderer>().sharedMaterial = (Material)Resources.Load("Materials/"+mat.ToString()  , typeof(Material));
            }
        }

        mapSize = length * 2;
        p = new TrackPart[mapSize][];
        for (int i = 0; i < mapSize; i++)
        {
            p[i] = new TrackPart[mapSize];
        }
        for (int i = 0; i < mapSize; i++)
        {
            for (int i2 = 0; i2 < mapSize; i2++)
            {
                p[i][i2] = new TrackPart();
            }
        }

        spawnTrail(mapSize / 2, mapSize / 2);
        //Save();
       // Load();
        //DrawMap();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    void spawnTrail(int x, int y)
    {
        string name = getRandomValidPart(x, y);
        name = "start";
        addPart(name, x, y, parts[name]);



        for (int i = 0; i < length; i++)
        {
            Vector2 pos = getNextPos(x, y, name);
            if (pos.x == 0 && pos.y == 0)
            {
                x = (int)pos.x;
                y = (int)pos.y;
                break;
            }

            name = getRandomValidPart((int)pos.x, (int)pos.y);
            addPart(name, (int)pos.x, (int)pos.y, parts[name]);
            x = (int)pos.x;
            y = (int)pos.y;
        }
        if (x == 0 && y == 0 || totalspawn < length - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        Vector2 pos2 = getNextPos(x, y, name);

        p[y][x].part = "end";
        spawnSpot = new Vector3(0 + 100 * pos2.x, 0, 0 + 100 * pos2.y);

        int yrot = 0;

        if (pos2.x - x == 1)
        {
            yrot = 90;
        }
        else if (pos2.x - x == -1)
        {
            yrot = -90;
        }
        if (pos2.y - y == 1)
        {
            yrot = 0;
        }
        else if (pos2.y - y == -1)
        {
            yrot = -180;
        }



        Instantiate(end, spawnSpot, Quaternion.Euler(0, yrot, 0));

    }
    Vector2 getNextPos(int x, int y, string name)
    {
        Vector2 pos = new Vector2(0, 0);
        switch (name)
        {
            case "leftUp":
                if (p[y + 1][x].part == "empty")
                {
                    pos.x = x;
                    pos.y = y + 1;
                }
                else
                {
                    pos.x = x - 1;
                    pos.y = y;
                }
                break;
            case "leftDown":
                if (p[y - 1][x].part == "empty")
                {
                    pos.x = x;
                    pos.y = y - 1;
                }
                else
                {
                    pos.x = x - 1;
                    pos.y = y;
                }
                break;
            case "rightUp":
                if (p[y + 1][x].part == "empty")
                {
                    pos.x = x;
                    pos.y = y + 1;
                }
                else
                {
                    pos.x = x + 1;
                    pos.y = y;
                }
                break;
            case "rightDown":
                if (p[y - 1][x].part == "empty")
                {
                    pos.x = x;
                    pos.y = y - 1;
                }
                else
                {
                    pos.x = x + 1;
                    pos.y = y;
                }
                break;
            case "straightX":
                if (p[y][x + 1].part == "empty")
                {
                    pos.x = x + 1;
                    pos.y = y;
                }
                else
                {
                    pos.x = x - 1;
                    pos.y = y;
                }
                break;
            case "straightZ":
                if (p[y + 1][x].part == "empty")
                {
                    pos.x = x;
                    pos.y = y + 1;
                }
                else
                {
                    pos.x = x;
                    pos.y = y - 1;
                }
                break;
            case "start":
                pos.x = x + 1;
                pos.y = y;

                break;
            default: break;

        }

        return pos;
    }

    void print()
    {
        Debug.Log("Start");
        for (int i = 1; i < mapSize - 1; i++)
        {
            for (int i2 = 1; i2 < mapSize - 1; i2++)
            {

                string name = getRandomValidPart(i2, i);
                addPart(name, i2, i, parts[name]);

            }
        }
    }
    bool addPart(string part, int x, int z, GameObject partObject)
    {
        if (p[z][x].part == "empty" && p[z][x].validParts[part] == true && part != "empty")
        {
            p[z][x].part = part;
            spawnSpot = new Vector3(0 + 100 * x, 0, 0 + 100 * z);
            Instantiate(partObject, spawnSpot, partObject.transform.rotation);
            updateValidParts(part, x, z);
            totalspawn++;
        }
        else return false;
        return true;
    }
    void updateValidParts(string part, int x, int z)
    {
        switch (part)
        {
            case "leftUp":
                p[z][x + 1].validParts["leftUp"] = false;
                p[z][x + 1].validParts["leftDown"] = false;
                p[z][x + 1].validParts["straightX"] = false;

                p[z][x - 1].validParts["straightZ"] = false;
                p[z][x - 1].validParts["leftUp"] = false;
                p[z][x - 1].validParts["leftDown"] = false;

                p[z - 1][x].validParts["straightZ"] = false;
                p[z - 1][x].validParts["leftUp"] = false;
                p[z - 1][x].validParts["rightUp"] = false;

                p[z + 1][x].validParts["straightX"] = false;
                p[z + 1][x].validParts["leftUp"] = false;
                p[z + 1][x].validParts["rightUp"] = false;
                break;
            case "leftDown":
                p[z][x + 1].validParts["leftUp"] = false;
                p[z][x + 1].validParts["leftDown"] = false;
                p[z][x + 1].validParts["straightX"] = false;

                p[z][x - 1].validParts["straightZ"] = false;
                p[z][x - 1].validParts["leftUp"] = false;
                p[z][x - 1].validParts["leftDown"] = false;

                p[z - 1][x].validParts["straightX"] = false;
                p[z - 1][x].validParts["leftDown"] = false;
                p[z - 1][x].validParts["rightDown"] = false;

                p[z + 1][x].validParts["straightZ"] = false;
                p[z + 1][x].validParts["leftDown"] = false;
                p[z + 1][x].validParts["rightDown"] = false;
                break;
            case "rightUp":
                p[z][x + 1].validParts["rightUp"] = false;
                p[z][x + 1].validParts["rightDown"] = false;
                p[z][x + 1].validParts["straightZ"] = false;

                p[z][x - 1].validParts["straightX"] = false;
                p[z][x - 1].validParts["rightUp"] = false;
                p[z][x - 1].validParts["rightDown"] = false;

                p[z - 1][x].validParts["straightZ"] = false;
                p[z - 1][x].validParts["leftUp"] = false;
                p[z - 1][x].validParts["rightUp"] = false;

                p[z + 1][x].validParts["straightX"] = false;
                p[z + 1][x].validParts["leftUp"] = false;
                p[z + 1][x].validParts["rightUp"] = false;
                break;
            case "rightDown":
                p[z][x + 1].validParts["rightUp"] = false;
                p[z][x + 1].validParts["rightDown"] = false;
                p[z][x + 1].validParts["straightZ"] = false;

                p[z][x - 1].validParts["straightX"] = false;
                p[z][x - 1].validParts["rightUp"] = false;
                p[z][x - 1].validParts["rightDown"] = false;

                p[z - 1][x].validParts["straightX"] = false;
                p[z - 1][x].validParts["leftDown"] = false;
                p[z - 1][x].validParts["rightDown"] = false;

                p[z + 1][x].validParts["straightZ"] = false;
                p[z + 1][x].validParts["leftDown"] = false;
                p[z + 1][x].validParts["rightDown"] = false;
                break;
            case "straightX":
                p[z][x + 1].validParts["rightUp"] = false;
                p[z][x + 1].validParts["rightDown"] = false;
                p[z][x + 1].validParts["straightZ"] = false;

                p[z][x - 1].validParts["straightZ"] = false;
                p[z][x - 1].validParts["leftUp"] = false;
                p[z][x - 1].validParts["leftDown"] = false;

                p[z - 1][x].validParts["straightZ"] = false;
                p[z - 1][x].validParts["leftUp"] = false;
                p[z - 1][x].validParts["rightUp"] = false;

                p[z + 1][x].validParts["straightZ"] = false;
                p[z + 1][x].validParts["leftDown"] = false;
                p[z + 1][x].validParts["rightDown"] = false;
                break;
            case "straightZ":
                p[z][x + 1].validParts["leftUp"] = false;
                p[z][x + 1].validParts["leftDown"] = false;
                p[z][x + 1].validParts["straightX"] = false;

                p[z][x - 1].validParts["straightX"] = false;
                p[z][x - 1].validParts["rightUp"] = false;
                p[z][x - 1].validParts["rightDown"] = false;

                p[z - 1][x].validParts["straightX"] = false;
                p[z - 1][x].validParts["leftDown"] = false;
                p[z - 1][x].validParts["rightDown"] = false;

                p[z + 1][x].validParts["straightX"] = false;
                p[z + 1][x].validParts["leftUp"] = false;
                p[z + 1][x].validParts["rightUp"] = false;
                break;
            case "start":
                p[z][x + 1].validParts["rightUp"] = false;
                p[z][x + 1].validParts["rightDown"] = false;
                p[z][x + 1].validParts["straightZ"] = false;

                p[z][x - 1].validParts["straightX"] = false;
                p[z][x - 1].validParts["rightUp"] = false;
                p[z][x - 1].validParts["rightDown"] = false;

                p[z - 1][x].validParts["straightZ"] = false;
                p[z - 1][x].validParts["leftUp"] = false;
                p[z - 1][x].validParts["rightUp"] = false;

                p[z + 1][x].validParts["straightZ"] = false;
                p[z + 1][x].validParts["leftDown"] = false;
                p[z + 1][x].validParts["rightDown"] = false;
                break;
            default: break;
            
        }
    }

    string getRandomValidPart(int x, int z)
    {
        string part = "empty";
        int randomNum = UnityEngine.Random.Range(1, 7);
        int validNum = p[z][x].getNumOfValidParts();
        if (validNum > 0)
        {
            do
            {
                randomNum = UnityEngine.Random.Range(1, 7);
                switch (randomNum)
                {
                    case 1: part = "leftUp"; break;
                    case 2: part = "leftDown"; break;
                    case 3: part = "rightUp"; break;
                    case 4: part = "rightDown"; break;
                    case 5: part = "straightX"; break;
                    case 6: part = "straightZ"; break;
                }
            } while (p[z][x].validParts[part] == false);
        }
        return part;
        
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/map.dat");

        Map map = new Map();
        map.setMap(p, length);

        bf.Serialize(file, map);
        file.Close();
    }
    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/map.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/map.dat", FileMode.Open);
            Map map = (Map)bf.Deserialize(file);
            file.Close();

            map.getMap(p);
        }
    }
    public void DrawMap()
    {
        for (int i = 0; i < length; i++)
        {
            for (int i2 = 0; i2 < length; i2++)
            {
                spawnSpot = new Vector3(0 + 150 * i, 0, 0 + 150 * i2);
                Instantiate(parts[p[i][i2].part], spawnSpot, parts[p[i][i2].part].transform.rotation);
            }
        }
    }
}
[Serializable]
class Map
{
    TrackPart[][] map;
    int length = 0;

    public void setMap(TrackPart[][] map, int length)
    {
        this.length = length;
        this.map = new TrackPart[length][];
        for (int i = 0; i < length; i++)
        {
            for (int i2 = 0; i2 < length; i2++)
            {
                this.map[i][i2] = map[i][i2]; 
            }
        }
    }
    public void getMap(TrackPart[][] map)
    {
        if(length != 0)
        {
            for (int i = 0; i < length; i++)
            {
                for (int i2 = 0; i2 < length; i2++)
                {
                    map[i][i2] = this.map[i][i2];
                }
            }
        }
    }
}
[Serializable]
class mapNames
{

}
   

