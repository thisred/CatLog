namespace ET
{
    /// <summary>
    /// 虾猫分不同朝向，在编队里面如果是同样朝向的一起冲撞，朝向端就会收到两只猫的合力攻击
    /// 相反方向情况1：合成一个爱心虾，会在旁边加油
    /// 相反情况2：出现X虾（两虾背靠背）的时候，双方虾消失
    /// </summary>
    [ChildOf]
    public class ShrimpAbility : Entity, IAbility, IAwake
    {
    }
}