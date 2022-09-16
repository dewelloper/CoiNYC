using CoiNYC.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoiNYC.Infrastructure
{
    public enum ButtonType
    {
        Button,
        Dropdown
    }


    public class DropdownButtonModel : ButtonBaseModel
    {
        public override ButtonType Type => ButtonType.Dropdown;
        public List<ButtonModel> Buttons { get; set; }

        public DropdownButtonModel()
        {
            Buttons = new List<ButtonModel>();
        }

        public DropdownButtonModel Add(ButtonModel button)
        {
            Buttons.Add(button);
            return this;
        }
    }

    public abstract class ButtonBaseModel
    {
        public int Order { get; set; }
        public string Text { get; set; }
        public string Class { get; set; }
        public string PrependIcon { get; set; }
        public string AppendIcon { get; set; }

        public abstract ButtonType Type { get; }
    }

    public class ButtonModel : ButtonBaseModel
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public object RouteValues { get; set; }
        public ButtonBinding Binding { get; set; }

        public override ButtonType Type => ButtonType.Button;
    }

    public enum BindingType
    {
        ActiveRecord,
        FiltersAndPageSettings
    }

    public enum ActionTarget
    {
        Dialog,
        Window,
        Popup,
        RedirectToResult

    }

    public class ButtonBinding
    {
        public BindingType? Binding { get; set; }
        [AppIgnore]
        public List<string> Properties { get; set; }
        public ActionTarget? ActionTarget { get; set; }

        public string BindingProps
        {
            get
            {
                if (Properties == null)
                    return null;
                return String.Join(",", Properties);
            }
        }

        public ButtonBinding AddProperties(params string[] properties)
        {
            if (Properties == null)
                Properties = new List<string>();
            Properties.AddRange(properties);
            return this;
        }
    }
}