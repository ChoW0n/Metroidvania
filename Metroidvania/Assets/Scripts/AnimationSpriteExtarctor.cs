using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpriteInfo
{
    public float time;      //���������Ͱ� ���Ǵ� �ð�
    public string spriteName; //��������Ʈ �̸�
}

public class AnimationSpriteExtarctor : EditorWindow    
{
    private AnimationClip animationClip;            //���õ� �ִϸ��̼� Ŭ��
    private List<SpriteInfo> spriteInfoList = new List<SpriteInfo>();   //��������Ʈ ������ ������ ����Ʈ
    
    [MenuItem("Window/Animation Sprite Extractor")]
    public static void ShowWindow()
    {
        GetWindow<AnimationSpriteExtarctor>("Animation Sprite Extractor");      //������ â ����
    }

    private void OnGUI()
    {
        GUILayout.Label("Extract Sprites Info form Animation Clip", EditorStyles.boldLabel);    //������ â�� ���̺�� �ִϸ��̼� Ŭ�� �ʵ� ǥ��

        //����ڰ� �巡�� �� ������� �ִϸ��̼� Ŭ���� ������ �� �ְ� ����
        animationClip = EditorGUILayout.ObjectField("Animation Clip", animationClip, typeof(AnimationClip), true) as AnimationClip;
        
        if (animationClip != null)  //�ִϸ��̼� Ŭ���� ������ ���
        {
            if(GUILayout.Button("Extract Sprites Info"))        //��ư�� Ŭ���Ǹ� ��������Ʈ ������ ����
                ExtractSpritesInfo(animationClip);
        }

        if (spriteInfoList.Count > 0)
        {
            GUILayout.Label("Sprite Info : ", EditorStyles.boldLabel);
            foreach (var spriteInfo in spriteInfoList)
            {
                GUILayout.BeginHorizontal(); //���� ���̾ƿ� �ð�
                GUILayout.Label("Time:", GUILayout.Width(50));  //time ���̺�
                GUILayout.Label(spriteInfo.time.ToString(), GUILayout.Width(100)); //�ð� ��
                GUILayout.Label("Sprite : ", GUILayout.Width(50));  //Sprite ���̺�
                GUILayout.Label(spriteInfo.spriteName, GUILayout.Width(100));   //��������Ʈ �̸�
                GUILayout.EndHorizontal(); //���� ���̾ƿ� ����
            }
        }
    }
    
    private void ExtractSpritesInfo(AnimationClip Clip) //��������Ʈ ������ �����ϴ� �Լ�
    {
        spriteInfoList.Clear(); //���� ��������Ʈ ���� �ʱ�ȭ
        var bindings = AnimationUtility.GetObjectReferenceCurveBindings(Clip);  //�ִϸ��̼� Ŭ������ Object Refrence Curve ���ε��� ������

        foreach (var binding in bindings)    //�� ���ε��� ��ȸ
        {
            if (binding.propertyName.Contains("Sprite")) //���ε��� ������Ƽ�� ��������Ʈ�� ���
            {
                var keyframes = AnimationUtility.GetObjectReferenceCurve(Clip, binding);    //�ش� ���ε��� Ű�������� ������

                foreach (var keyframe in keyframes)  //���� Ű�������� ��ȸ
                {
                    Sprite sprite = keyframe.value as Sprite;   //Ű������ ���� ��������Ʈ�� ĳ����
                    if (sprite != null)
                    {
                        spriteInfoList.Add(new SpriteInfo { time = keyframe.time, spriteName = sprite.name }); //��������Ʈ ������ ����Ʈ�� �߰�
                    }
                }
            }
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
