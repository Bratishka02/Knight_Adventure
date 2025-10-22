using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private static readonly int Die = Animator.StringToHash(IsDie);
    private static readonly int Running = Animator.StringToHash(IsRunning);
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private FlashBlink _flashBlink;

    private const string IsRunning = "isRunning";
    private const string IsDie = "IsDie";

    private void Awake() {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _flashBlink = GetComponent<FlashBlink>();
    }
    private void Start()
    {
        Player.Instance.OnPlayerDeath += Player_OnPlayerDeath;
    }

    private void Player_OnPlayerDeath(object sender, System.EventArgs e)
    {
        _animator.SetBool(Die, true);
        _flashBlink.StopBlinking();
    }

    private void Update() {
        _animator.SetBool(Running, Player.Instance.IsRunning());

        if (Player.Instance.IsAlive())
            AdjustPlayerFacingDirectoin();
    }

    private void AdjustPlayerFacingDirectoin() {
        Vector3 mousePos = GameInput.Instance.GetMousePositions();
        Vector3 playerPOS = Player.Instance.GetPlayerScreenPosition();

        if (mousePos.x < playerPOS.x) {
            _spriteRenderer.flipX = true;
        } else {
            _spriteRenderer.flipX = false;
        }
    }

    private void OnDestroy()
    {
        Player.Instance.OnPlayerDeath -= Player_OnPlayerDeath;
    }
}
