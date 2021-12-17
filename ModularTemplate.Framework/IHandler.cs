namespace ModularTemplate.Framework
{
    public interface IHandler<TParam, TResponse>
    {
        IResponse<TResponse> Handle(TParam param);
    }

    public interface IHandlerWithParam<TParam>
    {
        IResponse Handle(TParam param);
    }

    public interface IHandlerWithResponse<TResponse>
    {
        IResponse<TResponse> Handle();
    }
}