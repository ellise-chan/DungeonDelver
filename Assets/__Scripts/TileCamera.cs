﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCamera : MonoBehaviour
{
    static private int W, H;
    static private int[,] MAP;
    static public Sprite[] SPRITES;
    static public Transform TILE_ANCHOR;
    static public Tile[,] TILES;

    [Header("Set in Inspector")]
    public TextAsset mapData;
    public Texture2D mapTiles;
    public TextAsset mapCollisions; // This will be used later
    public Tile tilePrefab;

    void Awake()
    {
        LoadMap();
    }
    {
        // Create the TILE_ANCHOR. All Tiles will have this as their parent.
        GameObject go = new GameObject("TILE_ANCHOR");
        TILE_ANCHOR = go.transform;
        
        // Load all of the Sprites from mapTiles
        SPRITES = Resources.LoadAll<Sprite>(mapTiles.name); 
        
        // Read in the map data
        string[] lines = mapData.text.Split('\n'); 
        H = lines.Length;
        string[] tileNums = lines[0].Split(' ');
        W = tileNums.Length;
        System.Globalization.NumberStyles hexNum; 
        hexNum = System.Globalization.NumberStyles.HexNumber;
        
        // Place the map data into a 2D Array for faster access
        MAP = new int[W, H];
        for (int j = 0; j < H; j++)
        {
            tileNums = lines[j].Split(' ');
            for (int i = 0; i < W; i++)
            {
                if (tileNums[i] == "..")
                {
                    MAP[i, j] = 0;
                }
                else
                {
                    MAP[i, j] = int.Parse(tileNums[i], hexNum);
                }
            }
        }
        print("Parsed " + SPRITES.Length + "sprites."); 
        print("Map size: " + W + "wide by " + H + "high");
    }
    { 
        if (x < 0 || x >= W || y < 0 || y >= H)
        {
            return -1; // Do not allow IndexOutOfRangeExceptions
        }
        return MAP[x, y];
    }

    static public int GET_MAP(float x, float y)
    { // A float GET_MAP() overload
        int tX = Mathf.RoundToInt(x);
        int tY = Mathf.RoundToInt(y - 0.25f); 
        return GET_MAP(tX, tY);
    }

    static public void SET_MAP(int x, int y, int tNum)
    { 
      // Additional security or a break point could be set here.
        if (x < 0 || x >= W || y < 0 || y >= H)
        {
            return; // Do not allow IndexOutOfRangeExceptions
        }
        MAP[x, y] = tNum;
    }






}