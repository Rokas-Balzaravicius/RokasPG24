using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
   
    Animator ZombieAnimator;
    PlayerMovement lockOnTo;
    internal float maxMeleeDistance = 2f;
    enum NPCState { Patrol, Chase, Attack }
    enum NPCTransitions { None, See_Target, Within_Melee_Range }

    NPCTransitions NPCWorldChange = NPCTransitions.None;

    NPCState isCurrently = NPCState.Patrol;
    internal float breakAwayDistance = 7f;
    internal float chaseSpeed = 2f;
    internal float timer;
    internal float patrolChangeDirectionTime = 5f;
    internal float patrolSpeed = 1f;
    internal float AttackCoolDown = 2f;

    // Start is called before the first frame update
    internal void Start()
    {
        ZombieAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        NPCWorldChange = senseNPCWorldChange();

        switch (isCurrently)
        {
            case NPCState.Patrol:
                switch(NPCWorldChange)
                {
                    case NPCTransitions.See_Target:

                        isCurrently = NPCState.Chase;
                        break;

                    case NPCTransitions.Within_Melee_Range:
                        isCurrently = NPCState.Attack;
                        break;
                }

                break;

            case NPCState.Chase:
                {
                    switch(NPCWorldChange)
                    {
                        case NPCTransitions.See_Target:

                            isCurrently = NPCState.Chase;
                            break;


                        case NPCTransitions.Within_Melee_Range:
                            isCurrently = NPCState.Attack;
                            break;


                        case NPCTransitions.None:
                            isCurrently = NPCState.Patrol;
                            break;
                    }
                }
                break;

            case NPCState.Attack:

                switch(NPCWorldChange) 
                {
                    case NPCTransitions.See_Target:
                        isCurrently = NPCState.Chase;
                        break;

                    case NPCTransitions.Within_Melee_Range:
                        isCurrently = NPCState.Attack;
                        break;

                    case NPCTransitions.None:
                        isCurrently = NPCState.Patrol;
                        break;

                }

                break;
        }

        ZombieAnimator.SetBool("isRunningZombie", false);
        ZombieAnimator.SetBool("isAttackingZombie", false);
        ZombieAnimator.SetBool("isWalkingZombie", false);

        switch (isCurrently)
        {
            case NPCState.Chase:
                Vector3 target = lockOnTo.transform.position;
                target.y = transform.position.y;
                transform.LookAt(target);
                transform.position += chaseSpeed * transform.forward * Time.deltaTime;
                ZombieAnimator.SetBool("isRunningZombie",true);
                break;

            case NPCState.Attack:
                timer -= Time.deltaTime;

                if (timer < 0)
                {
                    print("Zombie Attack");
                    lockOnTo.takeDamage(10);
                    timer = AttackCoolDown;
                }

                ZombieAnimator.SetBool("isAttackingZombie", true);

                break;

            case NPCState.Patrol:

                timer -= Time.deltaTime;

                if (timer < 0)
                {
                    transform.Rotate(Vector3.up,
                        UnityEngine.Random.Range(0f, 360f));
                    timer = patrolChangeDirectionTime;
                }

                transform.position +=
                    patrolSpeed * transform.forward * Time.deltaTime;
                ZombieAnimator.SetBool("isWalkingZombie", true);


                break;
        }

         NPCTransitions senseNPCWorldChange()
        
        {
            if (lockOnTo)
            {
                if (Vector3.Distance(transform.position, lockOnTo.transform.position) < maxMeleeDistance)
                {
                    return NPCTransitions.Within_Melee_Range;
                }

                if (Vector3.Distance(transform.position, lockOnTo.transform.position) > breakAwayDistance)
                {
                    lockOnTo = null;
                    return NPCTransitions.None;


                }

                return NPCTransitions.See_Target;

            }
            Collider[] allThingsInFront =

                Physics.OverlapSphere(
                    transform.position + 4.5f * transform.forward,
                                5);

            foreach (Collider c in allThingsInFront)
            {

                if (c.TryGetComponent<PlayerMovement>(out lockOnTo))
                {
                    if (Vector3.Distance(transform.position,
                        c.transform.forward) < maxMeleeDistance)

                        return NPCTransitions.Within_Melee_Range;
                    else
                        return NPCTransitions.See_Target;
                }



            }

            return NPCTransitions.None;
        }



    }

}

