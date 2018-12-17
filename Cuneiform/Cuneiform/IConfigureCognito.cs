namespace Cuneiform
{
  public interface IConfigureCognito
  {
    string UserPoolId { get; }
    string ClientId { get; }
  }
}