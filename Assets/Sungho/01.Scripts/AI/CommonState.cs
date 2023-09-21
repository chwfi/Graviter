
public abstract class CommonState<T> where T : class //���⿡ brain�� ��
{
    public abstract void OnEnterState(T brain);
    public abstract void OnExitState(T brain);
    public abstract void UpdateState(T brain);

    public virtual void SetUp() { } //ó�� ������ �� Awake����
}
