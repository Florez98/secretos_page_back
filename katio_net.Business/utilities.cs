using System.Net;
using katio.Data.Dto;
using katio.Data.Models;

namespace katio.Business.Utilities;
public static class Utilities 
{

  #region BaseMessages
  public static BaseMessage<T> BuilResponse<T>(HttpStatusCode statusCode, string message, List<T>? elements = null)
  where T:class
  {
    return new BaseMessage<T>()
    {
      statusCode = statusCode,
      Message = message,
      TotalElements = (elements!=null&&elements.Any())?elements.Count:0,
      ResponseElements = elements ?? new List<T>()

    };
  }
  #endregion
  
}