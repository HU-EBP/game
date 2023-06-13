using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NodeCheck : MonoBehaviour
{
    public enum NodeType { BUTTON, AND, NAND, NOT, OR, NOR, XOR, XNOR, EMPTY, END, REROUTE }
    public NodeType SelectedNodeType;
    [Tooltip("If the current node is powered or not.")] public bool IsPowered = false;
    [Tooltip("List of nodes that this node should connect to.")] public GameObject[] ConnectTo;
    [Tooltip("Changes line pathing direction - False (default) paths to Y first, then X. True paths to X first, then Y.")] [SerializeField] private bool[] LineThroughX;

    [HideInInspector] public int[] Connection_IDs;
    [HideInInspector] public bool[] Connection_Bools;

    private int CurrentID;
    private int SortingOrder;
    private Color StartColor;
    private Image ButtonImage;
    private Button ButtonObject;
    private NodeCheckVars VarScript;
    private LineRenderer[] LinesFront;
    private LineRenderer[] LinesWhite;
    private LineRenderer[] LinesBlack;
    private GameObject[] ChildObjects;
    private SpriteRenderer LightRenderer;
    private Color endColor = new Color(1f, 1f, 1f, 1f);
    private Color redColor = new Color(0.5f, 0f, 0f, 1f);
    private Color greenColor = new Color(0f, 0.5f, 0f, 1f);

    void Awake()
    {
        // Initializing/correcting arrays
        ChildObjects = new GameObject[ConnectTo.Length * 3];
        LinesFront = new LineRenderer[ConnectTo.Length];
        LinesWhite = new LineRenderer[ConnectTo.Length];
        LinesBlack = new LineRenderer[ConnectTo.Length];
        Connection_IDs = new int[2];
        Connection_Bools = new bool[2];
        if (ConnectTo.Length > LineThroughX.Length) { System.Array.Resize(ref LineThroughX, ConnectTo.Length); }

        // Setting connection IDs default values (high value of 1 million to be sure it never gets chosen as an actual ID for a node)
        Connection_IDs[0] = 1000000;
        Connection_IDs[1] = 1000000;

        VarScript = FindObjectOfType<NodeCheckVars>(); // Getting NodeCheckVars script
        CurrentID = VarScript.getID(); // Getting the (hopefully) unique ID for this Node

        // If node is of type BUTTON, get image and set onclick event to change button power
        if (SelectedNodeType == NodeType.BUTTON)
        {
            ButtonImage = transform.GetChild(0).GetComponent<Image>();
            ButtonObject = transform.GetChild(0).GetComponent<Button>();
            ButtonObject.onClick.AddListener(ChangeButtonPower);
        }

        // If node is of type END, get sprite renderer and starting color
        if (SelectedNodeType == NodeType.END)
        {
            LightRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
            StartColor = LightRenderer.color;
            if (ConnectTo.Length > 0) { Debug.LogError("OUT-connection(s) added on node of type END, " + gameObject.name + "! This will not function as expected and may break other things.", gameObject); }
        }

        // If not END, check if the node has connections to other nodes
        else if (ConnectTo.Length == 0) { Debug.LogError("No OUT-connection(s) added on " + gameObject.name + "!", gameObject); }

        // Check if node type was selected
        if (SelectedNodeType != NodeType.BUTTON && SelectedNodeType != NodeType.AND && SelectedNodeType != NodeType.NAND && SelectedNodeType != NodeType.NOT && SelectedNodeType != NodeType.OR && SelectedNodeType != NodeType.NOR && SelectedNodeType != NodeType.XOR && SelectedNodeType != NodeType.XNOR && SelectedNodeType != NodeType.EMPTY && SelectedNodeType != NodeType.END && SelectedNodeType != NodeType.REROUTE) { Debug.LogError("No node type selected on " + gameObject.name + "!", gameObject); }
    }

    void Start()
    {
        // Assigning this ID to the Connection_IDs list of the connected nodes
        for (int i = 0; i < ConnectTo.Length; i++)
        {
            NodeCheck ScriptHolder = ConnectTo[i].GetComponent<NodeCheck>();

            if (ScriptHolder.SelectedNodeType == NodeType.BUTTON || ScriptHolder.SelectedNodeType == NodeType.EMPTY)
            {
                Debug.LogWarning("Node with type " + ScriptHolder.SelectedNodeType + ", "+ ConnectTo[i] + ", has IN-connection(s)! Adding any IN-connections to this node type will cause unexpected behavior.", gameObject);
            }
            else if (ScriptHolder.Connection_IDs[0] == 1000000) { ScriptHolder.Connection_IDs[0] = CurrentID; }
            else if (ScriptHolder.SelectedNodeType == NodeType.END || ScriptHolder.SelectedNodeType == NodeType.NOT || ScriptHolder.SelectedNodeType == NodeType.REROUTE)
            {
                Debug.LogWarning("Node with type " + ScriptHolder.SelectedNodeType + ", " + ConnectTo[i] + ", has too many IN-connections! Adding more than one IN-connection to this node type will cause unexpected behavior.", gameObject);
            }
            else if (ScriptHolder.Connection_IDs[1] == 1000000) { ScriptHolder.Connection_IDs[1] = CurrentID; }
            else { Debug.LogWarning("Node " + ConnectTo[i] + " has too many IN-connections! Adding more than 2 connections will cause unexpected behavior.", gameObject); }
        }

        SetConnBools(); GetLines(); ClickCheck();
    }

    // Function to check node types
    public void ClickCheck()
    {
        // BUTTON check (no real checks, just changing line color)
        if (SelectedNodeType == NodeType.BUTTON)
        {
            if (IsPowered) { SetColor(greenColor); }
            else { SetColor(redColor); }
        }

        // AND node check (this node powered: if both inputs are powered)
        else if (SelectedNodeType == NodeType.AND)
        {
            if (Connection_Bools[0] && Connection_Bools[1]) { SetColor(greenColor); IsPowered = true; }
            else { SetColor(redColor); IsPowered = false; }
        }

        // NAND node check (this node powered: if both inputs are not powered, or either input is powered)
        else if (SelectedNodeType == NodeType.NAND)
        {
            if (Connection_Bools[0] && Connection_Bools[1]) { SetColor(redColor); IsPowered = false; }
            else { SetColor(greenColor); IsPowered = true; }
        }

        // NOT node check function (this node powered: if the singular input is not powered)
        else if (SelectedNodeType == NodeType.NOT)
        {
            if (!Connection_Bools[0]) { SetColor(greenColor); IsPowered = true; }
            else { SetColor(redColor); IsPowered = false; }
        }

        // OR node check (this node powered: if either - or both - of the inputs are powered)
        else if (SelectedNodeType == NodeType.OR)
        {
            if (Connection_Bools[0] || Connection_Bools[1]) { SetColor(greenColor); IsPowered = true; }
            else { SetColor(redColor); IsPowered = false; }
        }

        // NOR node check (this node powered: if neither of the inputs are powered)
        else if (SelectedNodeType == NodeType.NOR)
        {
            if (!Connection_Bools[0] && !Connection_Bools[1]) { SetColor(greenColor); IsPowered = true; }
            else { SetColor(redColor); IsPowered = false; }
        }

        // XOR node check (this node powered: if either - but not both - of the inputs are powered)
        else if (SelectedNodeType == NodeType.XOR)
        {
            if (Connection_Bools[0] && !Connection_Bools[1]) { SetColor(greenColor); IsPowered = true; }
            else if (!Connection_Bools[0] && Connection_Bools[1]) { SetColor(greenColor); IsPowered = true; }
            else { SetColor(redColor); IsPowered = false; }
        }

        // XNOR node check (this node powered: only if BOTH inputs are either true or false)
        else if (SelectedNodeType == NodeType.XNOR)
        {
            if (Connection_Bools[0] && Connection_Bools[1]) { SetColor(greenColor); IsPowered = true; }
            else if (!Connection_Bools[0] && !Connection_Bools[1]) { SetColor(greenColor); IsPowered = true; }
            else { SetColor(redColor); IsPowered = false; }
        }

        // EMPTY node check (empty off-screen node, player cannot change power)
        else if (SelectedNodeType == NodeType.EMPTY)
        {
            if (IsPowered) { SetColor(greenColor); }
            else { SetColor(redColor); }
        }

        // END node check (the end-goal, powered if singular input is powered)
        else if (SelectedNodeType == NodeType.END)
        {
            if (Connection_Bools[0]) { IsPowered = true; if (LightRenderer) { LightRenderer.color = endColor; } }
            else { IsPowered = false; if (LightRenderer) { LightRenderer.color = StartColor; } }
        }

        // REROUTE node check (point to reroute a line, just outputs the input)
        else if (SelectedNodeType == NodeType.REROUTE)
        {
            if (Connection_Bools[0]) { IsPowered = true; SetColor(greenColor); }
            else { IsPowered = false; SetColor(redColor); }
        }

        SetConnBools(); // Setting connected bools after running checks

        // Run check on the connected object(s)
        for (int i = 0; i < ConnectTo.Length; i++)
        {
            NodeCheck ScriptHolder = ConnectTo[i].GetComponent<NodeCheck>();
            ScriptHolder.ClickCheck();
        }
    }

    // Setting the connected nodes' connection booleans
    private void SetConnBools()
    {
        for (int i = 0; i < ConnectTo.Length; i++)
        {
            NodeCheck ScriptHolder = ConnectTo[i].GetComponent<NodeCheck>();
            if (ScriptHolder.Connection_IDs[0] == CurrentID) { ScriptHolder.Connection_Bools[0] = IsPowered; }
            else if (ScriptHolder.Connection_IDs[1] == CurrentID) { ScriptHolder.Connection_Bools[1] = IsPowered; }
        }
    }

    // Function to run when user presses the button (changes power status)
    public void ChangeButtonPower()
    {
        if (IsPowered) { IsPowered = false; }
        else { IsPowered = true; }
        ClickCheck();
    }

    // Line color setting functions (red/unpowered green/powered)
    private void SetColor(Color color)
    {
        if (ButtonImage) { ButtonImage.color = color; }
        for (int i = 0; i < LinesFront.Length; i++)
        {
            if (LinesFront[i] != null) { LinesFront[i].startColor = color; LinesFront[i].endColor = color; }
            if (LinesWhite[i] != null) { LinesWhite[i].startColor = Color.white; LinesWhite[i].endColor = Color.white; }
            if (LinesBlack[i] != null) { LinesBlack[i].startColor = Color.black; LinesBlack[i].endColor = Color.black; }
        }
    }

    // Function to get sorting order
    private void GetSortingOrder() { SortingOrder = VarScript.getSO(); }

    // Lines getting function
    private void GetLines()
    {
        // If node is not of type end, draw line
        if (SelectedNodeType != NodeType.END)
        {
            // Creating a child object with line for each target
            for (int i = 0; i < ConnectTo.Length; i++)
            {
                // Getting line positions
                Vector3 StartPos; Vector3 MidPos; Vector3 EndPos;
                if (LineThroughX[i]) 
                {
                    StartPos = new Vector3(transform.position.x, transform.position.y, 0f);
                    MidPos = new Vector3(ConnectTo[i].transform.position.x, transform.position.y, 0f);
                    EndPos = new Vector3(ConnectTo[i].transform.position.x, ConnectTo[i].transform.position.y, 0f);
                }
                else
                {
                    StartPos = new Vector3(transform.position.x, transform.position.y, 0f);
                    MidPos = new Vector3(transform.position.x, ConnectTo[i].transform.position.y, 0f);
                    EndPos = new Vector3(ConnectTo[i].transform.position.x, ConnectTo[i].transform.position.y, 0f);
                }

                // Calling set line function for line, line background (white), and line background background (black)
                SetLines(0, StartPos, MidPos, EndPos, LinesFront[i], 0.15f, 0.15f, 1, i);
                SetLines(1, StartPos, MidPos, EndPos, LinesWhite[i], 0.2f, 0.2f, 0, i);
                SetLines(2, StartPos, MidPos, EndPos, LinesBlack[i], 0.25f, 0.25f, 0, i);
            }
        }
    }

    // Lines drawing function
    private void SetLines(int LineArrayNum, Vector3 StartPos, Vector3 MidPos, Vector3 EndPos, LineRenderer connectedLine, float StartWidth, float EndWidth, int CornerVertices, int i)
    {
        GetSortingOrder();
        ChildObjects[i] = new GameObject("LineRendererSO" + SortingOrder);
        ChildObjects[i].transform.parent = transform;

        connectedLine = ChildObjects[i].AddComponent<LineRenderer>();

        connectedLine.positionCount = 3;
        connectedLine.SetPosition(0, StartPos);
        connectedLine.SetPosition(1, MidPos);
        connectedLine.SetPosition(2, EndPos);

        connectedLine.startWidth = StartWidth;
        connectedLine.endWidth = EndWidth;
        connectedLine.numCornerVertices = CornerVertices;
        connectedLine.material = new Material(Shader.Find("Sprites/Default"));
        connectedLine.sortingOrder = SortingOrder;

        if (LineArrayNum == 0) { LinesFront[i] = connectedLine; }
        else if (LineArrayNum == 1) { LinesWhite[i] = connectedLine; }
        else if (LineArrayNum == 2) { LinesBlack[i] = connectedLine; }
    }
}