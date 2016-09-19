using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.PropertyEditors;

namespace Umbraco.Web.PropertyEditors
{
    [PropertyEditor(Constants.PropertyEditors.EmailAddressAlias, "Email address", "email", Icon="icon-message")]
    public class EmailAddressPropertyEditor : PropertyEditor
    {
        /// <summary>
        /// The constructor will setup the property editor based on the attribute if one is found
        /// </summary>
        public EmailAddressPropertyEditor(ILogger logger) : base(logger)
        {
        }

        protected override PropertyValueEditor CreateValueEditor()
        {
            var editor = base.CreateValueEditor();
            //add an email address validator
            editor.Validators.Add(new EmailValidator());
            return editor;
        }

        protected override PreValueEditor CreatePreValueEditor()
        {
            return new EmailAddressePreValueEditor();
        }

        internal class EmailAddressePreValueEditor : PreValueEditor
        {
            //TODO: This doesn't seem necessary since it can be specified at the property type level - this will however be useful if/when
            // we support overridden property value pre-value options.
            [PreValueField("Required?", "boolean")]
            public bool IsRequired { get; set; }
        }

    }
}