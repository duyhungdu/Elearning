using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using LiteSchool.Library.Domain;

namespace LiteSchool.Core.Messages
{
    /// <summary>
    /// BaseResponse is used to implement the Request-Response pattern.
    /// All returned objects in the Service layer should inherit from this class.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class BaseResponse
    {
        private bool showNotification;
        [DataMember()]
        public bool ShowNotification
        {
            get { return showNotification; }
            set { showNotification = value; }
        }

        private bool success;
        [DataMember()]
        public bool Success
        {
            get { return success; }
            set { success = value; }
        }

        private string errorMessage;
        [DataMember()]
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }

        private List<ValidationRule> brokenRules;
        [DataMember()]
        public List<ValidationRule> BrokenRules
        {
            get { return brokenRules; }
            set { brokenRules = value; }
        }

        public BaseResponse()
            : this(false, new List<ValidationRule>())
        {        
        }
        
        public BaseResponse(bool success, List<ValidationRule> brokenRules) : this(success, brokenRules, null)
        {         
        }

        public BaseResponse(bool success, List<ValidationRule> brokenRules, string errorMessage)
        {
            Success = success;
            BrokenRules = brokenRules;
            ErrorMessage = errorMessage;
            ShowNotification = true;
        }
    }

    [DataContract()]
    public class BaseResponse<T> : BaseResponse
    {
        public BaseResponse(T value)
        {
            this.Value = value;
        }

        public BaseResponse()
        {
        }

        [DataMember()]
        public T Value;
    }
}
