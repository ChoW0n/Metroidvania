using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpriteInfo
{
    public float time;      //스프라이터가 사용되는 시간
    public string spriteName; //스프라이트 이름
}

public class AnimationSpriteExtarctor : EditorWindow    
{
    private AnimationClip animationClip;            //선택된 애니메이션 클립
    private List<SpriteInfo> spriteInfoList = new List<SpriteInfo>();   //스프라이트 정보를 저장할 리스트
    
    [MenuItem("Window/Animation Sprite Extractor")]
    public static void ShowWindow()
    {
        GetWindow<AnimationSpriteExtarctor>("Animation Sprite Extractor");      //에디터 창 열기
    }

    private void OnGUI()
    {
        GUILayout.Label("Extract Sprites Info form Animation Clip", EditorStyles.boldLabel);    //에디터 창에 레이블과 애니메이션 클립 필드 표시

        //사용자가 드래그 앤 드롭으로 애니메이션 클립을 설정할 수 있게 해줌
        animationClip = EditorGUILayout.ObjectField("Animation Clip", animationClip, typeof(AnimationClip), true) as AnimationClip;
        
        if (animationClip != null)  //애니메이션 클립이 설정된 경우
        {
            if(GUILayout.Button("Extract Sprites Info"))        //버튼이 클릭되면 스프라이트 정보를 추출
                ExtractSpritesInfo(animationClip);
        }

        if (spriteInfoList.Count > 0)
        {
            GUILayout.Label("Sprite Info : ", EditorStyles.boldLabel);
            foreach (var spriteInfo in spriteInfoList)
            {
                GUILayout.BeginHorizontal(); //수평 레이아웃 시각
                GUILayout.Label("Time:", GUILayout.Width(50));  //time 레이블
                GUILayout.Label(spriteInfo.time.ToString(), GUILayout.Width(100)); //시간 값
                GUILayout.Label("Sprite : ", GUILayout.Width(50));  //Sprite 레이블
                GUILayout.Label(spriteInfo.spriteName, GUILayout.Width(100));   //스프라이트 이름
                GUILayout.EndHorizontal(); //수평 레이아웃 종료
            }
        }
    }
    
    private void ExtractSpritesInfo(AnimationClip Clip) //스프라이트 정보를 추출하는 함수
    {
        spriteInfoList.Clear(); //기존 스프라이트 정보 초기화
        var bindings = AnimationUtility.GetObjectReferenceCurveBindings(Clip);  //애니메이션 클립에서 Object Refrence Curve 바인딩을 가져옴

        foreach (var binding in bindings)    //각 바인딩을 순회
        {
            if (binding.propertyName.Contains("Sprite")) //바인딩된 프로페티가 스프라이트일 경우
            {
                var keyframes = AnimationUtility.GetObjectReferenceCurve(Clip, binding);    //해당 바인딩의 키프레임을 가져옴

                foreach (var keyframe in keyframes)  //각각 키프레임을 순회
                {
                    Sprite sprite = keyframe.value as Sprite;   //키프레임 같은 스프라이트로 캐스팅
                    if (sprite != null)
                    {
                        spriteInfoList.Add(new SpriteInfo { time = keyframe.time, spriteName = sprite.name }); //스프라이트 정보를 리스트에 추가
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
