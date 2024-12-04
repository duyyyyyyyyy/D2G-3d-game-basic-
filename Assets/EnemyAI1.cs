/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI1 : MonoBehaviour
{
    public NavMeshAgent agent;               
    public Transform player;                 
    public float detectionRange = 10f;       // Khoảng cách phát hiện Player
    public float chaseSpeed = 4f;            // Tốc độ khi đuổi theo Player
    public float patrolRange = 20f;          // Phạm vi tuần tra của Enemy
    public float timeBetweenPatrols = 3f;    // Thời gian giữa các lần đi tuần tra ngẫu nhiên
    public float patrolSpeed = 2f;           // Tốc độ khi tuần tra

    private bool isChasing = false;         

    void Start()
    {
        agent.speed = patrolSpeed;
        StartCoroutine(Patrol());
    }

    void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            DetectPlayer(); // Kiểm tra xem Player có trong phạm vi hay không
        }
    }

    // Di chuyển ngẫu nhiên trong phạm vi patrolRange
    IEnumerator Patrol()
    {
        while (!isChasing)
        {
            Vector3 randomPoint = RandomNavSphere(transform.position, patrolRange, -1);
            agent.SetDestination(randomPoint);
            yield return new WaitForSeconds(timeBetweenPatrols);
        }
    }

    // Tạo một điểm ngẫu nhiên trên NavMesh trong phạm vi
    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);
        return navHit.position;
    }

    void DetectPlayer()
    {
        // Phát hiện Player nếu trong khoảng cách detectionRange
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceToPlayer <= detectionRange)
        {
            isChasing = true;
            agent.speed = chaseSpeed; // Tăng tốc độ 
            //Debug.Log("Player detected! Chasing...");
        }
    }

    void ChasePlayer()
    {
        // Đặt điểm đích là vị trí của Player
        agent.SetDestination(player.position);

        // Kiểm tra khoảng cách tới Player
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceToPlayer > detectionRange)
        {
            // Nếu ko thấy Player, quay lại tuần tra
            isChasing = false;
            agent.speed = patrolSpeed; // Giảm tốc độ về tuần tra
            StartCoroutine(Patrol());
            //Debug.Log("Player lost. Returning to patrol...");
        }
    }
}
*/

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class EnemyAI1 : MonoBehaviour
//{
//    [SerializeField]
//    private NavMeshAgent navMeshAgent;

//    [SerializeField]
//    private float radius = 10f; //ban kinh check player

//    [SerializeField]
//    private Transform target;//player

//    void Start()
//    {

//    }
//    void Update()
//    {
//        //tinh khoang cach tu enemy = player
//        var distance = Vector3.Distance(target.position, transform.position);

//        if (distance < radius)
//        {
//            navMeshAgent.SetDestination(target.position);
//        }

//    }
//}

using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI1 : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private float radius = 10f; // Bán kính phát hiện player

    [SerializeField]
    private Transform target; // Player

    [SerializeField]
    private float patrolRadius = 15f; // Bán kính tuần tra

    [SerializeField]
    private float patrolInterval = 3f; // Thời gian giữa các lần tuần tra

    private bool isChasing = false; // Trạng thái có đang đuổi theo player không
    public int braincount;

    void Start()
    {
        // Bắt đầu tuần tra
        StartCoroutine(Patrol());
    }

    void Update()
    {

        Debug.Log(braincount);
        // Tính khoảng cách từ enemy đến player
        var distance = Vector3.Distance(target.position, transform.position);

        if (distance < radius)
        {
            // Nếu player trong phạm vi, đuổi theo player
            isChasing = true;
            navMeshAgent.SetDestination(target.position);
        }
        else
        {
            // Nếu player ngoài phạm vi, quay lại tuần tra
            isChasing = false;
        }

    }

    // Tuần tra ngẫu nhiên trong phạm vi bán kính
    IEnumerator Patrol()
    {
        while (true)
        {
            if (!isChasing) // Chỉ tuần tra khi không đuổi theo player
            {
                Vector3 randomPoint = RandomNavSphere(transform.position, patrolRadius, -1);
                navMeshAgent.SetDestination(randomPoint);
            }
            yield return new WaitForSeconds(patrolInterval); // Chờ trước khi chọn điểm tiếp theo
        }
    }

    // Hàm tạo điểm ngẫu nhiên trong phạm vi trên NavMesh
    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);
        return navHit.position;
        
    }

}
