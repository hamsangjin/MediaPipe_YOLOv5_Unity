using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using UnityEngine.XR;
using System.Security.Cryptography;

public class HumanBodyBone : MonoBehaviour
{
    private static int avatarID = 0;
    public const int NUM_JOINT = 16;
    public Animator animator;
    public Transform[] humanJoint = new Transform[NUM_JOINT];
    private List<Vector3> pose;
    private List<Vector3> left;
    private List<Vector3> right;
    private int ID;

    HumanBodyBone()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        ID = avatarID;
        avatarID++;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ID);
    }

    // 모든 Update함수가 호출된 뒤 호출
    void LateUpdate()
    {
        pose = new List<Vector3>(DataReceiver.Instance.getPose(ID));
        left = new List<Vector3>(DataReceiver.Instance.getLeft(ID));
        right = new List<Vector3>(DataReceiver.Instance.getRight(ID));

        SetBoneTransform();
    }

    private void SetBoneTransform()
    {
        SetShoulder();
        SetArm();
        setHead();

        SetHip();
        SetLeg();
        SetFoot();

        SetHand();
    }

#region UpperBoddy
    private void SetShoulder()
    {
        // 다른건 lookRotation으로 변경해야 할 수 도 있지만 어깨부분은 FromToRotation으로 충분해 보인다.
        animator.GetBoneTransform(HumanBodyBones.UpperChest).rotation = Quaternion.FromToRotation(Vector3.right, pose[11] - pose[12]);
    }
    private void SetArm()
    {
        Vector3 leftUp = pose[14] - pose[12];
        Vector3 leftRight = Vector3.Cross(leftUp, pose[16] - pose[12]);
        Vector3 leftForward = Vector3.Cross(leftUp, leftRight);
        animator.GetBoneTransform(HumanBodyBones.LeftUpperArm).rotation = Quaternion.LookRotation(leftForward, leftUp);

        leftUp = pose[16] - pose[14];
        leftForward = Vector3.Cross(pose[20] - pose[16], pose[18] - pose[16]);
        animator.GetBoneTransform(HumanBodyBones.LeftLowerArm).rotation = Quaternion.LookRotation(leftForward, leftUp);


        Vector3 rightUp = pose[13] - pose[11];
        Vector3 rightRight = Vector3.Cross(rightUp, pose[15] - pose[11]);
        Vector3 rightForward = Vector3.Cross(rightUp, rightRight);
        //Vector3 rightForward = Vector3.Cross(rightRight, rightUp);
        animator.GetBoneTransform(HumanBodyBones.RightUpperArm).rotation = Quaternion.LookRotation(rightForward, rightUp);

        rightUp = pose[15] - pose[13];
        rightForward = Vector3.Cross(pose[17] - pose[15], pose[19] - pose[15]); // 손바닥면
        animator.GetBoneTransform(HumanBodyBones.RightLowerArm).rotation = Quaternion.LookRotation(rightForward, rightUp);
    }
    private void setHead()
    {
        //animator.GetBoneTransform(HumanBodyBones.Head).rotation = Quaternion.FromToRotation(Vector3.right, pose[9] - pose[10]);
        animator.GetBoneTransform(HumanBodyBones.Head).rotation = Quaternion.AngleAxis(Mathf.Asin((pose[7].x - pose[8].x) / (pose[7].x - pose[0].x)), Vector3.up);
    }
    #endregion

    private void SetLeg()
    {
        Vector3 leftUp = pose[26] - pose[24];
        Vector3 leftRight = Vector3.Cross(leftUp, pose[28] - pose[24]);
        Vector3 leftForward = Vector3.Cross(leftUp, leftRight);
        //animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg).rotation = Quaternion.FromToRotation(Vector3.up, pose[26] - pose[24]);
        animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg).rotation = Quaternion.LookRotation(leftForward, leftUp);

        leftUp = pose[28] - pose[26];
        leftForward = Vector3.Cross(leftUp, leftRight);
        //animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg).rotation = Quaternion.FromToRotation(Vector3.up, pose[28] - pose[26]);
        animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg).rotation = Quaternion.LookRotation(leftForward, leftUp);


        Vector3 rightUp = pose[25] - pose[23];
        Vector3 rightRight = Vector3.Cross(rightUp, pose[27] - pose[23]);
        Vector3 rightForward = Vector3.Cross(rightUp, rightRight);
        //animator.GetBoneTransform(HumanBodyBones.RightUpperLeg).rotation = Quaternion.FromToRotation(Vector3.up, pose[25] - pose[23]);
        animator.GetBoneTransform(HumanBodyBones.RightUpperLeg).rotation = Quaternion.LookRotation(rightForward, rightUp);

        rightUp = pose[27] - pose[25];
        rightForward = Vector3.Cross(rightUp, rightRight);
        //animator.GetBoneTransform(HumanBodyBones.RightLowerLeg).rotation = Quaternion.FromToRotation(Vector3.up, pose[27] - pose[25]);
        animator.GetBoneTransform(HumanBodyBones.RightLowerLeg).rotation = Quaternion.LookRotation(rightForward, rightUp);
    }
    private void SetHip()
    {
        animator.GetBoneTransform(HumanBodyBones.Hips).rotation = Quaternion.FromToRotation(Vector3.right, pose[23] - pose[24]);
    }
    private void SetFoot() 
    {
        Vector3 leftUp = pose[32] - pose[28];
        Vector3 leftRight = Vector3.Cross(leftUp, pose[30] - pose[28]);
        Vector3 leftForward = Vector3.Cross(leftUp, leftRight);
        animator.GetBoneTransform(HumanBodyBones.LeftFoot).rotation = Quaternion.LookRotation(leftForward, leftUp); // 32 30 28

        Vector3 rightUp = pose[31] - pose[27];
        Vector3 rightRight = Vector3.Cross(rightUp, pose[29] - pose[27]);
        Vector3 rightForward = Vector3.Cross(rightUp, rightRight);
        animator.GetBoneTransform(HumanBodyBones.RightFoot).rotation = Quaternion.LookRotation(rightForward, rightUp); // 31 29 27
    }

    private void SetHand() 
    {
        SetLeftHand();
        SetRightHand();
    }
    
    private void SetLeftHand() // 아바타의 왼손
    {
        Vector3 leftUp = pose[16] - pose[14];
        Vector3 leftForward = Vector3.Cross(pose[20] - pose[16], pose[18] - pose[16]);
        Debug.Log(right.Count);
        if (right.Count < 1)
            return;

        Vector3 palmNormal = -Vector3.Cross(right[17] - right[0], right[5] - right[0]);
        Vector3 fingerUp;

        // 진짜 머리아프지만 왼손이 오른손이고 오른쪽이 왼쪽인 그런 상황
        animator.GetBoneTransform(HumanBodyBones.LeftHand).rotation = Quaternion.LookRotation(palmNormal, right[9] - right[0]);

        //fingerUp = right[1] - right[0] + animator.GetBoneTransform(HumanBodyBones.LeftHand).position; // position 값은 왜 더하는거임? 안하면 이상하게 나오긴하는데
        animator.GetBoneTransform(HumanBodyBones.LeftThumbProximal).rotation = Quaternion.FromToRotation(Vector3.up, right[2] - right[1]);
        animator.GetBoneTransform(HumanBodyBones.LeftThumbIntermediate).rotation = Quaternion.FromToRotation(Vector3.up, right[3] - right[2]);
        animator.GetBoneTransform(HumanBodyBones.LeftThumbDistal).rotation = Quaternion.FromToRotation(Vector3.up, right[4] - right[3]);

        //fingerUp = right[5] - right[0] + animator.GetBoneTransform(HumanBodyBones.LeftHand).position;
        animator.GetBoneTransform(HumanBodyBones.LeftIndexProximal).rotation = Quaternion.FromToRotation(Vector3.up, right[6] - right[5]);
        animator.GetBoneTransform(HumanBodyBones.LeftIndexIntermediate).rotation = Quaternion.FromToRotation(Vector3.up, right[7] - right[6]);
        animator.GetBoneTransform(HumanBodyBones.LeftIndexDistal).rotation = Quaternion.FromToRotation(Vector3.up, right[8] - right[7]);

        //fingerUp = right[9] - right[0] + animator.GetBoneTransform(HumanBodyBones.LeftHand).position;
        animator.GetBoneTransform(HumanBodyBones.LeftMiddleProximal).rotation = Quaternion.FromToRotation(Vector3.up, right[10] - right[9]);
        animator.GetBoneTransform(HumanBodyBones.LeftMiddleIntermediate).rotation = Quaternion.FromToRotation(Vector3.up, right[11] - right[10]);
        animator.GetBoneTransform(HumanBodyBones.LeftMiddleDistal).rotation = Quaternion.FromToRotation(Vector3.up, right[12] - right[11]);

        //fingerUp = right[13] - right[0] + animator.GetBoneTransform(HumanBodyBones.LeftHand).position;
        animator.GetBoneTransform(HumanBodyBones.LeftRingProximal).rotation = Quaternion.FromToRotation(Vector3.up, right[14] - right[13]);
        animator.GetBoneTransform(HumanBodyBones.LeftRingIntermediate).rotation = Quaternion.FromToRotation(Vector3.up, right[15] - right[14]);
        animator.GetBoneTransform(HumanBodyBones.LeftRingDistal).rotation = Quaternion.FromToRotation(Vector3.up, right[16] - right[15]);

        //fingerUp = right[17] - right[0] + animator.GetBoneTransform(HumanBodyBones.LeftHand).position;
        animator.GetBoneTransform(HumanBodyBones.LeftLittleProximal).rotation = Quaternion.FromToRotation(Vector3.up, right[18] - right[17]);
        animator.GetBoneTransform(HumanBodyBones.LeftLittleIntermediate).rotation = Quaternion.FromToRotation(Vector3.up, right[19] - right[18]);
        animator.GetBoneTransform(HumanBodyBones.LeftLittleDistal).rotation = Quaternion.FromToRotation(Vector3.up, right[20] - right[19]);
    }
    private void SetRightHand()
    {

        Debug.Log(left.Count);
        if (left.Count < 1)
            return;

        Vector3 palmNormal = Vector3.Cross(left[17] - left[0], left[5] - left[0]);
        Vector3 fingerUp;

        animator.GetBoneTransform(HumanBodyBones.RightHand).rotation = Quaternion.LookRotation(palmNormal, left[9] - left[0]);

        // 엄지손가락이 손등으로 접힘
        fingerUp = left[1] - left[0] + animator.GetBoneTransform(HumanBodyBones.LeftHand).position; 
        animator.GetBoneTransform(HumanBodyBones.RightThumbProximal).rotation = Quaternion.FromToRotation(fingerUp, left[2] - left[1]);
        animator.GetBoneTransform(HumanBodyBones.RightThumbIntermediate).rotation = Quaternion.FromToRotation(fingerUp, left[3] - left[2]);
        animator.GetBoneTransform(HumanBodyBones.RightThumbDistal).rotation = Quaternion.FromToRotation(fingerUp, left[4] - left[3]);

        fingerUp = left[5] - left[0] + animator.GetBoneTransform(HumanBodyBones.LeftHand).position;
        animator.GetBoneTransform(HumanBodyBones.RightIndexProximal).rotation = Quaternion.FromToRotation(fingerUp, left[6] - left[5]);
        animator.GetBoneTransform(HumanBodyBones.RightIndexIntermediate).rotation = Quaternion.FromToRotation(fingerUp, left[7] - left[6]);
        animator.GetBoneTransform(HumanBodyBones.RightIndexDistal).rotation = Quaternion.FromToRotation(fingerUp, left[8] - left[7]);

        fingerUp = left[9] - left[0] + animator.GetBoneTransform(HumanBodyBones.LeftHand).position;
        animator.GetBoneTransform(HumanBodyBones.RightMiddleProximal).rotation = Quaternion.FromToRotation(fingerUp, left[10] - left[9]);
        animator.GetBoneTransform(HumanBodyBones.RightMiddleIntermediate).rotation = Quaternion.FromToRotation(fingerUp, left[11] - left[10]);
        animator.GetBoneTransform(HumanBodyBones.RightMiddleDistal).rotation = Quaternion.FromToRotation(fingerUp, left[12] - left[11]);

        fingerUp = left[13] - left[0] + animator.GetBoneTransform(HumanBodyBones.LeftHand).position;
        animator.GetBoneTransform(HumanBodyBones.RightRingProximal).rotation = Quaternion.FromToRotation(fingerUp, left[14] - left[13]);
        animator.GetBoneTransform(HumanBodyBones.RightRingIntermediate).rotation = Quaternion.FromToRotation(fingerUp, left[15] - left[14]);
        animator.GetBoneTransform(HumanBodyBones.RightRingDistal).rotation = Quaternion.FromToRotation(fingerUp, left[16] - left[15]);

        fingerUp = left[17] - left[0] + animator.GetBoneTransform(HumanBodyBones.LeftHand).position;
        animator.GetBoneTransform(HumanBodyBones.RightLittleProximal).rotation = Quaternion.FromToRotation(fingerUp, left[18] - left[17]);
        animator.GetBoneTransform(HumanBodyBones.RightLittleIntermediate).rotation = Quaternion.FromToRotation(fingerUp, left[19] - left[18]);
        animator.GetBoneTransform(HumanBodyBones.RightLittleDistal).rotation = Quaternion.FromToRotation(fingerUp, left[20] - left[19]);
    }
}