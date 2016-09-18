namespace PokeGo.Compass.Api.Exceptions
{
    public class UserNotFoundException : BusinessException
    {
        public UserNotFoundException() : base(BusinessCodeEnum.UserNotFound) { }
    }
}
