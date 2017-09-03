﻿using UnityEditor;
using UnityEngine;

namespace Weaver
{
    [CustomPropertyDrawer(typeof(WeavedAssembly))]
    public class WeavedAssemblyDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();
            {
                const float BUTTON_WIDTH = 25;
                SerializedProperty filePath = property.FindPropertyRelative("m_FilePath");
                SerializedProperty enabled = property.FindPropertyRelative("m_Enabled");
                position.width -= BUTTON_WIDTH;
                EditorGUI.SelectableLabel(position, filePath.stringValue, EditorStyles.textArea);
                position.x += position.width;
                position.width = BUTTON_WIDTH;
                enabled.boolValue = EditorGUI.Toggle(position, enabled.boolValue);
            }
            if(EditorGUI.EndChangeCheck())
            {
                property.serializedObject.ApplyModifiedProperties();
            }
        }
    }
}