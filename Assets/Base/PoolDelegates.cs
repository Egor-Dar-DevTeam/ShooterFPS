using BaseInterfaces;

namespace Base
{
    public static class PoolDelegates
    {
        public delegate void ReleasePoolObject(IPoolObject poolObject);
    }
}