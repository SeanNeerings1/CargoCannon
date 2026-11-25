using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;          
    [SerializeField] private GameObject promptUI;         
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private bool closeWithSameKey = true;

    private bool playerInRange;
    private bool isOpen;

    private void Start()
    {
        if (uiPanel != null) uiPanel.SetActive(false);
        if (promptUI != null) promptUI.SetActive(false);
    }

    private void Update()
    {
        if (isOpen && !uiPanel.activeSelf) CloseUI();


        if (uiPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseUI();
            return;
        }

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
        isOpen = true;

        uiPanel.SetActive(true);
        if (promptUI != null) promptUI.SetActive(false);

        MouseLook.uiOpen = true;                 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseUI()
    {
        isOpen = false;
        uiPanel.SetActive(false);
        if (promptUI != null && playerInRange) promptUI.SetActive(true);

        MouseLook.uiOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SetInRange(bool inRange)
    {
        playerInRange = inRange;
        if (promptUI != null) promptUI.SetActive(inRange && !uiPanel.activeSelf);
        if (!inRange && uiPanel.activeSelf) CloseUI();
    }
}
