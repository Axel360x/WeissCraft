using UnityEngine;
using System.Collections;

public class Generator :MonoBehaviour {
    float minHeight;
    float maxHeight;
    float smooth;
    int worldX;
    int worldY;
    int worldZ;
    byte[, ,] data;
    System.Random rnd = new System.Random();
    
    int rndStone;
    int rndDirt;
    int rndHoles;
    int rndTrees;

    public Generator(int worldX, int worldY, int worldZ, byte[, ,] data)
    {


        this.worldX = worldX;
        this.worldY = worldY;
        this.worldZ = worldZ;
        this.data = data;
        rndStone = rnd.Next(0, 512);
        rndDirt = rnd.Next(0, 512);
        rndHoles = rnd.Next(0, 512);
        rndTrees = rnd.Next(0, 16);
    }

    public void SolidTerrain()
    {
        for (int x = 0; x < worldX; x++)
        {
            for (int z = 0; z < worldZ; z++)
            {
                
                int sStone = PerlinNoise(x, 100, z, 15 * 2.1f, 4, 2) + 16;
                int stone = PerlinNoise(x, 100 + rndStone, z, 15 * 2, 6, 2f);
                stone += PerlinNoise(x, 300 , z, 15 * 4, 8, 0) + 60;
                int dirt = PerlinNoise(x, 100 + rndDirt, z, 32 * 2, 4, 2) + 2;
                //int underDirt = PerlinNoise(x, 100, z, 4, 2, 2);
                int grass = PerlinNoise(x, 100, z, 32 * 2, 0, 0) + 1;
                int wood = NoiseInt(x, z + rndTrees, 2, 10, 1f) - 8;
                wood *= 5;
                int leaves = NoiseInt(x, z + rndTrees, 2, 10, 1f) - 8;
                leaves *= 2;

                for (int y = 0; y < worldY; y++)
                {
                    int mapHoles = PerlinNoise(x, 300 + rndHoles, z, 32, 64, 1.3f);
                    int dungeon = PerlinNoise(x, y, z, 24, 8, 1.3f);
                    if (y <= stone)
                    {
                        data[x, y, z] = 1;
                    }
                    else if (y <= dirt + stone)
                    {
                        data[x, y, z] = 3;
                    }
                    else if (y <= dirt + stone + grass)
                    {
                        data[x, y, z] = 2;
                    }
                    else
                        if (y <= stone + dirt + grass + wood && wood > 0 && data[x, y - 1, z] != 0)
                        {
                            data[x, y, z] = 17;
                            if (data[x, y - 1, z] == 2)
                                data[x, y - 1, z] = 3;
                        }
                        else if (y <= stone + dirt + grass + wood + leaves && wood > 0)
                        {
                            data[x, y, z] = 18;
                            GenLeaves(x, y, z);



                        }
                    if (y <= sStone)
                    {
                        data[x, y, z] = 1;
                    }
                    else
                            if (y <= sStone + mapHoles && x != 0 && x != worldX - 1 && z != 0 && z != worldZ - 1)
                            {
                                if (y <= dungeon + sStone)
                                    data[x, y, z] = 0;
                            }
                }
            }
        }
    }
    void GenLeaves(int x, int y, int z)
    {
        System.Random rnd = new System.Random();
        for (int py = y - 1; py >= y - 3; py--)
        {
            for (int pz = z + 1; pz >= z - 1; pz--)
            {
                for (int px = x + 1; px >= x - 1; px--)
                {
                    int qx = px;
                    int qz = pz;
                    qx += rnd.Next(-1, 1);
                    qz += rnd.Next(-1, 1);
                    if (qx == x && qz == z)
                        continue;
                    if (qx > 0 && qx < worldX && qz > 0 && qz < worldZ)
                        data[qx, py, qz] = 18;
                }
            }
        }
    }

    public void MenuTerrain()
    {
        for (int x = 0; x < worldX; x++)
        {
            for (int z = 0; z < worldZ; z++)
            {
                int stone = PerlinNoise(x, 100, z, 15 * 2, 4, 1.2f);
                stone += PerlinNoise(x, 300, z, 15 * 4, 8, 0) + 10;
                int dirt = PerlinNoise(x, 100, z, 32 * 2, 2, 2);
                int grass = PerlinNoise(x, 100, z, 32 * 2, 0, 0) + 1;
                

                for (int y = 0; y < worldY; y++)
                {
                    if (y <= stone)
                    {
                        data[x, y, z] = 1;
                    }
                    else if (y <= dirt + stone)
                    {
                        data[x, y, z] = 3;
                    }
                    else if (y <= dirt + stone + grass)
                    {
                        data[x, y, z] = 2;
                    }

                }
            }
        }
    }

    int PerlinNoise(int x, int y, int z, float scale, float height, float power)
    {
        float rValue;
        rValue = Noise.GetNoise(((double)x) / scale, ((double)y) / scale, ((double)z) / scale);
        rValue *= height;

        if (power != 0)
        {
            rValue = Mathf.Pow(rValue, power);
        }

        return (int)rValue;
    }

    int NoiseInt(int x, int y, float scale, float mag, float exp)
    {

        return (int)(Mathf.Pow((Mathf.PerlinNoise(x / scale, y / scale) * mag), (exp)));
    }
}
