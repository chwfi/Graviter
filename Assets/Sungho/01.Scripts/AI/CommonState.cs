
public abstract class CommonState<T> where T : class //���⿡ brain�� ��
{
    public abstract void OnEnterState(T ownerEntity);
    public abstract void OnExitState(T ownerEntity);
    public abstract void UpdateState(T ownerEntity);

    public virtual void SetUp() { } //ó�� ������ �� Awake����
}
