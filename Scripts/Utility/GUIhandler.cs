using UnityEngine;
using System.Collections;

public class GUIhandler : MonoBehaviour {

    int iToolBar = 0;
    public Texture2D tTile;
    int fTileSize = 32;
    public Texture2D tCrosshair;
    public Vector2 currentSlot;
    World world;
    ModifyTerrain mdf;
    Vector2[] slot;
    Texture2D[] slots;
    Texture2D[] invSlots;
    public bool update = true;
    int offset = 0;
    bool inv = false;
    byte id = 0;

    void Update()
    {

        if (Input.GetKey(KeyCode.Tab))
        {
            inv = true;
        }
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            inv = false;
        }
        if(inv){
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            {
                iToolBar--;
            }
            if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
            {
                iToolBar++;
            }
            if (iToolBar > 8)
            {
                update = true;
                offset++;
            }
            if (iToolBar < 0)
            {
                update = true;
                offset--;
            }
            if (offset < 0)
            {
                update = false;
                offset = 0;
            }

            if (update)
            {
                slots = movingArray(offset);
                slot = getVec(offset);
            }
        
        
        iToolBar = Mathf.Clamp(iToolBar, 0, 8);
        }

    }
    void Start()
    {
        world = GameObject.Find("World").GetComponent<World>();
        mdf = GameObject.Find("World").GetComponent<ModifyTerrain>();
        slot = new Vector2[9];
        slots = new Texture2D[9];
    }

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 16, Screen.height / 2 - 16, 32, 32));
        GUI.DrawTexture(new Rect(0, 0, 32, 32), tCrosshair);
            GUI.EndGroup();
            if (inv)
            {
                GUI.BeginGroup(new Rect(64, 64, 128, Screen.height - 128), new GUIContent());
                iToolBar = GUI.SelectionGrid(new Rect(0, 0, 128, Screen.height - 128), iToolBar, slots, 1);
                GUI.EndGroup();
                id = GetID(slot[iToolBar]);
                mdf.btBlockTypeToPlace = id;
            }
                string strid = "BlockID: " + id.ToString();
                GUI.Label(new Rect(Screen.width - 128, 128, 128, 32), new GUIContent(strid));
            
    }

    Texture2D GetTile(Vector2 vec)
    {
        Texture2D tex = new Texture2D(32,32);
        Color[] col = tTile.GetPixels(fTileSize * Mathf.RoundToInt(vec.x), fTileSize * Mathf.RoundToInt(vec.y), fTileSize, fTileSize);
        tex.SetPixels(col);
        tex.Apply();
        return tex;
    }
    byte GetID(Vector2 slot)
    {
        byte i = 0;
        foreach (BlockData bd in world.blockData)
        {
            if (bd.BlockTop == slot)
            {
                return i;
            }
                i++;
        }
        return (byte)0;
    }

    void Inventory()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 256, Screen.height / 2 - 256, 512, 512));
        GUI.Box(new Rect(0, 0, 512, 512), new GUIContent());

        GUI.EndGroup();
    }

    Texture2D[] movingArray(int offset)
    {
        Vector2[] vec = new Vector2[9];
        Texture2D[] tex = new Texture2D[9];
        int i = 0;
        int j = 0;
        foreach (BlockData block in world.blockData)
        {
            if (i >= offset)
            {
                vec[j] = block.BlockTop;
                j++;
                if (j == 9)
                    break;
            }
            i++;
        }
        i = 0;
        foreach (Vector2 vect in vec)
        {
            tex[i] = GetTile(vect);
            i++;
        }
        return tex;
    }
    Vector2[] getVec(int offset)
    {
        Vector2[] vec = new Vector2[9];
        int i = 0;
        int j = 0;
        foreach (BlockData block in world.blockData)
        {
            if (i >= offset)
            {
                vec[j] = block.BlockTop;
                j++;
                if (j == 9)
                    break;
            }
            i++;
        }
        return vec;
    }
}
