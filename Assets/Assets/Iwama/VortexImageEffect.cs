using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexImageEffect : MonoBehaviour
{


    public Vector2 radius = new Vector2(0.3F, 0.3F);
    public float angle = 0;
    public Vector2 center = new Vector2(0.5F, 0.5F);

    public Shader curShader;
    private Material curMaterial;

   //public GameObject MainCamera;
    float time;
    float rotate = 200;

    private void Start()
    {
        time = 0f;
    }

    Material material
    {
        get
        {
            if (curMaterial == null)
            {
                curMaterial = new Material(curShader);
                curMaterial.hideFlags = HideFlags.HideAndDontSave;
            }
            return curMaterial;
        }
    }

    //素材が使用不可または非アクティブになったら、呼び出して素材を削除
    void OnDisable()
    {
        if (curMaterial)
        {
            DestroyImmediate(curMaterial);
        }
    }

    //この関数は、すべてのレンダリング イメージが終了した後に呼び出され、イメージのポスト エフェクトをレンダリングするために使用されます。
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //さまざまなプラットフォームへの対応
        bool invertY = source.texelSize.y < 0.0f;
        if (invertY)
        {
            center.y = 1.0f - center.y;
            angle = -angle;
        }


        angle += Time.deltaTime * rotate*2.0f;

        if (curShader != null)//回転させる
        {
            Matrix4x4 rotationMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, angle), Vector3.one);

            //シェーダーの外部変数を設定する
            material.SetMatrix("_RotationMatrix", rotationMatrix);
            material.SetVector("_CenterRadius", new Vector4(center.x, center.y, radius.x, radius.y));
            material.SetFloat("_Angle", angle * Mathf.Deg2Rad);
            
            //ソース テクスチャとマテリアル エフェクトをターゲット テクスチャにコピーする
            Graphics.Blit(source, destination, material);

        }
        else
        {
            //特殊効果なしでソース テクスチャをターゲット テクスチャに直接コピーする
            Graphics.Blit(source, destination);
        }

    }

    void Update()

    {
        time += Time.deltaTime;
       // Debug.Log(time);

        if (time > 3) //反対に回転させる 
        {
           //this.GetComponent<VortexImageEffect>().enabled = false;
            rotate = -200;
         
        }
        if (time > 6.005)
        {
         this.GetComponent<VortexImageEffect>().enabled = false;
        }
    }
    //rotationMatrix 回転行列　angle 角度
}

