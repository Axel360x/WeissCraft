using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;


public class World : MonoBehaviour
{

	public GameObject chunk;
	public Chunk[,,] chunks;
	public int chunkSize = 16;
	public byte[,,] data;
	public int worldX = 16;
	public int worldY = 16;
	public int worldZ = 16;
    public bool genterr = true;
    public bool menuTerrain = false;
    public List<BlockData> blockData;
    bool loadMode = false;
	// Use this for initialization
    void Awake()
    {
        BlockSet.BlockMap();
        blockData = BlockSet.blockData;
    }
	void Start ()
    {
        if (LoadSave.loading)
        {
            Destroy(gameObject);
            genterr = false;
            LoadSave.ForceLoad();
        }
        if (genterr)
        {
            data = new byte[worldX, worldY, worldZ];

            Generator gen = new Generator(worldX, worldY, worldZ, data);

            if (menuTerrain)
                gen.MenuTerrain();
            else
                gen.SolidTerrain();

            chunks = new Chunk[Mathf.FloorToInt(worldX / chunkSize), Mathf.FloorToInt(worldY / chunkSize), Mathf.FloorToInt(worldZ / chunkSize)];

        }
	}


	public IEnumerator GenColumn(int x, int z, float time){
		for (int y=0; y<chunks.GetLength(1); y++) {
            GetComponent<ModifyTerrain>().loading = true;
					//Create a temporary Gameobject for the new chunk instead of using chunks[x,y,z]
					GameObject newChunk = Instantiate (chunk, new Vector3 (x * chunkSize - 0.5f,
 y * chunkSize + 0.5f, z * chunkSize - 0.5f), new Quaternion (0, 0, 0, 0)) as GameObject;
      
					chunks [x, y, z] = newChunk.GetComponent ("Chunk") as Chunk;
					chunks [x, y, z].worldGO = gameObject;
					chunks [x, y, z].chunkSize = chunkSize;
					chunks [x, y, z].chunkX = x * chunkSize;
					chunks [x, y, z].chunkY = y * chunkSize;
					chunks [x, y, z].chunkZ = z * chunkSize;

                    yield return new WaitForSeconds(time);
                    GetComponent<ModifyTerrain>().loading = false;
			}
	}



    public void GenColumnS(int x, int z)
    {
        for (int y = 0; y < chunks.GetLength(1); y++)
        {
            //Create a temporary Gameobject for the new chunk instead of using chunks[x,y,z]
            GameObject newChunk = Instantiate(chunk, new Vector3(x * chunkSize - 0.5f,
y * chunkSize + 0.5f, z * chunkSize - 0.5f), new Quaternion(0, 0, 0, 0)) as GameObject;

            chunks[x, y, z] = newChunk.GetComponent("Chunk") as Chunk;
            chunks[x, y, z].worldGO = gameObject;
            chunks[x, y, z].chunkSize = chunkSize;
            chunks[x, y, z].chunkX = x * chunkSize;
            chunks[x, y, z].chunkY = y * chunkSize;
            chunks[x, y, z].chunkZ = z * chunkSize;
        }
    }
	
	public void UnloadColumn(int x, int z){
		for (int y=0; y<chunks.GetLength(1); y++) {
			UnityEngine.Object.Destroy(chunks [x, y, z].gameObject);
			
		}
	}
  
	int PerlinNoise (int x, int y, int z, float scale, float height, float power)
	{
		float rValue;
		rValue = Noise.GetNoise (((double)x) / scale, ((double)y) / scale, ((double)z) / scale);
		rValue *= height;
   
		if (power != 0) {
			rValue = Mathf.Pow (rValue, power);
		}
   
		return (int)rValue;
	}
  
  
	// Update is called once per frame
	void Update ()
	{
  
	}
  
	public byte Block (int x, int y, int z)
	{
   
		if (x >= worldX || x < 0 || y >= worldY || y < 0 || z >= worldZ || z < 0) {
			return (byte)1;
		}
   
		return data [x, y, z];
	}
}