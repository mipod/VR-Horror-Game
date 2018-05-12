using UnityEditor;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [CustomEditor(typeof(ColorCorrectionLookup))]
    internal class ColorCorrectionLookupEditor : Editor
    {
        private SerializedObject serObj;

        private Texture2D tempClutTex2D;

        private void OnEnable()
        {
            serObj = new SerializedObject(target);
        }


        public override void OnInspectorGUI()
        {
            serObj.Update();

            EditorGUILayout.LabelField("Converts textures into color lookup volumes (for grading)",
                EditorStyles.miniLabel);

            //EditorGUILayout.LabelField("Change Lookup Texture (LUT):");
            //EditorGUILayout.BeginHorizontal ();
            //Rect r = GUILayoutUtility.GetAspectRect(1.0ff);

            Rect r;
            Texture2D t;

            //EditorGUILayout.Space();
            tempClutTex2D =
                EditorGUILayout.ObjectField(" Based on", tempClutTex2D, typeof(Texture2D), false) as Texture2D;
            if (tempClutTex2D == null)
            {
                t = AssetDatabase.LoadMainAssetAtPath(((ColorCorrectionLookup) target).basedOnTempTex) as Texture2D;
                if (t) tempClutTex2D = t;
            }

            var tex = tempClutTex2D;

            if (tex && (target as ColorCorrectionLookup).basedOnTempTex != AssetDatabase.GetAssetPath(tex))
            {
                EditorGUILayout.Separator();
                if (!(target as ColorCorrectionLookup).ValidDimensions(tex))
                {
                    EditorGUILayout.HelpBox(
                        "Invalid texture dimensions!\nPick another texture or adjust dimension to e.g. 256x16.",
                        MessageType.Warning);
                }
                else if (GUILayout.Button("Convert and Apply"))
                {
                    var path = AssetDatabase.GetAssetPath(tex);
                    var textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
                    var doImport = textureImporter.isReadable == false;
                    if (textureImporter.mipmapEnabled) doImport = true;
                    if (textureImporter.textureFormat != TextureImporterFormat.AutomaticTruecolor) doImport = true;

                    if (doImport)
                    {
                        textureImporter.isReadable = true;
                        textureImporter.mipmapEnabled = false;
                        textureImporter.textureFormat = TextureImporterFormat.AutomaticTruecolor;
                        AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
                        //tex = AssetDatabase.LoadMainAssetAtPath(path);
                    }

                    (target as ColorCorrectionLookup).Convert(tex, path);
                }
            }

            if ((target as ColorCorrectionLookup).basedOnTempTex != "")
            {
                EditorGUILayout.HelpBox("Using " + (target as ColorCorrectionLookup).basedOnTempTex, MessageType.Info);
                t = AssetDatabase.LoadMainAssetAtPath(((ColorCorrectionLookup) target).basedOnTempTex) as Texture2D;
                if (t)
                {
                    r = GUILayoutUtility.GetLastRect();
                    r = GUILayoutUtility.GetRect(r.width, 20);
                    r.x += r.width * 0.05f / 2.0f;
                    r.width *= 0.95f;
                    GUI.DrawTexture(r, t);
                    GUILayoutUtility.GetRect(r.width, 4);
                }
            }

            //EditorGUILayout.EndHorizontal ();

            serObj.ApplyModifiedProperties();
        }
    }
}