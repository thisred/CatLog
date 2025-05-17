namespace ET
{
    public interface ITBSState
    {
        void Enter(TBSRoom room);
        void Execute(TBSRoom room);
        void Exit(TBSRoom room);
        void Update(TBSRoom room, float deltaTime);
    }
}