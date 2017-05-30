using UnityEngine;
using System.Collections;

public class SapphiArtChan_AnimManager : MonoBehaviour {

    private Animator _SapphiArtChanAnimator;                //Character Animation
	public string _SapphiArtChanAnimation = null;         //Character Animation Name
    private AnimationManagerUI _AnimationManagerUI;         //Character Animation UI Connection
    private string _SapphiArtChanLastAnimation = null;      //Character Last Animation

    private SkinnedMeshRenderer _SapphiArtChanRenderer_Face;        //Character Skin Mesh Renderer for Face
    private SkinnedMeshRenderer _SapphiArtChanRenderer_Brow;        //Character Skin Mesh Renderer for Eyebrows
    private SkinnedMeshRenderer _SapphiArtChanRenderer_BottomTeeth;        //Character Skin Mesh Renderer for Bottom Teeth
    private SkinnedMeshRenderer _SapphiArtChanRenderer_Tongue;        //Character Tongue Skinned Mesh Renderer
    private SkinnedMeshRenderer _SapphiArtChanRenderer_TopTeeth;      //Character Top Teeth Skinned Mesh Renderer

    private string _EyesLastChangeType = null;      // Character Last Facial Type Update (Eyes)
    private string _EyebrowsLastChangeType = null;  // Character Last Facial Type Update (Eyebrows)
    private string _MouthLastChangeType = null;     // Character Last Facial Type Update (Mouth)

    private float _SapphiArtChanFacial = 0.0f;    //Character Facial Parameter
    private float _SapphiArtChanLastFacial = 0.0f;    //Character Last Facial Parameter
    private bool _SapphiArtChanFacialBool = false;    //Character Facial Parameter Bool
    private bool _SapphiArtChanLastFacialBool = false;    //Character Last Facial Parameter Bool
    //BlendShapeValues
    private float _SapphiArtChanFacial_Eye_L_Happy = 0.0f;
    private float _SapphiArtChanFacial_Eye_R_Happy = 0.0f;
    private float _SapphiArtChanFacial_Eye_L_Closed = 0.0f;
    private float _SapphiArtChanFacial_Eye_R_Closed = 0.0f;
    private float _SapphiArtChanFacial_Eye_L_Wide = 0.0f;
    private float _SapphiArtChanFacial_Eye_R_Wide = 0.0f;

    private float _SapphiArtChanFacial_Mouth_Sad = 0.0f;
    private float _SapphiArtChanFacial_Mouth_Puff = 0.0f;
    private float _SapphiArtChanFacial_Mouth_Smile = 0.0f;

    private float _SapphiArtChanFacial_Eyebrow_L_Up = 0.0f;
    private float _SapphiArtChanFacial_Eyebrow_R_Up = 0.0f;
    private float _SapphiArtChanFacial_Eyebrow_L_Angry = 0.0f;
    private float _SapphiArtChanFacial_Eyebrow_R_Angry = 0.0f;
    private float _SapphiArtChanFacial_Eyebrow_L_Sad = 0.0f;
    private float _SapphiArtChanFacial_Eyebrow_R_Sad = 0.0f;

    private float _SapphiArtChanFacial_Mouth_E = 0.0f;
    private float _SapphiArtChanFacial_Mouth_O = 0.0f;
    private float _SapphiArtChanFacial_Mouth_JawOpen = 0.0f;
    private float _SapphiArtChanFacial_Mouth_Extra01 = 0.0f;
    private float _SapphiArtChanFacial_Mouth_Extra02 = 0.0f;
    private float _SapphiArtChanFacial_Mouth_Extra03 = 0.0f;
    private float _SapphiArtChanFacial_Mouth_BottomTeeth = 0.0f;

    private bool _SapphiArtChanFacial_Mouth_TopTeeth = false;
    private bool _SapphiArtChanFacial_Mouth_Tongue = false;

	public ChanTouchMove moveFlag;

    void Start()
    {
		moveFlag = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<ChanTouchMove> ();
        _SapphiArtChanAnimator = this.gameObject.GetComponent<Animator>();
        _AnimationManagerUI = GameObject.Find("AnimationManagerUI").GetComponent<AnimationManagerUI>();

        Transform[] SapphiArtchanChildren = GetComponentsInChildren<Transform>();

        foreach (Transform t in SapphiArtchanChildren)
        {
            if (t.name == "face")
                _SapphiArtChanRenderer_Face = t.gameObject.GetComponent<SkinnedMeshRenderer>();
            if (t.name == "brow")
                _SapphiArtChanRenderer_Brow = t.gameObject.GetComponent<SkinnedMeshRenderer>();
            if (t.name == "BottomTeeth")
                _SapphiArtChanRenderer_BottomTeeth = t.gameObject.GetComponent<SkinnedMeshRenderer>();
            if (t.name == "tongue")
                _SapphiArtChanRenderer_Tongue = t.gameObject.GetComponent<SkinnedMeshRenderer>();
            if (t.name == "TopTeeth")
                _SapphiArtChanRenderer_TopTeeth = t.gameObject.GetComponent<SkinnedMeshRenderer>();
        }
        _SapphiArtChanRenderer_Tongue.enabled = false;
        _SapphiArtChanRenderer_TopTeeth.enabled = false;
    }


    void GetAnimation()
    {
        //Record Last Animation
        _SapphiArtChanLastAnimation = _SapphiArtChanAnimation;

		if (_SapphiArtChanAnimation == null)
            _SapphiArtChanAnimation = "idle";
		else 
        {
            //Set Animation Parameter
            _SapphiArtChanAnimation = _AnimationManagerUI._Animation;
            //_SapphiArtChanAnimation = "hit01";
        }
    }

    void SetAllAnimationFlagsToFalse()
    {
        _SapphiArtChanAnimator.SetBool("param_idletowalk", false);
        _SapphiArtChanAnimator.SetBool("param_idletorunning", false);
        _SapphiArtChanAnimator.SetBool("param_idletojump", false);
        _SapphiArtChanAnimator.SetBool("param_idletowinpose", false);
        _SapphiArtChanAnimator.SetBool("param_idletoko_big", false);
        _SapphiArtChanAnimator.SetBool("param_idletodamage", false);
        _SapphiArtChanAnimator.SetBool("param_idletohit01", false);
        _SapphiArtChanAnimator.SetBool("param_idletohit02", false);
        _SapphiArtChanAnimator.SetBool("param_idletohit03", false);
    }


    void SetAnimation()
    {
        SetAllAnimationFlagsToFalse();
		if (moveFlag.flag == 1) {
			_SapphiArtChanAnimation = "walk";
			_AnimationManagerUI._Animation="idle";
		}
        //IDLE
		if (_SapphiArtChanAnimation == "idle")
        {
            _SapphiArtChanAnimator.SetBool("param_toidle", true);
        }

        //WALK
		else if (_SapphiArtChanAnimation == "walk")
        {
			//_SapphiArtChanAnimator.SetBool("param_toidle", false);
            _SapphiArtChanAnimator.SetBool("param_idletowalk", true);
        }

        //RUN
        else if (_SapphiArtChanAnimation == "running")
        {
            _SapphiArtChanAnimator.SetBool("param_idletorunning", true);
        }

        //JUMP
        else if (_SapphiArtChanAnimation == "jump")
        {
            _SapphiArtChanAnimator.SetBool("param_idletojump", true);
        }

        //WIN POSE
        else if (_SapphiArtChanAnimation == "winpose")
        {
            _SapphiArtChanAnimator.SetBool("param_idletowinpose", true);
        }

        //KO
        else if (_SapphiArtChanAnimation == "ko_big")
        {
			//_SapphiArtChanAnimator.SetBool("param_toidle", false);
            _SapphiArtChanAnimator.SetBool("param_idletoko_big", true);

        }

        //DAMAGE
        else if (_SapphiArtChanAnimation == "damage")
        {
            _SapphiArtChanAnimator.SetBool("param_idletodamage", true);
        }

        //HIT 1
        else if (_SapphiArtChanAnimation == "hit01")
        {
            _SapphiArtChanAnimator.SetBool("param_idletohit01", true);
        }

        //HIT 2
        else if (_SapphiArtChanAnimation == "hit02")
        {
            _SapphiArtChanAnimator.SetBool("param_idletohit02", true);
        }

        //HIT 3
        else if (_SapphiArtChanAnimation == "hit03")
        {
            _SapphiArtChanAnimator.SetBool("param_idletohit03", true);
        }
	 
    }

    void ReturnToIdle()
    {
        if (_SapphiArtChanAnimator.GetCurrentAnimatorStateInfo(0).IsName(_SapphiArtChanAnimation))
        {
            if (
				moveFlag.flag!=1&&
				_SapphiArtChanAnimation != "idle"
                )
            {
                SetAllAnimationFlagsToFalse();
				_SapphiArtChanAnimation = null;
                _SapphiArtChanAnimator.SetBool("param_toidle", true);

            }
        }
    }


   


    void Update ()
    {
		
        //Get Animation from UI
        GetAnimation();
        
        //Set New Animation
        //if (_SapphiArtChanLastAnimation != _SapphiArtChanAnimation)
		     SetAnimation();
		if (_SapphiArtChanLastAnimation == _SapphiArtChanAnimation)
        {
            ReturnToIdle();
        }
    }

    void LateUpdate()
    {
        //Set Facial

		Debug.Log("Nothing");
    }
}
