using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BlockData : IEquatable<BlockData>
{

    public byte BlockID { get; set; }
    public string BlockName { get; set; }
    public Vector2 BlockTop { get; set; }
    public Vector2 BlockBot { get; set; }
    public Vector2 BlockNorth { get; set; }
    public Vector2 BlockSouth { get; set; }
    public Vector2 BlockEast { get; set; }
    public Vector2 BlockWest { get; set; }

    public override string ToString()
    {
        return BlockName;
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        BlockData objAsBlockData = obj as BlockData;
        if (objAsBlockData == null) return false;
        else return Equals(objAsBlockData);
    }

    public override int GetHashCode()
    {
        return BlockID;
    }

    public bool Equals(BlockData other)
    {
        if (other == null) return false;
        return (this.BlockID.Equals(other.BlockID));
    }
}

public static class BlockSet
{
    public static List<BlockData> blockData = new List<BlockData>();

    public static void BlockMap()
    {
        #region BlockMap
        blockData.Add(new BlockData()
        {
            BlockID = 0,
            BlockName = "Air",
            BlockTop = new Vector2(10, 0),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 1,
            BlockName = "Stone",
            BlockTop = new Vector2(1, 15),
            BlockBot = new Vector2(1, 15),
            BlockNorth = new Vector2(1, 15),
            BlockSouth = new Vector2(1, 15),
            BlockEast = new Vector2(1, 15),
            BlockWest = new Vector2(1, 15),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 2,
            BlockName = "Grass",
            BlockTop = new Vector2(0, 15),
            BlockBot = new Vector2(2, 15),
            BlockNorth = new Vector2(3, 15),
            BlockSouth = new Vector2(3, 15),
            BlockEast = new Vector2(3, 15),
            BlockWest = new Vector2(3, 15),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 3,
            BlockName = "Dirt",
            BlockTop = new Vector2(2, 15),
            BlockBot = new Vector2(2, 15),
            BlockNorth = new Vector2(2, 15),
            BlockSouth = new Vector2(2, 15),
            BlockEast = new Vector2(2, 15),
            BlockWest = new Vector2(2, 15),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 4,
            BlockName = "Cobblestone",
            BlockTop = new Vector2(5, 9),
            BlockBot = new Vector2(5, 9),
            BlockNorth = new Vector2(5, 9),
            BlockSouth = new Vector2(5, 9),
            BlockEast = new Vector2(5, 9),
            BlockWest = new Vector2(5, 9),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 5,
            BlockName = "Wooden Plank",
            BlockTop = new Vector2(4, 15),
            BlockBot = new Vector2(4, 15),
            BlockNorth = new Vector2(4, 15),
            BlockSouth = new Vector2(4, 15),
            BlockEast = new Vector2(4, 15),
            BlockWest = new Vector2(4, 15),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 6,
            BlockName = "Wooden Plank",
            BlockTop = new Vector2(4, 15),
            BlockBot = new Vector2(4, 15),
            BlockNorth = new Vector2(4, 15),
            BlockSouth = new Vector2(4, 15),
            BlockEast = new Vector2(4, 15),
            BlockWest = new Vector2(4, 15),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 7,
            BlockName = "Bedrock",
            BlockTop = new Vector2(1, 14),
            BlockBot = new Vector2(1, 14),
            BlockNorth = new Vector2(1, 14),
            BlockSouth = new Vector2(1, 14),
            BlockEast = new Vector2(1, 14),
            BlockWest = new Vector2(1, 14),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 8,
            BlockName = "Wooden Plank",
            BlockTop = new Vector2(4, 15),
            BlockBot = new Vector2(4, 15),
            BlockNorth = new Vector2(4, 15),
            BlockSouth = new Vector2(4, 15),
            BlockEast = new Vector2(4, 15),
            BlockWest = new Vector2(4, 15),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 9,
            BlockName = "Wooden Plank",
            BlockTop = new Vector2(4, 15),
            BlockBot = new Vector2(4, 15),
            BlockNorth = new Vector2(4, 15),
            BlockSouth = new Vector2(4, 15),
            BlockEast = new Vector2(4, 15),
            BlockWest = new Vector2(4, 15),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 10,
            BlockName = "Wooden Plank",
            BlockTop = new Vector2(4, 15),
            BlockBot = new Vector2(4, 15),
            BlockNorth = new Vector2(4, 15),
            BlockSouth = new Vector2(4, 15),
            BlockEast = new Vector2(4, 15),
            BlockWest = new Vector2(4, 15),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 11,
            BlockName = "Wooden Plank",
            BlockTop = new Vector2(4, 15),
            BlockBot = new Vector2(4, 15),
            BlockNorth = new Vector2(4, 15),
            BlockSouth = new Vector2(4, 15),
            BlockEast = new Vector2(4, 15),
            BlockWest = new Vector2(4, 15),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 12,
            BlockName = "Sand",
            BlockTop = new Vector2(2, 14),
            BlockBot = new Vector2(2, 14),
            BlockNorth = new Vector2(2, 14),
            BlockSouth = new Vector2(2, 14),
            BlockEast = new Vector2(2, 14),
            BlockWest = new Vector2(2, 14),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 13,
            BlockName = "Gravel",
            BlockTop = new Vector2(3, 14),
            BlockBot = new Vector2(3, 14),
            BlockNorth = new Vector2(3, 14),
            BlockSouth = new Vector2(3, 14),
            BlockEast = new Vector2(3, 14),
            BlockWest = new Vector2(3, 14),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 14,
            BlockName = "Gold ore",
            BlockTop = new Vector2(0, 13),
            BlockBot = new Vector2(0, 13),
            BlockNorth = new Vector2(0, 13),
            BlockSouth = new Vector2(0, 13),
            BlockEast = new Vector2(0, 13),
            BlockWest = new Vector2(0, 13),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 15,
            BlockName = "Iron ore",
            BlockTop = new Vector2(1, 13),
            BlockBot = new Vector2(1, 13),
            BlockNorth = new Vector2(1, 13),
            BlockSouth = new Vector2(1, 13),
            BlockEast = new Vector2(1, 13),
            BlockWest = new Vector2(1, 13),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 16,
            BlockName = "Coal ore",
            BlockTop = new Vector2(2, 13),
            BlockBot = new Vector2(2, 13),
            BlockNorth = new Vector2(2, 13),
            BlockSouth = new Vector2(2, 13),
            BlockEast = new Vector2(2, 13),
            BlockWest = new Vector2(2, 13),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 17,
            BlockName = "Wood",
            BlockTop = new Vector2(5, 14),
            BlockBot = new Vector2(5, 14),
            BlockNorth = new Vector2(4, 14),
            BlockSouth = new Vector2(4, 14),
            BlockEast = new Vector2(4, 14),
            BlockWest = new Vector2(4, 14),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 18,
            BlockName = "Leaves",
            BlockTop = new Vector2(4, 12),
            BlockBot = new Vector2(4, 12),
            BlockNorth = new Vector2(4, 12),
            BlockSouth = new Vector2(4, 12),
            BlockEast = new Vector2(4, 12),
            BlockWest = new Vector2(4, 12),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 19,
            BlockName = "Sponge",
            BlockTop = new Vector2(0, 12),
            BlockBot = new Vector2(0, 12),
            BlockNorth = new Vector2(0, 12),
            BlockSouth = new Vector2(0, 12),
            BlockEast = new Vector2(0, 12),
            BlockWest = new Vector2(0, 12),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 20,
            BlockName = "Glass",
            BlockTop = new Vector2(1, 12),
            BlockBot = new Vector2(1, 12),
            BlockNorth = new Vector2(1, 12),
            BlockSouth = new Vector2(1, 12),
            BlockEast = new Vector2(1, 12),
            BlockWest = new Vector2(1, 12),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 21,
            BlockName = "Lapis Lazuli ore",
            BlockTop = new Vector2(0, 5),
            BlockBot = new Vector2(0, 5),
            BlockNorth = new Vector2(0, 5),
            BlockSouth = new Vector2(0, 5),
            BlockEast = new Vector2(0, 5),
            BlockWest = new Vector2(0, 5),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 22,
            BlockName = "Lapis Lazuli block",
            BlockTop = new Vector2(0, 6),
            BlockBot = new Vector2(0, 6),
            BlockNorth = new Vector2(0, 6),
            BlockSouth = new Vector2(0, 6),
            BlockEast = new Vector2(0, 6),
            BlockWest = new Vector2(0, 6),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 23,
            BlockName = "Dispenser",
            BlockTop = new Vector2(14, 12),
            BlockBot = new Vector2(14, 12),
            BlockNorth = new Vector2(14, 13),
            BlockSouth = new Vector2(13, 13),
            BlockEast = new Vector2(13, 13),
            BlockWest = new Vector2(13, 13),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 24,
            BlockName = "Sandstone",
            BlockTop = new Vector2(15, 5),
            BlockBot = new Vector2(14, 7),
            BlockNorth = new Vector2(0, 4),
            BlockSouth = new Vector2(0, 4),
            BlockEast = new Vector2(0, 4),
            BlockWest = new Vector2(0, 4),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 25,
            BlockName = "White wool",
            BlockTop = new Vector2(0, 11),
            BlockBot = new Vector2(0, 11),
            BlockNorth = new Vector2(0, 11),
            BlockSouth = new Vector2(0, 11),
            BlockEast = new Vector2(0, 11),
            BlockWest = new Vector2(0, 11),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 26,
            BlockName = "Gray wool",
            BlockTop = new Vector2(1, 1),
            BlockBot = new Vector2(1, 1),
            BlockNorth = new Vector2(1, 1),
            BlockSouth = new Vector2(1, 1),
            BlockEast = new Vector2(1, 1),
            BlockWest = new Vector2(1, 1),
        });
        blockData.Add(new BlockData()
{
    BlockID = 27,
    BlockName = "Oceanic wool",
    BlockTop = new Vector2(1, 2),
    BlockBot = new Vector2(1, 2),
    BlockNorth = new Vector2(1, 2),
    BlockSouth = new Vector2(1, 2),
    BlockEast = new Vector2(1, 2),
    BlockWest = new Vector2(1, 2),
});
        blockData.Add(new BlockData()
{
    BlockID = 28,
    BlockName = "Purple wool",
    BlockTop = new Vector2(1, 3),
    BlockBot = new Vector2(1, 3),
    BlockNorth = new Vector2(1, 3),
    BlockSouth = new Vector2(1, 3),
    BlockEast = new Vector2(1, 3),
    BlockWest = new Vector2(1, 3),
});
        blockData.Add(new BlockData()
{
    BlockID = 29,
    BlockName = "Glass",
    BlockTop = new Vector2(1, 4),
    BlockBot = new Vector2(1, 4),
    BlockNorth = new Vector2(1, 4),
    BlockSouth = new Vector2(1, 4),
    BlockEast = new Vector2(1, 4),
    BlockWest = new Vector2(1, 4),
});
        blockData.Add(new BlockData()
{
    BlockID = 30,
    BlockName = "Glass",
    BlockTop = new Vector2(1, 5),
    BlockBot = new Vector2(1, 5),
    BlockNorth = new Vector2(1, 5),
    BlockSouth = new Vector2(1, 5),
    BlockEast = new Vector2(1, 5),
    BlockWest = new Vector2(1, 5),
});
        blockData.Add(new BlockData()
{
    BlockID = 31,
    BlockName = "Glass",
    BlockTop = new Vector2(1, 6),
    BlockBot = new Vector2(1, 6),
    BlockNorth = new Vector2(1, 6),
    BlockSouth = new Vector2(1, 6),
    BlockEast = new Vector2(1, 6),
    BlockWest = new Vector2(1, 6),
});
        blockData.Add(new BlockData()
{
    BlockID = 32,
    BlockName = "Glass",
    BlockTop = new Vector2(1, 7),
    BlockBot = new Vector2(1, 7),
    BlockNorth = new Vector2(1, 7),
    BlockSouth = new Vector2(1, 7),
    BlockEast = new Vector2(1, 7),
    BlockWest = new Vector2(1, 7),
});
        blockData.Add(new BlockData()
{
    BlockID = 33,
    BlockName = "Glass",
    BlockTop = new Vector2(1, 8),
    BlockBot = new Vector2(1, 8),
    BlockNorth = new Vector2(1, 8),
    BlockSouth = new Vector2(1, 8),
    BlockEast = new Vector2(1, 8),
    BlockWest = new Vector2(1, 8),
});
        blockData.Add(new BlockData()
{
    BlockID = 34,
    BlockName = "Glass",
    BlockTop = new Vector2(2, 2),
    BlockBot = new Vector2(2, 2),
    BlockNorth = new Vector2(2, 2),
    BlockSouth = new Vector2(2, 2),
    BlockEast = new Vector2(2, 2),
    BlockWest = new Vector2(2, 2),
});
        blockData.Add(new BlockData()
{
    BlockID = 35,
    BlockName = "Glass",
    BlockTop = new Vector2(2, 3),
    BlockBot = new Vector2(2, 3),
    BlockNorth = new Vector2(2, 3),
    BlockSouth = new Vector2(2, 3),
    BlockEast = new Vector2(2, 3),
    BlockWest = new Vector2(2, 3),
});
        blockData.Add(new BlockData()
        {
            BlockID = 36,
            BlockName = "Glass",
            BlockTop = new Vector2(2, 4),
            BlockBot = new Vector2(2, 4),
            BlockNorth = new Vector2(2, 4),
            BlockSouth = new Vector2(2, 4),
            BlockEast = new Vector2(2, 4),
            BlockWest = new Vector2(2, 4),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 37,
            BlockName = "Glass",
            BlockTop = new Vector2(2, 5),
            BlockBot = new Vector2(2, 5),
            BlockNorth = new Vector2(2, 5),
            BlockSouth = new Vector2(2, 5),
            BlockEast = new Vector2(2, 5),
            BlockWest = new Vector2(2, 5),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 38,
            BlockName = "Glass",
            BlockTop = new Vector2(2, 6),
            BlockBot = new Vector2(2, 6),
            BlockNorth = new Vector2(2, 6),
            BlockSouth = new Vector2(2, 6),
            BlockEast = new Vector2(2, 6),
            BlockWest = new Vector2(2, 6),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 39,
            BlockName = "Glass",
            BlockTop = new Vector2(2, 7),
            BlockBot = new Vector2(2, 7),
            BlockNorth = new Vector2(2, 7),
            BlockSouth = new Vector2(2, 7),
            BlockEast = new Vector2(2, 7),
            BlockWest = new Vector2(2, 7),
        });
        blockData.Add(new BlockData()
        {
            BlockID = 40,
            BlockName = "Glass",
            BlockTop = new Vector2(2, 8),
            BlockBot = new Vector2(2, 8),
            BlockNorth = new Vector2(2, 8),
            BlockSouth = new Vector2(2, 8),
            BlockEast = new Vector2(2, 8),
            BlockWest = new Vector2(2, 8),
        });


        blockData.Add(new BlockData()
        {
            BlockID = 255,
            BlockName = "NULL",
        });
        #endregion
    }
}