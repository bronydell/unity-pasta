using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
        [SerializeField]
        private float speed;
        [SerializeField]
        private float lifespanTime;
        
        // TODO: It would be a good idea to make it event, not Action
        private Action onEndLifetime;
        private Coroutine lifetimeCoroutine;

        public Action OnEndLifetime{ set => onEndLifetime = value; }

        public void Update()
        {
                transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }

        private IEnumerator LifespanCoroutine()
        {
                yield return new WaitForSeconds(lifespanTime);
                EndLifespan();
        }

        private void EndLifespan()
        {
                onEndLifetime?.Invoke();
        }

        public void ReturnToPool()
        {
                // This is what we do after we are done using our object
                gameObject.SetActive(false);
                if (lifetimeCoroutine != null)
                {
                        StopCoroutine(lifetimeCoroutine);
                        lifetimeCoroutine = null;
                }
        }

        public void RequestFromPool()
        {
                gameObject.SetActive(true);
                lifetimeCoroutine = StartCoroutine(LifespanCoroutine());
        }
}