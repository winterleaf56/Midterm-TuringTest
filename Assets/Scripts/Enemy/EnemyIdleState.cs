using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState {
    int currentTarget = 0;

    public EnemyIdleState(EnemyController enemy) : base(enemy) {

    }

    public override void OnStateEnter() {
        _enemy.agent.destination = _enemy.targetPoints[currentTarget].position;
    }

    public override void OnStateExit() {
        Debug.Log("Enemy stopped idling");
    }

    public override void OnStateUpdate() {
        if (_enemy.agent.remainingDistance < 0.5f) {
            currentTarget++;

            if (currentTarget >= _enemy.targetPoints.Length) {
                currentTarget = 0;
            }

            _enemy.agent.destination = _enemy.targetPoints[currentTarget].position;
        }

        if (Physics.SphereCast(_enemy.enemyEye.position, _enemy.checkRadius, _enemy.enemyEye.forward, out RaycastHit hit, _enemy.playerCheckDistance)) {
            if (hit.collider.CompareTag("Player")) {
                Debug.Log("Player Found");

                _enemy.player = hit.transform;
                _enemy.agent.destination = _enemy.player.position;

                _enemy.ChangeState(new EnemyFollowState(_enemy));
            }
        }
    }
}
