using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Noise;

public class World : MonoBehaviour
{
    [SerializeField] int worldX = 128;	// size world
	[SerializeField] int worldY = 128;
	[SerializeField] int worldZ = 128;
    public int chunkSize = 16;	// size 1 chunk
    [SerializeField] GameObject chunk;	
	private byte[,,] blockData;
    public byte[,,] worldData;	// data by 3 axis

	public Chunk[,,] Chunks;
    void Start()
    {
        worldData = new byte[worldX,worldY,worldZ];

        for (int x = 0; x < worldX; x++)
        {
			for (int z = 0; z < worldZ; z++)
            {				
				int rock = PerlinNoise(x,0,z,10,3f,1.2f);
				rock += PerlinNoise(x,200,z,20,8f,0f)+10;
				int grass = PerlinNoise(x,100,z,50,30f,0f)+1;
				for (int y = 0; y < worldY; y++)
                {
					if(y <= rock){
						worldData[x,y,z] = (byte)textureType.grass.GetHashCode();
					} else if(y <= grass){
						worldData[x,y,z] = (byte)textureType.rock.GetHashCode();
					}
				}
			}
		}
        Chunks = new Chunk[Mathf.FloorToInt(worldX/chunkSize), Mathf.FloorToInt(worldY/chunkSize), Mathf.FloorToInt(worldZ/chunkSize)];

        for (int x = 0; x < Chunks.GetLength(0); x++){
			for (int y = 0; y < Chunks.GetLength(1); y++){
				for (int z = 0; z < Chunks.GetLength(2); z++){
					GameObject newChunk = Instantiate(chunk, new Vector3(x * chunkSize - 0.5f, y * chunkSize + 0.5f, z * chunkSize - 0.5f), new Quaternion(0,0,0,0)) as GameObject;
					Chunks[x, y, z] = newChunk.GetComponent("Chunk") as Chunk;
					Chunks[x, y, z].WorldGO = gameObject;
					Chunks[x, y, z].ChunkSize = chunkSize;
					Chunks[x, y, z].ChunkX = x * chunkSize;
					Chunks[x, y, z].ChunkY = y * chunkSize;
					Chunks[x, y, z].ChunkZ = z * chunkSize;
				}
			}
		}
    }

    // Update is called once per frame
    void Update()
    {

    }

    public byte Block(int x, int y, int z)
    {
        if(x >= worldX || x < 0 || y >= worldY || y < 0 || z >= worldZ || z < 0)
        {
            return (byte)textureType.rock.GetHashCode();
        }
        return worldData[x,y,z];
    }

    int PerlinNoise(int x, int y, int z, float scale, float height, float power) 
    {
		float rValue;
		rValue = Noise.Noise.GetNoise(((double)x) / scale, ((double)y) / scale, ((double)z) / scale);
		rValue *= height;

		if(power != 0){
			rValue = Mathf.Pow(rValue, power);
		}
		return (int)rValue;
	}

	public void GenColumn(int x, int z) {
		for (int y = 0; y < Chunks.GetLength(1); y++){
				GameObject newChunk = Instantiate(chunk, new Vector3(x * chunkSize - 0.5f, y * chunkSize + 0.5f, z * chunkSize - 0.5f), new Quaternion(0,0,0,0)) as GameObject;
				Chunks[x, y, z] = newChunk.GetComponent("Chunk") as Chunk;
				Chunks[x, y, z].WorldGO = gameObject;
				Chunks[x, y, z].ChunkSize = chunkSize;
				Chunks[x, y, z].ChunkX = x * chunkSize;
				Chunks[x, y, z].ChunkY = y * chunkSize;
				Chunks[x, y, z].ChunkZ = z * chunkSize;
		}
	}

	public void UnloadColumn(int x, int z){
		for (int y = 0; y < Chunks.GetLength(1); y++){
			Object.Destroy(Chunks[x, y, z].gameObject);
		}
	}
}
