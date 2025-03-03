using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BundleLoader : MonoBehaviour
{
    IEnumerator Start()
    {
        AssetBundle bundle = AssetBundle.LoadFromFile("Bundle/player");
        if (bundle == null)
        {
            Debug.Log("Failed load Bundle");
            yield break;
        }

        var player1 = bundle.LoadAsset<GameObject>("RPGHeroHP");
        var player2 = bundle.LoadAsset<GameObject>("RPGHeroPBR");
        
        var instance1 = Instantiate(player1);
        var instance2 = Instantiate(player2);
        
        instance1.transform.position = new Vector3(-2f, 0f, 0.5f);
        instance1.transform.Rotate(new Vector3(0f, 180f, 0f));

        instance2.transform.position = new Vector3(2f, 0f, 0.5f);
        instance2.transform.Rotate(new Vector3(0f, 180f, 0f));

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        // 번들을 메모리에서 해제
        // true 입력 시 씬에서 사용중인 에셋을 포함해 모든 에셋이 즉시 언로드된다.
        bundle.Unload(true);
        Debug.Log("Unload Complete");
    }
}
