namespace Fox
{
    public struct EntityPtr<T> where T : Entity
    {
        T ptr;
        uint refCount;
    }
}
