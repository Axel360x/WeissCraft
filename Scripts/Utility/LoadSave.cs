using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using System;

public static class LoadSave
{
    public static bool loading = false;
    public static int worldNO;

    public static void ForceLoad()
    {
        int i = 0;


    }

    public static void Save(string userID, byte[,,] blockData)
    {
        XElement[,,] xlmt = new XElement[128,128,128];
        for(int x = 0; x< xlmt.GetLength(0); x++)
        {
                    for(int y = 0; y< xlmt.GetLength(1); y++)
        {
                    for(int z = 0; z< xlmt.GetLength(2); z++)
        {
            xlmt[x,y,z] = new XElement("Block", blockData[x,y,z] ,new XAttribute("X", x), new XAttribute("Y", y), new XAttribute("Z", z));
        }
        }
        }
        XElement xEle = XElement.Load("Save.xml");
        xEle.Add(new XElement("UserWorld",
            new XElement("UserID", userID),
            xlmt
            ));
        xEle.Save("Save.xml");
    }

    public static byte[, ,] Load(string userID)
    {
        byte[, ,] arr = new byte[128, 128, 128];
        XElement xel = XElement.Load("Save.xml");
        for (int x = 0; x < arr.GetLength(0); x++)
        {
            for (int y = 0; y < arr.GetLength(1); y++)
            {
                for (int z = 0; z < arr.GetLength(2); z++)
                {
                    var blocksID = from id in xel.Elements("UserWorld")
                                   where (int)id.Element("Block").Attribute("X") == x && (int)id.Element("Block").Attribute("Y") == y && (int)id.Element("Block").Attribute("Z") == z
                                   select id;
                    foreach (XElement bid in blocksID)
                    {
                        arr[x, y, z] = Convert.ToByte(bid.Element("Block").Value);
                    }
                    
                }
            }
        }
        return arr;
    }
}

