using UnityEngine;

public class VanBesturing : MonoBehaviour
{
    [Header("Motor & Snelheid")]
    public float maxSnelheid = 30f;          // Topsnelheid vooruit
    public float maxAchteruitSnelheid = 12f; // Topsnelheid achteruit
    public float optrekKracht = 18f;         // Hoe snel je accelereert met W
    public float remKracht = 30f;            // Hoe hard S remt als je vooruit rijdt
    public float uitrolVertraging = 6f;      // Hoe snel je uitrolt zonder gas

    [Header("Sturen & Handrem")]
    public float stuurSnelheid = 90f;
    public float handremKracht = 45f;        // Hoe snel SPACE je stilzet

    private Rigidbody rb;
    private float huidigeSnelheid = 0f;
    private float gasInput;
    private float stuurInput;
    private bool handremIngedrukt;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Reset elke frame eerst netjes naar 0 (geen spook-inputs meer!)
        gasInput = 0f;
        stuurInput = 0f;

        // Check puur de toetsenbord-knoppen voor gas en rem
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            gasInput = 1f;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            gasInput = -1f;
        }

        // Check puur de toetsenbord-knoppen voor sturen
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            stuurInput = 1f;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            stuurInput = -1f;
        }

        // Spatiebalk voor de handrem
        handremIngedrukt = Input.GetKey(KeyCode.Space);
    }

    void FixedUpdate()
    {
        // 1. HANDREM (SPACE)
        if (handremIngedrukt)
        {
            huidigeSnelheid = Mathf.MoveTowards(huidigeSnelheid, 0f, handremKracht * Time.fixedDeltaTime);
        }
        // 2. GAS GEVEN (W)
        else if (gasInput > 0)
        {
            huidigeSnelheid += optrekKracht * Time.fixedDeltaTime;
        }
        // 3. REMMEN OF ACHTERUIT (S)
        else if (gasInput < 0)
        {
            if (huidigeSnelheid > 0)
            {
                huidigeSnelheid -= remKracht * Time.fixedDeltaTime;
            }
            else
            {
                huidigeSnelheid -= optrekKracht * Time.fixedDeltaTime;
            }
        }
        // 4. UITROLLEN (geen W of S)
        else
        {
            huidigeSnelheid = Mathf.MoveTowards(huidigeSnelheid, 0f, uitrolVertraging * Time.fixedDeltaTime);
        }

        // Houd de snelheid binnen de limieten
        huidigeSnelheid = Mathf.Clamp(huidigeSnelheid, -maxAchteruitSnelheid, maxSnelheid);

        // Pas de beweging toe op de Rigidbody
        Vector3 voorwaarts = transform.forward * huidigeSnelheid;
        rb.linearVelocity = new Vector3(voorwaarts.x, rb.linearVelocity.y, voorwaarts.z);

        // 5. STUREN (A & D)
        if (Mathf.Abs(huidigeSnelheid) > 0.5f)
        {
            float richting = huidigeSnelheid > 0 ? 1f : -1f;
            float draai = stuurInput * stuurSnelheid * richting * Time.fixedDeltaTime;

            Quaternion nieuweRotatie = Quaternion.Euler(0f, draai, 0f);
            rb.MoveRotation(rb.rotation * nieuweRotatie);
        }
    }
}
