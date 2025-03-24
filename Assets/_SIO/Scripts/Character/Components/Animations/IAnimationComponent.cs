public interface IAnimationComponent: ICharacterComponent
{
    public void SetAnimation(string animationName);
    public void SetTrigger(string triggerName);
    public void SetBool(string boolName, bool status);
    public void SetValue(string valueName, float value);
}
