using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(PlateauBeweger))]
public class PointEditor : Editor
{
    PlateauBeweger plateau;
    string text = "Nothing Opened...";
    bool clicked;

    private void OnSceneGUI()
    {
        PlateauBeweger plateau = target as PlateauBeweger;
        Handles.color = Color.white;
        Transform handletransform = plateau.transform;


        Quaternion handleRotation = handletransform.rotation;
        Vector3 p0 = handletransform.TransformPoint(plateau.position1);
        Vector3 p1 = handletransform.TransformPoint(plateau.position2);

        Handles.color = Color.white;
        Handles.DrawLine(p0, p1);
        //Handles.DoPositionHandle(p1, handleRotation);
        //Handles.DoPositionHandle(p0, handleRotation);

        EditorGUI.BeginChangeCheck();
        p1 = Handles.DoPositionHandle(p1, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(plateau, "Move Point");
            EditorUtility.SetDirty(plateau);
            plateau.position2 = handletransform.InverseTransformPoint(p1);
        }


        
        EditorGUI.BeginChangeCheck();
        p0 = Handles.DoPositionHandle(p0, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(plateau, "Move Point");
            EditorUtility.SetDirty(plateau);
            plateau.position1 = handletransform.InverseTransformPoint(p0);
        }


    }

    public override void OnInspectorGUI()
    {
        PlateauBeweger plateau = (PlateauBeweger)target;

        if (GUILayout.Button("uitleg"))
        {
            if (clicked)
                clicked = false;
            else
                clicked = true;
        }

        if(clicked)
        {
            EditorGUILayout.HelpBox("Dit script kan een plateau doen bewegen tussen twee punten. \nJe bepaalt de twee uiteindes van de beweging met de twee 'positie' punten en bepaald vervolgens de snelheid met de 'snelheid' slider. \nJe kunt je eigen plateau toevoegen door het simpelweg in het 'plateauobject' object te slepen", MessageType.Info);
        }



        plateau.position1 = EditorGUILayout.Vector3Field("positie 1", plateau.position1);
        plateau.position2 = EditorGUILayout.Vector3Field("positie 2", plateau.position2);
        //plateau.speed = EditorGUILayout.FloatField("speed", plateau.speed);

        plateau.speed = EditorGUILayout.Slider("snelheid", plateau.speed, 0, 100);
    }
}
