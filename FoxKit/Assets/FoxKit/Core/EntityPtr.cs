namespace Fox
{
    struct EntityPtr<T> where T : Entity
    {
        T ptr;
        uint refCount;
    }
}
