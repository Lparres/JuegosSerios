using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public float wanderRadius = 10f; // Radio de movimiento
    public float pauseTime = 3f;     // Tiempo que el NPC espera antes de moverse
    public bool isMovable = true;    // Controla si el NPC puede moverse (editable desde el inspector)

    private bool isWaiting = false; // Indica si el NPC está esperando

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (isMovable) MoveToRandomPosition();
    }

    void Update()
    {
        if (!isMovable)
        {
            UpdateAnimation(false); // Cambiar a idle si el movimiento está deshabilitado
            return;
        }

        // Comprobar si el NPC ha llegado al destino
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !isWaiting)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                StartCoroutine(PauseBeforeNextMove());
            }
        }

        // Si el agente no puede llegar a su destino, recalcula
        if (agent.pathStatus == NavMeshPathStatus.PathInvalid && !isWaiting)
        {
            Debug.LogWarning("Destino inalcanzable");
            MoveToRandomPosition();
        }

        // Actualizar animación según el movimiento del agente
        UpdateAnimation(agent.velocity.sqrMagnitude > 0f);
    }

    /// <summary>
    /// Mueve el NPC a una posición aleatoria dentro del NavMesh.
    /// </summary>
    private void MoveToRandomPosition()
    {
        if (!isMovable) return; // Si el movimiento está deshabilitado, no hace nada

        Vector3 randomPosition = GetRandomPosition(transform.position, wanderRadius);
        agent.SetDestination(randomPosition);
    }

    /// <summary>
    /// Genera una posición aleatoria válida en el NavMesh dentro del radio especificado.
    /// </summary>
    private Vector3 GetRandomPosition(Vector3 origin, float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += origin;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit navHit, radius, NavMesh.AllAreas))
        {
            return navHit.position;
        }

        // Si no se encuentra una posición válida, devuelve la posición original (para evitar errores)
        return origin;
    }

    /// <summary>
    /// Pausa al NPC antes de moverse a la siguiente posición.
    /// </summary>
    private System.Collections.IEnumerator PauseBeforeNextMove()
    {
        isWaiting = true; // Marca al NPC como esperando
        UpdateAnimation(false); // Cambiar a idle mientras espera
        yield return new WaitForSeconds(pauseTime); // Espera el tiempo definido
        isWaiting = false; // Reinicia el estado de espera
        MoveToRandomPosition(); // Mueve al NPC a un nuevo destino
    }

    /// <summary>
    /// Detiene el movimiento del NPC.
    /// </summary>
    public void StopMovement()
    {
        isMovable = false;
        agent.isStopped = true; // Detiene al NavMeshAgent
        UpdateAnimation(false); // Cambiar a idle
    }

    /// <summary>
    /// Reactiva el movimiento del NPC.
    /// </summary>
    public void ResumeMovement()
    {
        isMovable = true;
        agent.isStopped = false; // Reactiva al NavMeshAgent
        MoveToRandomPosition(); // Reinicia el movimiento
    }

    /// <summary>
    /// Actualiza el parámetro "isWalking" en el Animator.
    /// </summary>
    /// <param name="isWalking">True si el NPC está caminando, False si está en idle.</param>
    private void UpdateAnimation(bool isWalking)
    {
        if (animator != null)
        {
            animator.SetBool("isWalking", isWalking);
        }
    }
}
