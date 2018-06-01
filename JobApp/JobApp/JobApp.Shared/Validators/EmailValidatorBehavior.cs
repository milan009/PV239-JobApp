using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace JobApp.Shared.Validators
{
    /**
     * Source: https://www.c-sharpcorner.com/article/input-validation-in-xamarin-forms-behaviors/
     */
    public class EmailValidatorBehavior : Behavior<Entry>
    {
        const string EmailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        public bool IsValid { get; private set; } = true;

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
           IsValid = (Regex.IsMatch(e.NewTextValue, EmailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
           ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }
    }
}
