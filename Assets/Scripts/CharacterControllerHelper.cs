using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CharacterControllerHelper : MonoBehaviour
{
    private XRRig XRRig;
    private CharacterController CharacterController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharacterController();
    }

        protected virtual void UpdateCharacterController()
        {
            if (xRRig == null || m_CharacterController == null)
                return;

            var height = Mathf.Clamp(xRRig.cameraInRigSpaceHeight, m_MinHeight, m_MaxHeight);

            Vector3 center = xRRig.cameraInRigSpacePos;
            center.y = height / 2f + m_CharacterController.skinWidth;

            m_CharacterController.height = height;
            m_CharacterController.center = center;
        }
}
