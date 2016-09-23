using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(RailSection), true)]
[CanEditMultipleObjects]
public class RailroadEditor : Editor {


	
	

    Rect windowRect = new Rect(14, 24, 100, 92);

    public void OnSceneGUI()
    {
        Handles.BeginGUI();

        GUILayout.Window(333, windowRect, DoMyWindow, "Railroad Section");

        Handles.EndGUI();
        if (Selection.activeGameObject != null)
        {
            List<Vector3> joints = Selection.activeGameObject.GetComponent<RailSection>().GetJoints();
            foreach (var v in joints)
                Handles.DrawCube(0, v, Quaternion.identity, 0.5f);
           // Handles.DrawLine(Vector3.zero, Selection.activeGameObject.transform.position);
        }

        
    }

    static GUIContent RotateCWButton = new GUIContent("RCW", "Rotate by 22.5 degrees clockwise");
    static GUIContent RotateCCWButton = new GUIContent("RCCW", "Rotate by 22.5 degrees counter-clockwise");
    static GUIContent SnapButton = new GUIContent("Snap to Section", "Snap to nearest railroad section");
    static GUIContent SnapButton2 = new GUIContent("Snap to Train", "Snap to nearest train");

    static RailroadEditor()
    {
        LoadIcons();
    }

    static void LoadIcons()
    {
        Texture2D cwIcon = (Texture2D)(AssetDatabase.LoadAssetAtPath("Assets/SimpleRailroads/Editor/rotate_cw.png", typeof(Texture2D)));
        Texture2D ccwIcon = (Texture2D)(AssetDatabase.LoadAssetAtPath("Assets/SimpleRailroads/Editor/rotate_ccw.png", typeof(Texture2D)));

        RotateCWButton = new GUIContent(cwIcon, "Rotate by 22.5 degrees clockwise");
        RotateCCWButton = new GUIContent(ccwIcon, "Rotate by 22.5 degrees counter-clockwise");
    }

    void DoMyWindow(int windowID)
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button(RotateCWButton))
        {
            Selection.activeGameObject.transform.Rotate(0, 22.5f, 0);
        }


        if (GUILayout.Button(RotateCCWButton))
        {
            Selection.activeGameObject.transform.Rotate(0, -22.5f, 0);
        }

        GUILayout.EndHorizontal();


        if (GUILayout.Button(SnapButton))
        {
            
        }

        if (GUILayout.Button(SnapButton2))
        {

        }

        

    }
}
