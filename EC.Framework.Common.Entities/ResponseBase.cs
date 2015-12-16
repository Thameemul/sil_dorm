namespace EC.Framework.Common.Entities
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public abstract class ResponseBase
  {
    private string internalMessage;
    protected ResponseBase()
    {
      this.ErrorMessages = new List<ErrorMessage>();
    }

    public List<ErrorMessage> ErrorMessages { get; set; }

    public bool IsOk
    {
      get { return this.ErrorMessages.Count == 0; }
      private set { }
    }

    public string Message
    {
      get
      {
        if (this.IsOk)
        {
          return this.internalMessage;
        }
        else
        {
          return string.Join("<br />", this.ErrorMessages);
        }
      }

      private set { }
    }

    public bool HasWarning { get; private set; }

    public void Error(string message)
    {
      this.ErrorMessages.Add(new ErrorMessage { Name = string.Empty, Message = message });
    }

    public void Error(string name, string message)
    {
      this.ErrorMessages.Add(new ErrorMessage { Name = name, Message = message });
    }

    public void Success(string message)
    {
      this.internalMessage = message;
    }

    public void Warning(string message)
    {
      this.HasWarning = true;
      this.internalMessage = message;
    }

    public object ReturnValue { get; set; }
  }
}
