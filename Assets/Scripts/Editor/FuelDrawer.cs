using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Fuel))]
public class FuelDrawer : Editor
{
    public override void OnInspectorGUI()
    {
        Fuel fuel = target as Fuel;

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Fuel:");

        if (fuel.IsNew)
        {
            GUILayout.Label("???", GUILayout.Width(25));
        }
        else
        {
            var label = string.Format("{0:0.00}", fuel.Amount);
            GUILayout.Label(label, GUILayout.Width(45));
            Repaint();
        }

        GUILayout.Label("/", GUILayout.Width(10));

        var max_property = serializedObject.FindProperty("max");
        EditorGUILayout.PropertyField(max_property, GUIContent.none, true, GUILayout.MaxWidth(75));
        EditorGUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();

    }
}
