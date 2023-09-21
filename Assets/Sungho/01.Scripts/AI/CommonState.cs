
public abstract class CommonState<T> where T : class //여기에 brain이 들어감
{
    public abstract void OnEnterState(T ownerEntity);
    public abstract void OnExitState(T ownerEntity);
    public abstract void UpdateState(T ownerEntity);

    public virtual void SetUp() { } //처음 시작할 때 Awake느낌
}
