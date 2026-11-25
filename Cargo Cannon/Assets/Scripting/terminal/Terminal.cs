using UnityEngine;

public class InteractableUI : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;          
    [SerializeField] private GameObject promptUI;         
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private bool closeWithSameKey = true;

    private bool playerInRange;

    private void Start()
    {
        if (uiPanel != null) uiPanel.SetActive(false);
        if (promptUI != null) promptUI.SetActive(false);
    }

    private void Update()
    {
        if (!playerInRange || !Input.GetKeyDown(interactKey)) return;

        if (uiPanel.activeSelf)
        {
            if (closeWithSameKey) CloseUI();
        }
        else
        {
            OpenUI();
        }
    }

    public void OpenUI()
    {
        uiPanel.SetActive(true);
        if (promptUI != null) promptUI.SetActive(false);
    }

    public void CloseUI()
    {
        uiPanel.SetActive(false);
        if (promptUI != null && playerInRange) promptUI.SetActive(true);
    }

    public void SetInRange(bool inRange)
    {
        playerInRange = inRange;
        if (promptUI != null) promptUI.SetActive(inRange && !uiPanel.activeSelf);
        if (!inRange) uiPanel.SetActive(false);
    }
}
