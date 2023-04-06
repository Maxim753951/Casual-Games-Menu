using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class Flap: MonoBehaviour
{
    /* PLAYER */

    [Header("Player")] [SerializeField] private string PlayerTag = "Player";
    [SerializeField] private ParticleSystem PlayerJumpParticles;
    [SerializeField] private float PlayerJump;
    [SerializeField] private KeyCode PlayerJumpKey;
    private Rigidbody2D _playerRigidbody;
    private bool _isDead;

    /* PLAYER / / SCORE */

    [Header("Score")] [SerializeField] private string ScoreTag = "Score";
    [SerializeField] private TextMeshProUGUI ScoreText;
    private int _score;

    /* SCORE / / SPIKES */

    [Header("Spikes")][SerializeField] private string SpikesTag;
    [SerializeField] private string InstantKillTag = "InstantKill";
    [SerializeField] private float SpikeScroll;
    [SerializeField] private Collider2D SpikeEndCollider;
    [SerializeField] private Transform SpikeStart;
    [SerializeField] private float MinY;
    [SerializeField] private float MaxY;
    private Rigidbody2D _spikeRigidbody;

    /* SPIKES / / UNITY EVENT METHODS */

    private void Awake()
    {
        if (gameObject.CompareTag(PlayerTag))
            _playerRigidbody = GetComponent<Rigidbody2D>();
        else if (gameObject.CompareTag(SpikesTag))
            _spikeRigidbody = GetComponent<Rigidbody2D>();

        //Physics2D.IgnoreCollision(gameObject.collider.CompareTag(SpikesTag), CompareTag(InstantKillTag), true);
    }

    private void Update()
    {
        if (gameObject.CompareTag(PlayerTag) && Input.GetKeyDown(PlayerJumpKey) && !_isDead)
        {
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, PlayerJump);
            PlayerJumpParticles.Play();
        }

        if (Input.GetKey(KeyCode.Escape) == true)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate()
    {
        if (gameObject.CompareTag(SpikesTag))
        {
            _spikeRigidbody.MovePosition(_spikeRigidbody.position - Vector2.right * SpikeScroll);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag(PlayerTag))
        {
            if (collision.collider.CompareTag(SpikesTag))
                StartCoroutine(Co_Death(1f));
            else if (collision.collider.CompareTag(InstantKillTag))
                StartCoroutine(Co_Death(0.5f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (gameObject.CompareTag(PlayerTag) && collider.CompareTag(ScoreTag) && !_isDead)
        {
            _score++;
            ScoreText.text = _score.ToString();
        }
        else if (gameObject.CompareTag(SpikesTag) && collider == SpikeEndCollider)
        {
            Vector3 __startPosition = SpikeStart.position;
            __startPosition.y = Random.Range(MinY, MaxY);
            _spikeRigidbody.position = __startPosition;
        }
    }

    /* UNITY EVENT METHODS / / Death */

    private IEnumerator Co_Death(float delay)
    {
        _isDead = true;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
