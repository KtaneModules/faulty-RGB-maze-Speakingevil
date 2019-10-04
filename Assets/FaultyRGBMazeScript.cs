using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;

public class FaultyRGBMazeScript : MonoBehaviour {

    public KMAudio Audio;
    public List<KMSelectable> gridbuttons;
    public Renderer[] gridleds;
    public Renderer[] framework;
    public KMColorblindMode colblind;
    public Renderer[] segdisplay;
    public TextMesh[] segcol;
    public Renderer[] orientleds;
    public TextMesh[] orientledcol;
    public Renderer[] meter;
    public TextMesh[] ledcol;
    public TextMesh mazecol;
    public Material[] colours;

    private string[][] mazes = new string[16][]
    {
        new string[15] {"XXXXXXXXXXXXXXX",
                        "X     X       X",
                        "X XXX XXX XXXXX",
                        "X X   X X   X X",
                        "XXX XXX XXX X X",
                        "X X X     X X X",
                        "X XXXXXXX XXX X",
                        "X       X X   X",
                        "XXXXX XXX XXX X",
                        "X   X X X X X X",
                        "XXX X X X X X X",
                        "X X X X X X X X",
                        "X X XXX XXX X X",
                        "X     X     X X",
                        "XXXXXXXXXXXXXXX"},

        new string[15] {"XXXXXXXXXXXXXXX",
                        "X   X   X   X X",
                        "X XXX X XXX X X",
                        "X   X X X X   X",
                        "XXX XXX X XXX X",
                        "X X   X   X   X",
                        "X X XXXXXXXXXXX",
                        "X X X X       X",
                        "X XXX XXXXX XXX",
                        "X     X     X X",
                        "X XXXXX XXXXX X",
                        "X X X   X X X X",
                        "XXX XXXXX X X X",
                        "X         X   X",
                        "XXXXXXXXXXXXXXX"},

        new string[15] {"XXXXXXXXXXXXXXX",
                        "X       X X   X",
                        "XXXXXXX X X XXX",
                        "X     X X   X X",
                        "X X X X X XXX X",
                        "X X X X X X X X",
                        "XXX XXX X X X X",
                        "X X X X X X   X",
                        "X XXX XXXXX XXX",
                        "X X   X   X X X",
                        "X X XXX XXX X X",
                        "X   X   X X X X",
                        "XXXXX XXX XXX X",
                        "X     X       X",
                        "XXXXXXXXXXXXXXX"},

        new string[15] {"XXXXXXXXXXXXXXX",
                        "X       X     X",
                        "XXX XXX X XXX X",
                        "X X X X X X X X",
                        "X XXX X X X XXX",
                        "X     X X X   X",
                        "XXX XXXXX XXX X",
                        "X X X   X X X X",
                        "X X XXX XXX X X",
                        "X X X   X   X X",
                        "X XXX XXX XXX X",
                        "X   X   X X   X",
                        "XXX XXX X XXXXX",
                        "X     X X     X",
                        "XXXXXXXXXXXXXXX"},

        new string[15] {"XXXXXXXXXXXXXXX",
                        "X   X   X     X",
                        "XXX X XXXXXXX X",
                        "X X   X X     X",
                        "X X XXX X XXXXX",
                        "X X X   X X   X",
                        "X XXXXX XXX X X",
                        "X     X X   X X",
                        "X XXX X XXXXX X",
                        "X X X X   X X X",
                        "XXX XXX XXX X X",
                        "X     X X   X X",
                        "X XXXXXXXXX XXX",
                        "X     X       X",
                        "XXXXXXXXXXXXXXX"},

        new string[15] {"XXXXXXXXXXXXXXX",
                        "X       X X   X",
                        "XXXXX XXX X XXX",
                        "X   X   X X   X",
                        "XXX X XXX XXX X",
                        "X X X X X   X X",
                        "X X XXX X XXX X",
                        "X X   X   X   X",
                        "X XXX XXXXXXXXX",
                        "X   X   X   X X",
                        "XXX XXXXX XXX X",
                        "X   X     X   X",
                        "X XXX XXXXX X X",
                        "X X   X     X X",
                        "XXXXXXXXXXXXXXX"},

        new string[15] {"XXXXXXXXXXXXXXX",
                        "X X     X     X",
                        "X X XXX XXXXX X",
                        "X X X X   X   X",
                        "X XXX X XXX XXX",
                        "X     X X   X X",
                        "XXXXX XXXXXXX X",
                        "X X X X       X",
                        "X X XXXXXXXXX X",
                        "X X   X     X X",
                        "X XXX XXX XXX X",
                        "X   X   X   X X",
                        "X X XXX XXX XXX",
                        "X X   X   X   X",
                        "XXXXXXXXXXXXXXX"},

        new string[15] {"XXXXXXXXXXXXXXX",
                        "X X         X X",
                        "X XXXXX XXXXX X",
                        "X     X X     X",
                        "XXXXX X X XXXXX",
                        "X   X X X X   X",
                        "X XXX XXX XXX X",
                        "X X X X X   X X",
                        "X X X X XXXXX X",
                        "X X X X   X X X",
                        "X X XXXXX X X X",
                        "X X     X X   X",
                        "X XXX XXX XXXXX",
                        "X   X   X     X",
                        "XXXXXXXXXXXXXXX"},

        new string[15] {"XXXXXXXXXXXXXXX",
                        "X       X X   X",
                        "X XXXXX X XXX X",
                        "X X X X X X X X",
                        "X X X XXX X X X",
                        "X X X     X X X",
                        "XXX XXX XXX X X",
                        "X     X X   X X",
                        "X XXXXXXX XXX X",
                        "X   X   X X   X",
                        "XXXXX XXX XXXXX",
                        "X     X   X X X",
                        "X XXXXXXXXX X X",
                        "X   X         X",
                        "XXXXXXXXXXXXXXX"},

        new string[15] {"XXXXXXXXXXXXXXX",
                        "X X     X     X",
                        "X X X X XXXXX X",
                        "X X X X X   X X",
                        "X XXXXX X XXX X",
                        "X     X X X   X",
                        "X XXXXXXX XXX X",
                        "X X X       X X",
                        "X X XXXXXXXXXXX",
                        "X X     X X   X",
                        "XXX XXXXX XXX X",
                        "X     X X     X",
                        "XXXXXXX XXXXX X",
                        "X           X X",
                        "XXXXXXXXXXXXXXX"},

        new string[15] {"XXXXXXXXXXXXXXX",
                        "X     X       X",
                        "XXXXX XXX XXXXX",
                        "X   X   X X   X",
                        "X X XXX X XXX X",
                        "X X X   X   X X",
                        "X XXXXXXXXXXX X",
                        "X X   X       X",
                        "X XXX XXXXXXXXX",
                        "X   X     X   X",
                        "XXXXX XXXXX X X",
                        "X X   X   X X X",
                        "X XXXXX XXXXX X",
                        "X       X     X",
                        "XXXXXXXXXXXXXXX"},

        new string[15] {"XXXXXXXXXXXXXXX",
                        "X X         X X",
                        "X XXX XXX XXX X",
                        "X   X X X X   X",
                        "XXX XXX XXXXX X",
                        "X X   X   X X X",
                        "X XXX XXX X X X",
                        "X   X   X   X X",
                        "X XXXXXXX XXX X",
                        "X     X X X   X",
                        "XXX XXX XXXXXXX",
                        "X X X X       X",
                        "X XXX XXXXXXX X",
                        "X         X   X",
                        "XXXXXXXXXXXXXXX"},

        new string[15] {"XXXXXXXXXXXXXXX",
                        "X X     X     X",
                        "X XXXXX XXXXX X",
                        "X     X X     X",
                        "X XXXXX XXXXX X",
                        "X X X     X X X",
                        "X X XXXXXXX XXX",
                        "X X X X       X",
                        "X X X XXXXXXX X",
                        "X X X   X   X X",
                        "XXX XXX XXX X X",
                        "X     X X X X X",
                        "X XXXXX X X XXX",
                        "X X     X     X",
                        "XXXXXXXXXXXXXXX"},

        new string[15] {"XXXXXXXXXXXXXXX",
                        "X X     X     X",
                        "X XXXXX XXX XXX",
                        "X     X   X X X",
                        "XXX XXX XXX X X",
                        "X X X   X   X X",
                        "X X XXXXXXX X X",
                        "X X   X   X X X",
                        "X XXXXXXX XXX X",
                        "X       X X X X",
                        "XXX XXXXX X X X",
                        "X X X   X   X X",
                        "X XXX X X XXX X",
                        "X     X X X   X",
                        "XXXXXXXXXXXXXXX"},

        new string[15] {"XXXXXXXXXXXXXXX",
                        "X         X   X",
                        "XXXXXXX XXX X X",
                        "X X   X X   X X",
                        "X X XXX XXXXX X",
                        "X   X X X X X X",
                        "XXX X XXX X X X",
                        "X X X     X X X",
                        "X X X XXX X XXX",
                        "X X X X X X   X",
                        "X XXXXX XXXXX X",
                        "X X   X     X X",
                        "X X XXXXX XXX X",
                        "X   X     X   X",
                        "XXXXXXXXXXXXXXX"},
    
        new string[15] {"XXXXXXXXXXXXXXX",
                        "X   X     X   X",
                        "X XXXXX XXXXX X",
                        "X     X X     X",
                        "XXXXX X X XXXXX",
                        "X   X X X   X X",
                        "X X X X XXXXX X",
                        "X X X X X     X",
                        "X XXXXX XXXXX X",
                        "X X   X X   X X",
                        "X XXX XXX XXX X",
                        "X X X     X X X",
                        "X X XXXXXXX X X",
                        "X X         X X",
                        "XXXXXXXXXXXXXXX"} };
    
    private string[] gridmaze = new string[15];
    private int[][] keylocations = new int[3][] { new int[2] { -5, -5 }, new int[2] { -5, -5 }, new int[2] { -5, -5 } };
    private int[][] mazenumber = new int[3][] { new int[2], new int[2], new int[2] };
    private int[][] teleport = new int[4][] { new int[2] { 0, 0 }, new int[2], new int[2], new int[2] };
    private bool[][] segon = new bool[3][] { new bool[7], new bool[7], new bool[7] };
    private bool[] segflip = new bool[3];
    private int[] switchforbid = new int[3];
    private int[] tracker = new int[2] { -5, -5 };
    private int[] pos = new int[2];
    private bool[] collect = new bool[3];
    private int currentcol;
    private bool firstmove = true;
    private bool exit;
    private int[] exitlocation = new int[3];
    private bool colb;

    private static int moduleIDCounter;
    private int moduleID;
    private bool moduleSolved;

    private void Awake()
    {
        moduleID = moduleIDCounter++;
        foreach(Renderer m in meter)
        {
            m.material = colours[0];
        }
        foreach(Renderer s in segdisplay)
        {
            s.material = colours[0];
        }
        foreach(Renderer l in orientleds)
        {
            l.material = colours[0];
        }
        foreach(KMSelectable button in gridbuttons)
        {
            int b = gridbuttons.IndexOf(button);
            gridleds[b].material = colours[0];
            button.OnInteract += delegate () { Press(b); return false; };
        }
    }

    void Start()
    {
        colb = colblind.ColorblindModeActive;
        pos[0] = Random.Range(0, 7);
        pos[1] = Random.Range(0, 7);
        exitlocation[0] = Random.Range(0, 3);
        exitlocation[1] = Random.Range(1, 6);
        exitlocation[2] = Random.Range(1, 6);
        Debug.LogFormat("[Faulty RGB Maze #{2}]The starting location is {0}{1}", "ABCDEFGH"[pos[1]], "12345678"[pos[0]], moduleID);
        for (int i = 0; i < 3; i++)
        {
            mazenumber[i][0] = -1;
            switchforbid[i] = Random.Range(1, 15);
            segflip[i] = new bool[2]{ false, true }[Random.Range(0, 2)];
            if (i < 2)
            {
                teleport[i + 1][0] = Random.Range(0, 7);
                switch (teleport[i + 1][0] - teleport[i][0])
                {
                    case 0:
                        teleport[i + 1][1] = Random.Range(3, 5);
                        break;
                    case 1:
                    case 6:
                        teleport[i + 1][1] = Random.Range(2, 6);
                        break;
                    case 2:
                    case 5:
                        teleport[i + 1][1] = Random.Range(1, 7);
                        break;
                    default:
                        teleport[i + 1][1] = Random.Range(0, 7);
                        break;
                }
            }
            else
            {
                teleport[3][0] = (14 - (teleport[1][0] + teleport[2][0])) % 7;
                teleport[3][1] = (14 - (teleport[1][1] + teleport[2][1])) % 7;
            }
            if(switchforbid[0] == 9 || switchforbid[0] == 11 || switchforbid[0] == 13)
            {
                teleport[1][0] = pos[0];
                teleport[1][1] = pos[1];
            }
            keylocations[i][0] = Random.Range(1, 6);
            keylocations[i][1] = Random.Range(1, 6);
            while (Mathf.Abs(keylocations[i][0] - pos[0]) + Mathf.Abs(keylocations[i][1] - pos[1]) < 2 || ((Mathf.Abs(keylocations[1][0] - keylocations[0][0]) + Mathf.Abs(keylocations[1][1] - keylocations[0][1]) < 2) && i == 1) || ((Mathf.Abs(keylocations[2][0] - keylocations[0][0]) + Mathf.Abs(keylocations[2][1] - keylocations[0][1]) < 2 || Mathf.Abs(keylocations[2][0] - keylocations[1][0]) + Mathf.Abs(keylocations[2][1] - keylocations[1][1]) < 2) && i == 2))
            {
                keylocations[i][0] = Random.Range(1, 6);
                keylocations[i][1] = Random.Range(1, 6);
            }
            StartCoroutine(FlashKey(i));
        }
        for (int i = 0; i < 3; i++)
        {
            List<string>[] grid = new List<string>[15] { new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { } };
            mazenumber[i][0] = Random.Range(0, 16);
            mazenumber[i][1] = Random.Range(0, 4);
            switch (i)
            {
                case 0:
                    for (int j = 0; j < 15; j++)
                    {
                        for (int k = 0; k < 15; k++)
                        {
                            switch (mazenumber[0][1])
                            {
                                case 1:
                                    if (mazes[mazenumber[0][0]][j][14 - k] == 'X')
                                    {
                                        grid[j].Add("R");
                                    }
                                    else
                                    {
                                        grid[j].Add("K");
                                    }
                                    break;
                                case 2:
                                    if (mazes[mazenumber[0][0]][14 - j][14 - k] == 'X')
                                    {
                                        grid[j].Add("R");
                                    }
                                    else
                                    {
                                        grid[j].Add("K");
                                    }
                                    break;
                                case 3:
                                    if (mazes[mazenumber[0][0]][14 - j][k] == 'X')
                                    {
                                        grid[j].Add("R");
                                    }
                                    else
                                    {
                                        grid[j].Add("K");
                                    }
                                    break;
                                default:
                                    if (mazes[mazenumber[0][0]][j][k] == 'X')
                                    {
                                        grid[j].Add("R");
                                    }
                                    else
                                    {
                                        grid[j].Add("K");
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case 1:
                    while (mazenumber[1][0] == mazenumber[0][0])
                        mazenumber[1][0] = Random.Range(0, 10);
                    for (int j = 0; j < 15; j++)
                    {
                        for (int k = 0; k < 15; k++)
                        {
                            switch (mazenumber[1][1])
                            {
                                case 1:
                                    if (mazes[mazenumber[1][0]][j][14 - k] == 'X')
                                    {
                                        if (gridmaze[j][k] == 'R')
                                            grid[j].Add("Y");
                                        else
                                            grid[j].Add("G");
                                    }
                                    else
                                    {
                                        grid[j].Add(gridmaze[j][k].ToString());
                                    }
                                    break;
                                case 2:
                                    if (mazes[mazenumber[1][0]][14 - j][14 - k] == 'X')
                                    {
                                        if (gridmaze[j][k] == 'R')
                                            grid[j].Add("Y");
                                        else
                                            grid[j].Add("G");
                                    }
                                    else
                                    {
                                        grid[j].Add(gridmaze[j][k].ToString());
                                    }
                                    break;
                                case 3:
                                    if (mazes[mazenumber[1][0]][14 - j][k] == 'X')
                                    {
                                        if (gridmaze[j][k] == 'R')
                                            grid[j].Add("Y");
                                        else
                                            grid[j].Add("G");
                                    }
                                    else
                                    {
                                        grid[j].Add(gridmaze[j][k].ToString());
                                    }
                                    break;
                                default:
                                    if (mazes[mazenumber[1][0]][j][k] == 'X')
                                    {
                                        if (gridmaze[j][k] == 'R')
                                            grid[j].Add("Y");
                                        else
                                            grid[j].Add("G");
                                    }
                                    else
                                    {
                                        grid[j].Add(gridmaze[j][k].ToString());
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                default:
                    while (mazenumber[2][0] == mazenumber[0][0] || mazenumber[2][0] == mazenumber[1][0])
                        mazenumber[2][0] = Random.Range(0, 10);
                    for (int j = 0; j < 15; j++)
                    {
                        for (int k = 0; k < 15; k++)
                        {
                            switch (mazenumber[2][1])
                            {
                                case 1:
                                    if (mazes[mazenumber[2][0]][j][14 - k] == 'X')
                                    {
                                        if (gridmaze[j][k] == 'Y')
                                            grid[j].Add("W");
                                        else if (gridmaze[j][k] == 'R')
                                            grid[j].Add("M");
                                        else if (gridmaze[j][k] == 'G')
                                            grid[j].Add("C");
                                        else
                                            grid[j].Add("B");
                                    }
                                    else
                                    {
                                        grid[j].Add(gridmaze[j][k].ToString());
                                    }
                                    break;
                                case 2:
                                    if (mazes[mazenumber[2][0]][14 - j][14 - k] == 'X')
                                    {
                                        if (gridmaze[j][k] == 'Y')
                                            grid[j].Add("W");
                                        else if (gridmaze[j][k] == 'R')
                                            grid[j].Add("M");
                                        else if (gridmaze[j][k] == 'G')
                                            grid[j].Add("C");
                                        else
                                            grid[j].Add("B");
                                    }
                                    else
                                    {
                                        grid[j].Add(gridmaze[j][k].ToString());
                                    }
                                    break;
                                case 3:
                                    if (mazes[mazenumber[2][0]][14 - j][k] == 'X')
                                    {
                                        if (gridmaze[j][k] == 'Y')
                                            grid[j].Add("W");
                                        else if (gridmaze[j][k] == 'R')
                                            grid[j].Add("M");
                                        else if (gridmaze[j][k] == 'G')
                                            grid[j].Add("C");
                                        else
                                            grid[j].Add("B");
                                    }
                                    else
                                    {
                                        grid[j].Add(gridmaze[j][k].ToString());
                                    }
                                    break;
                                default:
                                    if (mazes[mazenumber[2][0]][j][k] == 'X')
                                    {
                                        if (gridmaze[j][k] == 'Y')
                                            grid[j].Add("W");
                                        else if (gridmaze[j][k] == 'R')
                                            grid[j].Add("M");
                                        else if (gridmaze[j][k] == 'G')
                                            grid[j].Add("C");
                                        else
                                            grid[j].Add("B");
                                    }
                                    else
                                    {
                                        grid[j].Add(gridmaze[j][k].ToString());
                                    }
                                    break;
                            }
                        }
                    }
                    break;
            }
            Debug.LogFormat("[Faulty RGB Maze #{2}]The {3} key is located at {0}{1}", "ABCDEFG"[keylocations[i][1]], "1234567"[keylocations[i][0]], moduleID, new string[3] { "red", "green", "blue" }[i]);
            if (colb == true)
            {
                ledcol[i].text = "ABCDEFG"[keylocations[i][1]].ToString() + "1234567"[keylocations[i][0]].ToString();
            }
            Debug.LogFormat("[Faulty RGB Maze #{2}]The {3} maze is maze {0}{1}", "0123456789abcdef"[mazenumber[i][0]], new string[4] { string.Empty, " flipped horizontally", " flipped horizontally and vertically", " flipped vertically" }[mazenumber[i][1]], moduleID, new string[3] { "red", "green", "blue" }[i]);
            Debug.LogFormat("[Faulty RGB Maze #{0}]Switching from the {2} maze moves {1} space(s) to the right and {2} space(s) down", moduleID, teleport[i + 1][0], teleport[i + 1][1], new string[3] { "red", "green", "blue"}[i]);
            Debug.LogFormat("[Faulty RGB Maze #{1}]The fault in the {2} maze is defect {0}", "#123456789abcde"[switchforbid[i]], moduleID, new string[3] { "red", "green", "blue" }[i]);
            for (int j = 0; j < 15; j++)
            {
                gridmaze[j] = string.Join(string.Empty, grid[j].ToArray());
            }
            switch (mazenumber[i][0])
            {
                case 0:
                    segon[i] = new bool[7] { true, true, true, false, true, true, true };
                    break;
                case 1:
                    segon[i] = new bool[7] { false, false, true, false, false, true, false };
                    break;
                case 2:
                    segon[i] = new bool[7] { true, false, true, true, true, false, true };
                    break;
                case 3:
                    segon[i] = new bool[7] { true, false, true, true, false, true, true };
                    break;
                case 4:
                    segon[i] = new bool[7] { false, true, true, true, false, true, false };
                    break;
                case 5:
                    segon[i] = new bool[7] { true, true, false, true, false, true, true };
                    break;
                case 6:
                    segon[i] = new bool[7] { true, true, false, true, true, true, true };
                    break;
                case 7:
                    segon[i] = new bool[7] { true, false, true, false, false, true, false };
                    break;
                case 9:
                    segon[i] = new bool[7] { true, true, true, true, false, true, true };
                    break;
                case 10:
                    segon[i] = new bool[7] { true, false, true, true, true, true, true };
                    break;
                case 11:
                    segon[i] = new bool[7] { false, true, false, true, true, true, true };
                    break;
                case 12:
                    segon[i] = new bool[7] { true, true, false, false, true, false, true };
                    break;
                case 13:
                    segon[i] = new bool[7] { false, false, true, true, true, true, true };
                    break;
                case 14:
                    segon[i] = new bool[7] { true, true, true, true, true, false, true };
                    break;
                case 15:
                    segon[i] = new bool[7] { true, true, false, true, true, false, false };
                    break;
                default:
                    segon[i] = new bool[7] { true, true, true, true, true, true, true };
                    break;
            }
            for (int j = 0; j < 7; j++)
            {
                if(segflip[i] == true)
                {
                    if(segon[i][j] == true)
                    {
                        segon[i][j] = false;
                    }
                    else
                    {
                        segon[i][j] = true;
                    }
                }
            }
        }
        string gridmaez = string.Empty;
        for(int i = 0; i < 15; i++)
        {
            gridmaez +=  "\n[RGB Maze #" + moduleID + "]" + gridmaze[i]; 
        }
        Debug.LogFormat("[Faulty RGB Maze #{0}]The grid:{1}",moduleID, gridmaez);
        for (int i = 0; i < 7; i++)
        {
            int switchseg = 0;
            for(int j = 0; j < 3; j++)
            {
                if (segon[j][i] == true)
                    switchseg += (int)Mathf.Pow(2, 2 - j);
            }
            switch (switchseg)
            {
                case 1:
                    segdisplay[i].material = colours[3];
                    break;
                case 2:
                    segdisplay[i].material = colours[2];
                    break;
                case 3:
                    segdisplay[i].material = colours[5];
                    break;
                case 4:
                    segdisplay[i].material = colours[1];
                    break;
                case 5:
                    segdisplay[i].material = colours[6];
                    break;
                case 6:
                    segdisplay[i].material = colours[7];
                    break;
                case 7:
                    segdisplay[i].material = colours[8];
                    break;
            }
            if(colb == true)
               segcol[i].text = "KBGCRMYW"[switchseg].ToString();
        }
        for(int i = 0; i < 4; i++)
        {
            int ledkey = 0;
            for (int j = 0; j < 3; j++)
            {
                if (mazenumber[j][1] == i)
                    ledkey += (int)Mathf.Pow(2, 2 - j);
            }
            switch (ledkey)
            {
                case 1:
                    orientleds[i].material = colours[3];
                    break;
                case 2:
                    orientleds[i].material = colours[2];
                    break;
                case 3:
                    orientleds[i].material = colours[5];
                    break;
                case 4:
                    orientleds[i].material = colours[1];
                    break;
                case 5:
                    orientleds[i].material = colours[6];
                    break;
                case 6:
                    orientleds[i].material = colours[7];
                    break;
                case 7:
                    orientleds[i].material = colours[8];
                    break;
            }
            if(colb == true)
                orientledcol[i].text = "KBGCRMYW"[ledkey].ToString();
        }
	}

    private void Press(int b)
    {
        if (firstmove == true)
        {
            firstmove = false;
            StopAllCoroutines();
            Audio.PlaySoundAtTransform("Switch", transform);
            if (colb == true)
            {
                mazecol.text = "R";
            }
            gridleds[7 * pos[0] + pos[1]].material = colours[8];
            if (pos[0] > 0)
                gridleds[7 * (pos[0] - 1) + pos[1]].material = colours[4];
            if (pos[1] > 0)
                gridleds[7 * pos[0] + pos[1] - 1].material = colours[4];
            if (pos[0] < 6)
                gridleds[7 * (pos[0] + 1) + pos[1]].material = colours[4];
            if (pos[1] < 6)
                gridleds[7 * pos[0] + pos[1] + 1].material = colours[4];
            foreach (Renderer frame in framework)
            {
                frame.material = colours[1];
            }
            for (int i = 0; i < 3; i++)
            {
                gridleds[7 * keylocations[i][0] + keylocations[i][1]].material = colours[0];
                ledcol[i].text = string.Empty;
            }
        }
        else if(moduleSolved == false)
        {
            gridleds[7 * pos[0] + pos[1]].material = colours[0];
            if (pos[0] > 0)
                gridleds[7 * (pos[0] - 1) + pos[1]].material = colours[0];
            if (pos[1] > 0)
                gridleds[7 * pos[0] + pos[1] - 1].material = colours[0];
            if (pos[0] < 6)
                gridleds[7 * (pos[0] + 1) + pos[1]].material = colours[0];
            if (pos[1] < 6)
                gridleds[7 * pos[0] + pos[1] + 1].material = colours[0];
            if (b == 7 * (pos[0] - 1) + pos[1])
            {
                if ((currentcol == 0 && (gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'R' || gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'Y' || gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'M')) || (currentcol == 1 && (gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'G' || gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'Y' || gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'C')) || (currentcol == 2 && (gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'B' || gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'C' || gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'M')) || gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'W')
                {
                    GetComponent<KMBombModule>().HandleStrike();
                    Debug.LogFormat("[Faulty RGB Maze #{0}]Error: Hit {1} wall north of {2}{3}", moduleID, gridmaze[2 * pos[0]][2 * pos[1] + 1], "ABCDEFGH"[pos[1]], "12345678"[pos[0]]);
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (i < 3)
                        {
                            if (currentcol != i && b == 7 * keylocations[i][0] + keylocations[i][1] && collect[i] == false)
                            {
                                GetComponent<KMBombModule>().HandleStrike();
                                Debug.LogFormat("[Faulty RGB Maze #{0}]Error: Attempted to collect {1} key from {2} maze", moduleID, "RGB"[i], "RGB"[currentcol]);
                                break;
                            }
                            else if(exit == true && currentcol != exitlocation[0] && b == 7 * exitlocation[1] + exitlocation[2])
                            {
                                GetComponent<KMBombModule>().HandleStrike();
                                Debug.LogFormat("[Faulty RGB Maze #{0}]Error: Attempted to exit through {1} exit from {2} maze", moduleID, "RGB"[i], "RGB"[currentcol]);
                                break;
                            }
                        }
                        else
                        {
                            Audio.PlaySoundAtTransform("Move", transform);
                            for (int j = 0; j < 3; j++)
                            {
                                if (exit == false)
                                {
                                    if (currentcol == j && b == 7 * keylocations[j][0] + keylocations[j][1] && collect[j] == false)
                                    {
                                        collect[j] = true;
                                        Audio.PlaySoundAtTransform("InputCorrect", transform);
                                        Debug.LogFormat("[Faulty RGB Maze #{0}]{1} key collected", moduleID, "RGB"[j]);
                                        meter[j].material = colours[j + 1];
                                    }
                                }
                                else if (currentcol == exitlocation[0] && b == 7 * exitlocation[1] + exitlocation[2])
                                {
                                    GetComponent<KMBombModule>().HandlePass();
                                    moduleSolved = true;
                                    break;
                                }
                            }
                            pos[0]--;
                        }
                    }
                }
            }
            else if (b == 7 * pos[0] + pos[1] - 1)
            {
                if ((currentcol == 0 && (gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'R' || gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'Y' || gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'M')) || (currentcol == 1 && (gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'G' || gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'Y' || gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'C')) || (currentcol == 2 && (gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'B' || gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'C' || gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'M')) || gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'W')
                {
                    GetComponent<KMBombModule>().HandleStrike();
                    Debug.LogFormat("[Faulty RGB Maze #{0}]Error: Hit {1} wall west of {2}{3}", moduleID, gridmaze[2 * pos[0] + 1][2 * pos[1]], "ABCDEFGH"[pos[1]], "12345678"[pos[0]]);
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (i < 3)
                        {
                            if (currentcol != i && b == 7 * keylocations[i][0] + keylocations[i][1] && collect[i] == false)
                            {
                                GetComponent<KMBombModule>().HandleStrike();
                                Debug.LogFormat("[Faulty RGB Maze #{0}]Error: Attempted to collect {1} key from {2} maze", moduleID, "RGB"[i], "RGB"[currentcol]);
                                break;
                            }
                            else if (exit == true && currentcol != exitlocation[0] && b == 7 * exitlocation[1] + exitlocation[2])
                            {
                                GetComponent<KMBombModule>().HandleStrike();
                                Debug.LogFormat("[Faulty RGB Maze #{0}]Error: Attempted to exit through {1} exit from {2} maze", moduleID, "RGB"[i], "RGB"[currentcol]);
                                break;
                            }
                        }
                        else
                        {
                            Audio.PlaySoundAtTransform("Move", transform);
                            for (int j = 0; j < 3; j++)
                            {
                                if (exit == false)
                                {
                                    if (currentcol == j && b == 7 * keylocations[j][0] + keylocations[j][1] && collect[j] == false)
                                    {
                                        collect[j] = true;
                                        Audio.PlaySoundAtTransform("InputCorrect", transform);
                                        Debug.LogFormat("[Faulty RGB Maze #{0}]{1} key collected", moduleID, "RGB"[j]);
                                        meter[j].material = colours[j + 1];
                                    }
                                }
                                else if (currentcol == exitlocation[0] && b == 7 * exitlocation[1] + exitlocation[2])
                                {
                                    GetComponent<KMBombModule>().HandlePass();
                                    moduleSolved = true;
                                    break;
                                }
                            }
                            pos[1]--;
                        }
                    }
                }
            }
            else if (b == 7 * (pos[0] + 1) + pos[1])
            {
                if ((currentcol == 0 && (gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'R' || gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'Y' || gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'M')) || (currentcol == 1 && (gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'G' || gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'Y' || gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'C')) || (currentcol == 2 && (gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'B' || gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'C' || gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'M')) || gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'W')
                {
                    GetComponent<KMBombModule>().HandleStrike();
                    Debug.LogFormat("[Faulty RGB Maze #{0}]Error: Hit {1} wall south of {2}{3}", moduleID, gridmaze[2 * pos[0] + 2][2 * pos[1] + 1], "ABCDEFGH"[pos[1]], "12345678"[pos[0]]);
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (i < 3)
                        {
                            if (currentcol != i && b == 7 * keylocations[i][0] + keylocations[i][1] && collect[i] == false)
                            {
                                GetComponent<KMBombModule>().HandleStrike();
                                Debug.LogFormat("[Faulty RGB Maze #{0}]Error: Attempted to collect {1} key from {2} maze", moduleID, "RGB"[i], "RGB"[currentcol]);
                                break;
                            }
                            else if (exit == true && currentcol != exitlocation[0] && b == 7 * exitlocation[1] + exitlocation[2])
                            {
                                GetComponent<KMBombModule>().HandleStrike();
                                Debug.LogFormat("[Faulty RGB Maze #{0}]Error: Attempted to exit through {1} exit from {2} maze", moduleID, "RGB"[i], "RGB"[currentcol]);
                                break;
                            }
                        }
                        else
                        {
                            Audio.PlaySoundAtTransform("Move", transform);
                            for (int j = 0; j < 3; j++)
                            {
                                if (exit == false)
                                {
                                    if (currentcol == j && b == 7 * keylocations[j][0] + keylocations[j][1] && collect[j] == false)
                                    {
                                        collect[j] = true;
                                        Audio.PlaySoundAtTransform("InputCorrect", transform);
                                        Debug.LogFormat("[Faulty RGB Maze #{0}]{1} key collected", moduleID, "RGB"[j]);
                                        meter[j].material = colours[j + 1];
                                    }
                                }
                                else if (currentcol == exitlocation[0] && b == 7 * exitlocation[1] + exitlocation[2])
                                {
                                    GetComponent<KMBombModule>().HandlePass();
                                    moduleSolved = true;
                                    break;
                                }
                            }
                            pos[0]++;
                        }
                    }
                }
            }
            else if (b == 7 * pos[0] + pos[1] + 1)
            {
                if ((currentcol == 0 && (gridmaze[2 * pos[0] + 1][2 * pos[1] + 2] == 'R' || gridmaze[2 * pos[0] + 1][2 * pos[1] + 1] == 'Y' || gridmaze[2 * pos[0] + 1][2 * pos[1] + 2] == 'M')) || (currentcol == 1 && (gridmaze[2 * pos[0] + 1][2 * pos[1] + 2] == 'G' || gridmaze[2 * pos[0] + 1][2 * pos[1] + 2] == 'Y' || gridmaze[2 * pos[0] + 1][2 * pos[1] + 2] == 'C')) || (currentcol == 2 && (gridmaze[2 * pos[0] + 1][2 * pos[1] + 2] == 'B' || gridmaze[2 * pos[0] + 1][2 * pos[1] + 2] == 'C' || gridmaze[2 * pos[0] + 1][2 * pos[1] + 2] == 'M')) || gridmaze[2 * pos[0] + 1][2 * pos[1] + 2] == 'W')
                {
                    GetComponent<KMBombModule>().HandleStrike();
                    Debug.LogFormat("[Faulty RGB Maze #{0}]Error: Hit {1} wall east of {2}{3}", moduleID, gridmaze[2 * pos[0] + 1][2 * pos[1] + 2], "ABCDEFGH"[pos[1]], "12345678"[pos[0]]);
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (i < 3)
                        {
                            if (currentcol != i && b == 7 * keylocations[i][0] + keylocations[i][1] && collect[i] == false)
                            {
                                GetComponent<KMBombModule>().HandleStrike();
                                Debug.LogFormat("[Faulty RGB Maze #{0}]Error: Attempted to collect {1} key from {2} maze", moduleID, "RGB"[i], "RGB"[currentcol]);
                                break;
                            }
                            else if (exit == true && currentcol != exitlocation[0] && b == 7 * exitlocation[1] + exitlocation[2])
                            {
                                GetComponent<KMBombModule>().HandleStrike();
                                Debug.LogFormat("[Faulty RGB Maze #{0}]Error: Attempted to exit through {1} exit from {2} maze", moduleID, "RGB"[i], "RGB"[currentcol]);
                                break;
                            }
                        }
                        else
                        {
                            Audio.PlaySoundAtTransform("Move", transform);
                            for (int j = 0; j < 3; j++)
                            {
                                if (exit == false)
                                {
                                    if (currentcol == j && b == 7 * keylocations[j][0] + keylocations[j][1] && collect[j] == false)
                                    {
                                        collect[j] = true;
                                        Audio.PlaySoundAtTransform("InputCorrect", transform);
                                        Debug.LogFormat("[Faulty RGB Maze #{0}]{1} key collected", moduleID, "RGB"[j]);
                                        meter[j].material = colours[j + 1];
                                    }
                                }
                                else if (currentcol == exitlocation[0] && b == 7 * exitlocation[1] + exitlocation[2])
                                {
                                    GetComponent<KMBombModule>().HandlePass();
                                    moduleSolved = true;
                                    break;
                                }
                            }
                            pos[1]++;
                        }
                    }
                }
            }
            else if (b == 7 * pos[0] + pos[1])
            {
                bool stuck = false;
                switch (switchforbid[currentcol])
                {
                    case 1:
                        if (pos[1] % 2 == 0)
                            stuck = true;
                        break;
                    case 2:
                        if (Mathf.Abs(3 -pos[0]) + Mathf.Abs(3 - pos[1]) == 0 || Mathf.Abs(3 - pos[0]) + Mathf.Abs(3 - pos[1]) == 3 || Mathf.Abs(3 - pos[0]) + Mathf.Abs(3 - pos[1]) == 6)
                            stuck = true;
                        break;
                    case 3:
                        if ((pos[0] + pos[1]) % 2 == 0)
                            stuck = true;
                        break;
                    case 4:
                        if (Mathf.Abs(3 - pos[0]) + Mathf.Abs(3 - pos[1]) == 1 || Mathf.Abs(3 - pos[0]) + Mathf.Abs(3 - pos[1]) == 4)
                            stuck = true;
                        break;
                    case 5:
                        if (pos[0] % 2 == 1)
                            stuck = true;
                        break;
                    case 6:
                        if (Mathf.Abs(3 - pos[0]) + Mathf.Abs(3 - pos[1]) == 2 || Mathf.Abs(3 - pos[0]) + Mathf.Abs(3 - pos[1]) == 5)
                            stuck = true;
                        break;
                    case 7:
                        if (pos[0] == 0 || pos[0] == 6 || pos[1] == 0 || pos[1] == 6)
                            stuck = true;
                        break;
                    case 8:
                        if (pos[0] % 2 == 0)
                            stuck = true;
                        break;
                    case 9:
                        if (pos[0] == tracker[0])
                            stuck = true;
                        break;
                    case 10:
                        if ((pos[0] + pos[1]) % 2 == 1)
                            stuck = true;
                        break;
                    case 11:
                        if (Mathf.Abs(pos[0] - tracker[0]) + Mathf.Abs(pos[1] - tracker[1]) > 3)
                            stuck = true;
                        break;
                    case 12:
                        if (pos[1] % 2 == 1)
                            stuck = true;
                        break;
                    case 13:
                        if (pos[1] == tracker[1])
                            stuck = true;
                        break;
                    case 14:
                        if (pos[0] == 3 || pos[1] == 3)
                            stuck = true;
                        break;
                }
                if (stuck == true)
                {
                    GetComponent<KMBombModule>().HandleStrike();
                    Debug.LogFormat("[Faulty RGB Maze #{0}]Error: Attempted to switch the {1} maze from faulty space: {2}{3}", moduleID, "RGB"[currentcol], "ABCDEFGH"[pos[1]], "12345678"[pos[0]]);
                }
                else if ((b + 7 * teleport[currentcol + 1][0] + teleport[currentcol + 1][1]) % 49 == 7 * keylocations[(currentcol + 1) % 3][0] + keylocations[(currentcol + 1) % 3][1] && collect[(currentcol + 1) % 3] == false)
                {
                    GetComponent<KMBombModule>().HandleStrike();
                    Debug.LogFormat("[Faulty RGB Maze #{0}]Error: Attempted to collect {1} key from {2} maze", moduleID, "RGB"[(currentcol + 1) % 3], "RGB"[currentcol]);
                }
                else if (exit == true && currentcol != exitlocation[0] && (b + 7 * teleport[currentcol + 1][0] + teleport[currentcol + 1][1]) % 49 == 7 * exitlocation[1] + exitlocation[2])
                {
                    GetComponent<KMBombModule>().HandleStrike();
                    Debug.LogFormat("[Faulty RGB Maze #{0}]Error: Attempted to exit through {1} exit from {2} maze", moduleID, "RGB"[(currentcol + 1) % 3], "RGB"[currentcol]);
                }
                else
                {
                    currentcol++;
                    currentcol %= 3;
                    Audio.PlaySoundAtTransform("Switch", transform);
                    if (colb == true)
                    {
                        mazecol.text = "RGB"[currentcol].ToString();
                    }
                    foreach (Renderer frame in framework)
                    {
                        frame.material = colours[currentcol + 1];
                    }
                    pos[0] += teleport[currentcol + 1][0];
                    pos[1] += teleport[currentcol + 1][1];
                    pos[0] %= 7;
                    pos[1] %= 7;
                    if (switchforbid[currentcol] == 9 || switchforbid[currentcol] == 11 || switchforbid[currentcol] == 13)
                    {
                        tracker[0] = pos[0];
                        tracker[1] = pos[1];
                    }
                }               
            }
            if (collect[0] == true && collect[1] == true && collect[2] == true && exit == false)
            {
                exit = true;
                Debug.LogFormat("[Faulty RGB Maze #{0}]All keys collected: the exit lies at {1}{2} in the {3} maze", moduleID, "ABCDEFGH"[exitlocation[2]], "12345678"[exitlocation[1]], "RGB"[exitlocation[0]]);      
                switch (exitlocation[1])
                {
                    case 0:
                        segon[1] = new bool[7] { false, false, true, false, false, true, false };
                        break;
                    case 1:
                        segon[1] = new bool[7] { true, false, true, true, true, false, true };
                        break;
                    case 2:
                        segon[1] = new bool[7] { true, false, true, true, false, true, true };
                        break;
                    case 3:
                        segon[1] = new bool[7] { false, true, true, true, false, true, false };
                        break;
                    case 4:
                        segon[1] = new bool[7] { true, true, false, true, false, true, true };
                        break;
                    case 5:
                        segon[1] = new bool[7] { true, true, false, true, true, true, true };
                        break;
                    case 6:
                        segon[1] = new bool[7] { true, false, true, false, false, true, false };
                        break;
                    default:
                        segon[1] = new bool[7] { true, true, true, true, true, true, true };
                        break;
                }                           
                switch (exitlocation[2])
                {
                    case 0:
                        segon[2] = new bool[7] { true, true, true, true, true, true, false };
                        break;
                    case 1:
                        segon[2] = new bool[7] { false, true, false, true, true, true, true };
                        break;
                    case 2:
                        segon[2] = new bool[7] { true, true, false, false, true, false, true };
                        break;
                    case 3:
                        segon[2] = new bool[7] { false, false, true, true, true, true, true };
                        break;
                    case 4:
                        segon[2] = new bool[7] { true, true, false, true, true, false, true };
                        break;
                    case 5:
                        segon[2] = new bool[7] { true, true, false, true, true, false, false };
                        break;
                    case 6:
                        segon[2] = new bool[7] { true, true, false, false, true, true, true };
                        break;
                    default:
                        segon[2] = new bool[7] { false, true, true, true, true, true, false };
                        break;
                }                                                                                             
                switch (Random.Range(0, 10))
                {
                    case 0:
                        segon[0] = new bool[7] { true, false, false, true, false, false, true };
                        break;
                    case 1:
                        segon[0] = new bool[7] { false, true, true, true, true, true, true };
                        break;
                    case 2:
                        segon[0] = new bool[7] { false, false, false, true, true, true, true };
                        break;
                    case 3:
                        segon[0] = new bool[7] { false, true, true, false, true, true, false };
                        break;
                    case 4:
                        segon[0] = new bool[7] { true, false, false, true, false, false, true };
                        break;
                    case 5:
                        segon[0] = new bool[7] { true, false, true, false, false, true, true };
                        break;
                    case 6:
                        segon[0] = new bool[7] { true, false, false, true, true, true, false };
                        break;
                    case 7:
                        segon[0] = new bool[7] { true, true, true, true, false, false, true };
                        break;
                    case 8:
                        segon[0] = new bool[7] { true, false, true, false, true, false, true };
                        break;
                    case 9:
                        segon[0] = new bool[7] { true, true, true, false, true, true, false };
                        break;
                }
                for (int i = 0; i < 7; i++)
                {
                    int switchseg = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (segon[(j + 3 - exitlocation[0]) % 3][i] == true)
                            switchseg += (int)Mathf.Pow(2, 2 - j);
                    }
                    switch (switchseg)
                    {
                        case 1:
                            segdisplay[i].material = colours[3];
                            break;
                        case 2:
                            segdisplay[i].material = colours[2];
                            break;
                        case 3:
                            segdisplay[i].material = colours[5];
                            break;
                        case 4:
                            segdisplay[i].material = colours[1];
                            break;
                        case 5:
                            segdisplay[i].material = colours[6];
                            break;
                        case 6:
                            segdisplay[i].material = colours[7];
                            break;
                        case 7:
                            segdisplay[i].material = colours[8];
                            break;
                        default:
                            segdisplay[i].material = colours[0];
                            break;
                    }
                    if (colb == true)
                        segcol[i].text = "KBGCRMYW"[switchseg].ToString();                                             
                }
            }
            if (moduleSolved == false)
            {
                gridleds[7 * pos[0] + pos[1]].material = colours[8];
                previousButton = 7 * pos[0] + pos[1];
                if (pos[0] > 0)
                    gridleds[7 * (pos[0] - 1) + pos[1]].material = colours[4];
                if (pos[1] > 0)
                    gridleds[7 * pos[0] + pos[1] - 1].material = colours[4];
                if (pos[0] < 6)
                    gridleds[7 * (pos[0] + 1) + pos[1]].material = colours[4];
                if (pos[1] < 6)
                    gridleds[7 * pos[0] + pos[1] + 1].material = colours[4];
            }
            else
            {
                Audio.PlaySoundAtTransform("Exit", transform);
                mazecol.text = string.Empty;
                gridleds[7 * pos[0] + pos[1]].material = colours[0];
                if (pos[0] > 0)
                    gridleds[7 * (pos[0] - 1) + pos[1]].material = colours[0];
                if (pos[1] > 0)
                    gridleds[7 * pos[0] + pos[1] - 1].material = colours[0];
                if (pos[0] < 6)
                    gridleds[7 * (pos[0] + 1) + pos[1]].material = colours[0];
                if (pos[1] < 6)
                    gridleds[7 * pos[0] + pos[1] + 1].material = colours[0];
                foreach (Renderer thing in framework)
                {
                    thing.material = colours[0];
                }
                foreach (Renderer thing in meter)
                {
                    thing.material = colours[0];
                }
                foreach (Renderer thing in orientleds)
                {
                    thing.material = colours[0];
                }
                foreach (Renderer thing in segdisplay)
                {
                    thing.material = colours[0];
                }
                foreach (TextMesh thing in ledcol)
                {
                    thing.text = string.Empty;
                }
                foreach (TextMesh thing in orientledcol)
                {
                    thing.text = string.Empty;
                }
                foreach (TextMesh thing in segcol)
                {
                    thing.text = string.Empty;
                }
            }
        }
    }


    private IEnumerator FlashKey(int k)
    {
        for (int i = 0; i < 2; i++)
        {
            if (i == 0)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (j % 3 == 1 && Mathf.FloorToInt(switchforbid[k]/Mathf.Pow(2, Mathf.FloorToInt(j / 3))) % 2 == 1)
                    {
                        gridleds[7 * keylocations[k][0] + keylocations[k][1]].material = colours[k + 1];
                    }
                    else
                    {
                        gridleds[7 * keylocations[k][0] + keylocations[k][1]].material = colours[0];
                    }
                    yield return new WaitForSeconds(0.125f);
                }
            }
            else
            {
                i = -1;
                gridleds[7 * keylocations[k][0] + keylocations[k][1]].material = colours[k + 1];
                yield return new WaitForSeconds(1);
            }
        }
    }

    //twitch plays
    private int previousButton;

    private bool commandIsValid(string s)
    {
        char[] valids = { 'u', 'd', 'l', 'r', 'R', 'G', 'B' };
        s = s.Replace(" ", "");
        for (int i = 0; i < s.Length; i++)
        {
            if (!valids.Contains(s[i]))
            {
                return false;
            }
        }
        return true;
    }

#pragma warning disable 414
    private readonly string TwitchHelpMessage = @"!{0} start [Starts the module] | !{0} u/d/l/r [Moves in the specified direction] | !{0} R/G/B [Switches to the specified maze] | !{0} reset [Resets the module ENTIRELY] | Move and switch commands may be chained, for example '!{0} rdGuuRr'";
#pragma warning restore 414
    IEnumerator ProcessTwitchCommand(string command)
    {
        if (Regex.IsMatch(command, @"^\s*start\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            yield return null;
            if (firstmove == true)
            {
                gridbuttons[0].OnInteract();
            }
            else
            {
                yield return "sendtochaterror The module has already been started!";
            }
            yield break;
        }
        if (Regex.IsMatch(command, @"^\s*reset\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            yield return null;
            Debug.LogFormat("[RGB Maze #{0}] Reset of module triggered! [TP]", moduleID);
            for (int i = 0; i < gridleds.Length; i++)
            {
                gridleds[i].material = colours[0];
            }
            for (int i = 0; i < orientleds.Length; i++)
            {
                orientleds[i].material = colours[0];
            }
            for (int i = 0; i < framework.Length; i++)
            {
                framework[i].material = colours[8];
            }
            firstmove = true;
            Start();
            yield break;
        }
        if (commandIsValid(command) && firstmove == false)
        {
            yield return null;
            string temp = "";
            temp = command.Replace(" ", "");
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].Equals('u'))
                {
                    if ((previousButton - 7) < 0)
                    {
                        yield break;
                    }
                    else
                    {
                        gridbuttons[previousButton - 7].OnInteract();
                    }
                }
                else if (temp[i].Equals('d'))
                {
                    if ((previousButton + 7) > 48)
                    {
                        yield break;
                    }
                    else
                    {
                        gridbuttons[previousButton + 7].OnInteract();
                    }
                }
                else if (temp[i].Equals('l'))
                {
                    if (((previousButton % 7) - 1) < 0)
                    {
                        yield break;
                    }
                    else
                    {
                        gridbuttons[previousButton - 1].OnInteract();
                    }
                }
                else if (temp[i].Equals('r'))
                {
                    if (((previousButton % 7) + 1) > 6)
                    {
                        yield break;
                    }
                    else
                    {
                        gridbuttons[previousButton + 1].OnInteract();
                    }
                }
                else if (temp[i].Equals('R'))
                {
                    while (currentcol != 0)
                    {
                        gridbuttons[previousButton].OnInteract();
                        yield return new WaitForSeconds(0.1f);
                    }
                }
                else if (temp[i].Equals('G'))
                {
                    while (currentcol != 1)
                    {
                        gridbuttons[previousButton].OnInteract();
                        yield return new WaitForSeconds(0.1f);
                    }
                }
                else if (temp[i].Equals('B'))
                {
                    while (currentcol != 2)
                    {
                        gridbuttons[previousButton].OnInteract();
                        yield return new WaitForSeconds(0.1f);
                    }
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
