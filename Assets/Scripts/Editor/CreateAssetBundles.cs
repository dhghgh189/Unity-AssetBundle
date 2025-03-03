using System.IO;
using UnityEditor;

public class CreateAssetBundles
{
    [MenuItem("Custom Tools/Build AssetBundles")]
    public static void Build()
    {
        string directory = "./Bundle";

        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        BuildPipeline.BuildAssetBundles(directory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

        EditorUtility.DisplayDialog("Build Asset Bundle", "에셋 번들 빌드 완료", "닫기");
    }
}