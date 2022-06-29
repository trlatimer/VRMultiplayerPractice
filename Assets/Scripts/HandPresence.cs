using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandPresence : MonoBehaviour
{
    public GameObject handModelPrefab;
    public ActionBasedController targetDevice;

    private GameObject spawnedHandModel;
    private Animator handAnimator;

    void Start()
    {
        spawnedHandModel = Instantiate(handModelPrefab, transform);
        handAnimator = spawnedHandModel.GetComponent<Animator>();
    }

    private void UpdateHandAnimation()
    {
        handAnimator.SetFloat("Trigger", targetDevice.activateAction.action.ReadValue<float>());
        handAnimator.SetFloat("Grip", targetDevice.selectAction.action.ReadValue<float>());
    }

    void Update()
    {
        spawnedHandModel.SetActive(true);
        UpdateHandAnimation();   
    }
}
