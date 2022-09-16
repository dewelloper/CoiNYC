using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoiNYC.Infrastructure
{
    public class FieldError
    {
        public string FieldName { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class JsonResultEntry
    {

        public JsonResultEntry()
        {
            Success = true;
            Messages = new string[0];
            FieldErrors = new FieldError[0];
        }

        public JsonResultEntry(ModelStateDictionary modelState)
            : this()
        {
            AddModelState(modelState);
            Success = false;
        }

        public JsonResultEntry SetFailed()
        {
            Success = false;
            return this;
        }

        public JsonResultEntry SetSuccess()
        {
            Success = true;
            return this;
        }

        public JsonResultEntry AddModelState(ModelStateDictionary modelState)
        {
            foreach (var ms in modelState)
            {
                foreach (var err in ms.Value.Errors)
                {
                    AddMessage(err.ErrorMessage);
                }
            }

            return this;
        }

        public bool Success { get; set; }

        public string[] Messages { get; set; }

        public object Model { get; set; }

        public FieldError[] FieldErrors { get; set; }

        public JsonResultEntry AddFieldError(string fieldName, string message)
        {
            Success = false;
            FieldErrors = FieldErrors.Concat(new[] { new FieldError() { FieldName = fieldName, ErrorMessage = message } }).ToArray();
            return this;
        }

        public JsonResultEntry AddMessage(string message)
        {
            Messages = Messages.Concat(new[] { message }).ToArray();
            return this;
        }

        public JsonResultEntry AddException(System.Exception e)
        {
            Success = false;
            return AddMessage(e.Message);
        }
    }

}
