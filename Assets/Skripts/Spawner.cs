using UnityEngine;
using UnityEngine.Pool;

namespace Spawn
{
    public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected T _object;
        [SerializeField] protected int initialPoolSize = 10;
        [SerializeField] protected int maxPoolSize = 100;

        public ObjectPool<T> _pool;

        private void Start()
        {
            _pool = new ObjectPool<T>(
            createFunc: () => Create(),  // Функция создания нового объекта
            actionOnGet: obj => obj.gameObject.SetActive(true),  // Действие при извлечении объекта из пула
            actionOnRelease: obj => obj.gameObject.SetActive(false),  // Действие при возврате объекта в пул
            actionOnDestroy: Destroy,  // Действие при уничтожении объекта
            collectionCheck: false,  // Отключение проверки двойного добавления в пул
            defaultCapacity: initialPoolSize,  // Начальный размер пула
            maxSize: maxPoolSize  // Максимальный размер пула
            );
        }

        protected T Spawn(Vector3 position, Quaternion rotation)
        {
            T obj = _pool.Get();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            return obj;
        }

        protected void ReturnToPool(T obj)
        {
            _pool.Release(obj);
        }


        private T Create()
        {
            T obj = Instantiate(_object, transform);
            return obj;
        }
    }
}