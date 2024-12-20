using Gaskellgames;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.CameraController
{
    [CustomEditor(typeof(CameraMultiTarget))] [CanEditMultipleObjects]
    public class CameraMultiTargetEditor : Editor
    {
        #region Serialized Properties / OnEnable

        SerializedProperty defaultColor;
        SerializedProperty trackedColor;
        
        SerializedProperty gizmosOnSelected;
        SerializedProperty zoomCamera;
        
        SerializedProperty refCamLookAt;
        SerializedProperty moveSpeed;
        
        SerializedProperty cameraRig;
        SerializedProperty boundsX;
        SerializedProperty boundsY;
        SerializedProperty boundsZ;
        SerializedProperty padding;
        SerializedProperty minZoom;
        SerializedProperty maxZoom;
        SerializedProperty zoomSpeed;
        
        SerializedProperty targetObjects;

        private bool gizmoGroup;

        private void OnEnable()
        {
            defaultColor = serializedObject.FindProperty("defaultColor");
            trackedColor = serializedObject.FindProperty("trackedColor");
            
            gizmosOnSelected = serializedObject.FindProperty("gizmosOnSelected");
            zoomCamera = serializedObject.FindProperty("zoomCamera");
            
            refCamLookAt = serializedObject.FindProperty("refCamLookAt");
            moveSpeed = serializedObject.FindProperty("moveSpeed");
            
            cameraRig = serializedObject.FindProperty("cameraRig");
            boundsX = serializedObject.FindProperty("boundsX");
            boundsY = serializedObject.FindProperty("boundsY");
            boundsZ = serializedObject.FindProperty("boundsZ");
            padding = serializedObject.FindProperty("padding");
            minZoom = serializedObject.FindProperty("minZoom");
            maxZoom = serializedObject.FindProperty("maxZoom");
            zoomSpeed = serializedObject.FindProperty("zoomSpeed");
            
            targetObjects = serializedObject.FindProperty("targetObjects");
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region OnInspectorGUI

        public override void OnInspectorGUI()
        {
            // get & update references
            CameraMultiTarget cameraMultiTarget = (CameraMultiTarget)target;
            serializedObject.Update();

            /*
            // draw default inspector
            base.OnInspectorGUI();
            */

            // banner
            Texture banner = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Camera Controller/Editor/Icons/inspectorBanner_CameraController.png", typeof(Texture));
            GUILayout.Box(banner, GUILayout.ExpandWidth(true), GUILayout.Height(Screen.width / 7.5f));

            // custom inspector
            gizmoGroup = EditorGUILayout.BeginFoldoutHeaderGroup(gizmoGroup, "Gizmo Settings");
            if (gizmoGroup)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(defaultColor);
                EditorGUILayout.PropertyField(trackedColor);
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
            EditorGUILayout.Space();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(gizmosOnSelected);
            EditorGUILayout.PropertyField(zoomCamera);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.PropertyField(refCamLookAt);
            EditorGUILayout.PropertyField(moveSpeed);
            if (zoomCamera.boolValue)
            {
                EditorGUILayout.PropertyField(cameraRig);
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Calculate Bounds");
                cameraMultiTarget.BoundsX = EditorGUILayout.ToggleLeft("X", cameraMultiTarget.BoundsX, GUILayout.Width(28), GUILayout.ExpandWidth(false));
                cameraMultiTarget.BoundsY = EditorGUILayout.ToggleLeft("Y", cameraMultiTarget.BoundsY, GUILayout.Width(28), GUILayout.ExpandWidth(false));
                cameraMultiTarget.BoundsZ = EditorGUILayout.ToggleLeft("Z", cameraMultiTarget.BoundsZ, GUILayout.Width(28), GUILayout.ExpandWidth(false));
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.PropertyField(padding);
                EditorGUILayout.PropertyField(minZoom);
                EditorGUILayout.PropertyField(maxZoom);
                EditorGUILayout.PropertyField(zoomSpeed);
            }
            EditorGUILayout.PropertyField(targetObjects);

            // apply reference changes
            serializedObject.ApplyModifiedProperties();
        }

        #endregion
        
    } // class end
}

#endif
